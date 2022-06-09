using MHRS_ApplicationBusinessLayer.EMailService;
using MHRS_ApplicationEntityLayer.Enums;
using MHRS_ApplicationEntityLayer.IdentityModels;
using MHRS_ApplicationUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace MHRS_ApplicationUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailSenderService _emailSenderService;

        public AccountController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IEmailSenderService emailSenderService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _emailSenderService = emailSenderService;
        }
        [HttpGet]
        public IActionResult Register()
        {
            if (_signInManager.IsSignedIn(HttpContext.User))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model); //modeli nos gonderdik textboxlar bosalacak
                }
                var checkIdtfNumber = await _userManager.FindByNameAsync(model.IdentificationNumber);
                if (checkIdtfNumber != null)
                {
                    throw new Exception("Bu TC sisteme zaten kayıtlıdır!");
                }
                var checkEmail = await _userManager.FindByEmailAsync(model.Email);
                if (checkEmail != null)
                {
                    ModelState.AddModelError("", "Bu Email ile sisteme zaten kayıt yapılmıştır!");
                }
                //artık kayıt edilebilir
                AppUser user = new AppUser()
                {
                    Email = model.Email,
                    Name = model.Name,
                    Surname = model.Surname,
                    Gender = model.Gender,
                    UserName = model.IdentificationNumber,
                    BirthDate = model.BirthDate.HasValue ? model.BirthDate.Value : null,
                    RegisterDate = DateTime.Now,
                    IdentificationNumber = model.IdentificationNumber,
                };
                var result = await _userManager.CreateAsync(user, model.Password); //aspnet users tablosuna kullanıcı ekler, insert into.....
                if (result.Succeeded)
                {
                    //kullanıcı eklendi. ona rol verelim
                    await _userManager.AddToRoleAsync(user, MHRSRoles.Passive.ToString()); //ilk eklendiğinde pasif olacak

                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
                    //emailde gönderilecek link
                    var callBackUrl = Url.Action("ConfirmPatient", "Account", new { userId = user.Id, token = token }, protocol: Request.Scheme);
                    var email = new EMailMessage()
                    {
                        Contacts = new string[] { user.Email },
                        Subject = "MHRS KAYIT ONAY",
                        Body = $"Merhaba {user.Name} {user.Surname} <br/>" +
                        $"Hesabınızı aktifleştirmek için <a href='{callBackUrl}'> buraya </a> tıklayınız..."
                    };
                    await _emailSenderService.SendAsync(email);
                    //KAYIT OLUR OLMAZ LOGIN SAYFASINA YONLENDIRIYORUZ
                    return RedirectToAction("Login", "Account", new { idtfnumber = model.IdentificationNumber });
                }
                else
                {
                    throw new Exception("Hasta ekleme işlemi başarısız oldu!Daha sonra tekrar deneyiniz!");
                }
            }
            catch (Exception ex)
            {
                //ex loglansın
                ViewBag.RegisterErrorMessage = "Beklenmedik hata nedeniye sisteme kaydınız yapılamadı! Tekrar deneyiniz!" + ex.Message;
                return View(model);
            }

        }
        [HttpGet]
        public IActionResult Login(string idtfnumber)
        {
            if (_signInManager.IsSignedIn(HttpContext.User))
            {
                return RedirectToAction("Index", "Home");
            }
            LoginViewModel model = new LoginViewModel()
            {
                IdentificationNumber = idtfnumber
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                //userı bulalım
                var user = await _userManager.FindByNameAsync(model.IdentificationNumber);
                if (user == null)
                {
                    ModelState.AddModelError("", "Bu TC numarası sistemimizde kayıtlı değildir! Kayıt olunuz!"); ;
                    return View(model);
                }
                //user varsa
                if (!user.EmailConfirmed)
                {
                    ModelState.AddModelError("", "Sistemi kullanabilmek için lütfen EPostanıza gönderilen aktivasyon linkine tıklayarak hesabınızı aktif hale getiriniz!"); ;
                    return View(model);
                }
                //giriş yapsın

                var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Patient");
                }
                else
                {
                    ModelState.AddModelError("", "TC ya da Şifreniz Hatalıdır!");
                    return View(model);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Beklenmedik bir sorun oluştu! Tekrar deneyiniz!"); ;
                return View(model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> ConfirmPatient(string userId, string token)
        {
            try
            {
                if (userId == null || token == null)
                {
                    throw new Exception("Kullanıcıyı aktifleştirmek için tıkladığınız link hatalıdır!");
                }
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    throw new Exception("Kullanıcı bulunamadı! Link hatalı!");
                }
                if (user.EmailConfirmed)
                {
                    TempData["PatientEmailConfirmedMessage"] = "Hesabınızı zaten aktifleştirmişsiniz. Artık giriş yapabilirsiniz.";
                    return RedirectToAction("Login", "Account", new { idtfnumber = user.IdentificationNumber });
                }
                var tokenDeCode = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));
                //aspnetusers set emailconfirmed=1 where ıd=user.ıd
                //kullanıcının emailini aktifleştirdik
                var result = await _userManager.ConfirmEmailAsync(user, tokenDeCode);
                if (result.Succeeded) //rol ataması
                {
                    //rolü sil
                    await _userManager.RemoveFromRoleAsync(user, MHRSRoles.Passive.ToString());
                    await _userManager.AddToRoleAsync(user, MHRSRoles.Patient.ToString());
                    TempData["PatientEmailConfirmedMessage"] = "Hesabınız aktifleştirilmiştir.";
                    return RedirectToAction("Login", "Account", new { idtfnumber = user.IdentificationNumber });
                }
                else
                {
                    throw new Exception("Aktifleştirme işleminde bir hata oluştu!");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ConfirmPatient("Beklenmedik hata:" + ex.Message);
                return View();
            }
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    ViewBag.ResetPasswordErrorMessage = "Girdiğiniz bu email sistemimizde kayıtlı değildir! Lütfen önce kayıt olunuz! ";
                    return View();
                }

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var tokenEncoded = WebEncoders.Base64UrlEncode
                    (Encoding.UTF8.GetBytes(token));
                // www.localhost:xxxxx/Account/ConfirmResetPassword?userId=xx&token=xx
                var url = Url.Action("ConfirmResetPassword", "Account",
                    new { userId = user.Id, token = tokenEncoded },
                    protocol: Request.Scheme);  // www.localhost:xxxxx

                var emailMessage = new EMailMessage()
                {
                    Contacts = new string[] { user.Email },
                    Subject = "MHRS303 - Şifremi Unuttum!",
                    Body = $"Merhaba {user.Name} {user.Surname} <br/>" +
                    $"Yeni parola belirlemek için " +
                    $"<a href='{HtmlEncoder.Default.Encode(url)}'> buraya </a> tıklayınız... "
                };
                await _emailSenderService.SendAsync(emailMessage);
                ViewBag.ResetPasswordMessage = "Emailinize şifre güncelleme talebi gönderilmiştir!";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ResetPasswordErrorMessage = "Beklenmedik bir hata oluştu! ";
                return View();

            }
        }
        [HttpGet]
        public IActionResult ConfirmResetPassword(string userId, string token)
        {
            if (userId == null || token == null)
            {
                ModelState.AddModelError("", "Kullanıcı bulunamadı!");
                return View();
            }
            //ViewBag.userId = userId;
            //ViewBag.Token = token;
            ResetPasswordViewModel model = new ResetPasswordViewModel()
            {
                UserId = userId,
                Token = token
            };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmResetPassword(ResetPasswordViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user == null)
                {
                    ModelState.AddModelError("", "Kullanıcı bulunamadı");
                    return View(model);
                }
                var tokenDecode = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(model.Token));
                var result = await _userManager.ResetPasswordAsync(user, tokenDecode, model.NewPassword);

                if (result.Succeeded)
                {
                    TempData["ConfirmResetPasswordMessage"] = "Şifreniz başarıyla değiştirilmiştir.";
                    return RedirectToAction("Login", "Account", new { tc = user.IdentificationNumber });
                }
                else
                {
                    ModelState.AddModelError("", "HATA: Parolanız değiştirilemedi!");
                    return View();
                }
            }
            catch (Exception ex)
            {
                // ex loglanabilir
                ModelState.AddModelError("", "Beklenmedik bir hata oluştu");
                return View();
            }
        }
    }
}

