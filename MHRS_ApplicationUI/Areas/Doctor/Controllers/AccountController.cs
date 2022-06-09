
using MHRS_ApplicationBusinessLayer.EMailService;
using MHRS_ApplicationEntityLayer.Enums;
using MHRS_ApplicationEntityLayer.IdentityModels;
using MHRS_ApplicationUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS303UI.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    public class AccountController : Controller
    {
        //Burada doktor register işlemi yapılacaktır
        //Zaman kısıtlı old. için sadece register işlemini yapacağız

        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailSenderService _emailSenderManager;

        public AccountController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IEmailSenderService emailSenderManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _emailSenderManager = emailSenderManager;
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
                    return View(model);
                }
                var checkTcNumber = await _userManager.FindByNameAsync(model.IdentificationNumber);
                if (checkTcNumber != null)
                {
                    throw new Exception("Bu TC ile sisteme zaten kayıtlıdır!");
                }

                var checkEmail = await _userManager.FindByEmailAsync(model.Email);
                if (checkEmail != null)
                {
                    ModelState.AddModelError("", "Bu email ile sisteme zaten kayıt yapılmıştır!");
                    return View(model);
                }
                // artık sisteme kayıt olabilir
                AppUser user = new AppUser()
                {
                    Email = model.Email,
                    Name = model.Name,
                    Surname = model.Surname,
                    Gender = model.Gender,
                    UserName = model.IdentificationNumber,
                    BirthDate = model.BirthDate.HasValue ? model.BirthDate.Value : null,
                    RegisterDate = DateTime.Now,
                    IdentificationNumber = model.IdentificationNumber
                };

                // aspnetusers tablosuna kullanıcı ekler
                //sql gider insert into AspnetUsers () values ()
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //DOKTOR eklendi. Ona role ekleyelim
                    await _userManager.AddToRoleAsync(user, MHRSRoles.PassiveDoctor.ToString());
                    //kullanıcının rolü eklendi.

                    var token = await _userManager
                        .GenerateEmailConfirmationTokenAsync(user);
                    token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
                    //emailde gönderilecek link
                    var callBackUrl = $"{Request.Path}/Doctor/Account/ConfirmDoctor?userId={user.Id}&token={token}";

                    var email = new EMailMessage()
                    {
                        Contacts = new string[] { user.Email },
                        Subject = $"MHRS303'e Hoşgeldiniz Dr.{user.Name} {user.Surname}",
                        Body = $"Merhaba <br/>" +
                        $"Hesabınızı aktifleştirmek için <a href='{callBackUrl}'> buraya </a> tıklayınız..."
                    };
                    await _emailSenderManager.SendAsync(email);
                    //kayıt olur olmaz login sayfasına yönlendiriliyoruz
                    return RedirectToAction("Login", "Account", new { area = "Doctor", tc = model.IdentificationNumber });
                }
                else
                {
                    throw new Exception("Hasta ekleme işlemi başarısız oldu! Daha sonra tekrar deneyiniz!");
                }

            }
            catch (Exception ex)
            {
                //ex loglanacak
                ViewBag.RegisterErrorMessage = "Beklenmedik bir hata nedeniyle sisteme kaydınız yapılamadı! Tekrar deneyiniz! " + ex.Message;
                return View(model);
            }
        }


        [HttpGet]
        public async Task<IActionResult> ConfirmDoctor(string userId, string token)
        {
            try
            {
                if (userId == null || token == null)
                {
                    ViewBag.ConfirmDoctorErrorMessage = "Kullanıcıyı aktifleştirmek için tıkladığınız link hatalıdır! ";
                    return View();
                }
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    ViewBag.ConfirmDoctorErrorMessage = "Kullanıcı bulunamadı! Kullanıcıyı aktifleştirmek için tıkladığınız link hatalıdır!";
                    return View();
                }

                if (user.EmailConfirmed)
                {
                    TempData["DoctorEmailConfirmedMessage"] = "Hesabınızı zaten aktifleştirmişsiniz. Artık giriş yapabilirsiniz...";

                    return RedirectToAction("Login", "Account", new { area = "Doctor", tc = user.IdentificationNumber });
                }
                var tokenDecode = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));

                //ConfirmEmailAsync metodu sql'de update AspnetUsers set EmailConfirmed=1 where Id=user.Id sorgusunu işler.
                //kullanıcının emailini aktifleştirdik
                var result = await _userManager.ConfirmEmailAsync(user, tokenDecode);

                if (result.Succeeded)
                {
                    //pasifdoktor rolünü sil aktifdoktor rol ekle
                    await _userManager.RemoveFromRoleAsync(user, MHRSRoles.PassiveDoctor.ToString());
                    await _userManager.AddToRoleAsync(user, MHRSRoles.ActiveDoctor.ToString());
                    TempData["DoctorEmailConfirmedMessage"] = "Hesabınız aktifleştirilmiştir...";
                    return RedirectToAction("Login", "Account", new { area = "Doctor", tc = user.IdentificationNumber });
                }
                else
                {
                    throw new Exception("Aktifleştirme işleminde bir sorun oluştu!");
                }
            }
            catch (Exception ex)
            {
                // ex loglanabilir
                ViewBag.ConfirmDoctorErrorMessage = "Doktor hesabı etkinleştirmede beklenmedik bir hata oluştu! ";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Login(string idtf)
        {
            LoginViewModel model = new LoginViewModel()
            {
                IdentificationNumber = idtf
            };
            return View(model);
        }
    }

}