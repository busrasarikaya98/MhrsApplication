using MHRS_ApplicationBusinessLayer.Abstracts;
using MHRS_ApplicationEntityLayer.Enums;
using MHRS_ApplicationEntityLayer.IdentityModels;
using MHRS_ApplicationEntityLayer.ViewModels;
using MHRS_ApplicationUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MHRS_ApplicationUI.Controllers
{
    public class PatientController : Controller
    {
        private readonly ICityService _cityManager;
        private readonly IClinicService _clinicManager;
        private readonly IHospitalClinicService _hospitalClinicManager;
        private readonly IAppointmentHourService _appointmentHourManager;
        private readonly IAppointmentService _appointmentManager;
        private readonly IHospitalService _hospitalManager;
        private readonly UserManager<AppUser> _userManager;

        public PatientController(ICityService cityManager, IClinicService clinicManager, IHospitalClinicService hospitalClinicManager, IAppointmentHourService appointmentHourManager, IAppointmentService appointmentManager, IHospitalService hospitalManager, UserManager<AppUser> userManager)
        {
            _cityManager = cityManager;
            _clinicManager = clinicManager;
            _hospitalClinicManager = hospitalClinicManager;
            _appointmentHourManager = appointmentHourManager;
            _appointmentManager = appointmentManager;
            _hospitalManager = hospitalManager;
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index(int pageNumberFuture=1,int pageNumberPast=1)
        {
            ViewBag.pageNumberFuture = pageNumberFuture;
            ViewBag.pageNumberPast = pageNumberPast;
            return View();
        }

        [Authorize]
        public IActionResult Appointment()
        {
            //İlleri  klinkleri   comboboxlara aracılığıyla seçeceğiz.
            try
            {
                ViewBag.Cities = _cityManager.GetAllCities(null).Data;
                ViewBag.Clinics = _clinicManager.GetAllClinics(null).Data;
                return View();
            }
            catch (Exception)
            {
                return View();

            }
        }

        [Authorize]
        public IActionResult FindAppointment(int cityId, int? districtId, int clinicId,
            int? hospitalId, string doctorId)
        {
            try
            {
                var returnList = new List<AppointmentViewModel>();
                TempData["ClinicId"] = clinicId;
                TempData["HospitalId"] = hospitalId != null ? hospitalId : null;
                //öncelikle clinicId'den data çekicem
                var data = _hospitalClinicManager.GetAll(x => x.ClinicId == clinicId).Data;

                //ilçeyi seçtiyse
                if (districtId.HasValue && districtId.Value > 0)
                {
                    data = data.Where(x => x.Hospital.DistrictId == districtId.Value).ToList();
                }

                //eğer hastane seçildiyse
                if (hospitalId.HasValue && hospitalId.Value > 0)
                {
                    data = data.Where(x => x.HospitalId == hospitalId.Value).ToList();
                }
                // eğer doktor seçildiyse
                if (!string.IsNullOrEmpty(doctorId)
                    && doctorId != "undefined")
                {
                    data = data.Where(x => x.DoctorId == doctorId).ToList();
                }
                //Randevusu müsait olan doktorları ve saatlerini sayfaya göndereceğiz
                //bizim sistemde sadece ertesi güne randevu verilmektedir.
                var appointmentDate = DateTime.Now.AddDays(1);
                // Eğer haftasonuna denk geliyorsa tarihi pztye çekmelisin!
                DayOfWeek day = appointmentDate.DayOfWeek;
                if (day == DayOfWeek.Saturday)
                {
                    appointmentDate = appointmentDate.AddDays(2);
                }
                else if (day == DayOfWeek.Sunday)
                {
                    appointmentDate = appointmentDate.AddDays(1);
                }

                ViewBag.AppointmentDate = appointmentDate.ToShortDateString();
                foreach (var item in data)
                {
                    // acaba bu doktorın çalışma saatleri nedir?
                    var drAppointmentHoursList = _appointmentHourManager.GetAll(
                        x => x.HospitalClinicId == item.Id).Data.FirstOrDefault();

                    // dr'nin çalışma saatleri
                    foreach (var hourItem in drAppointmentHoursList.Hours.Split(','))
                    {
                        var appointmentCount = _appointmentManager.GetAll
                                (x => x.HospitalClinicId == item.Id
                                &&
                                x.AppointmentStatus == AppointmentStatus.Active
                                &&
                                x.AppointmentDate == appointmentDate.Date
                                && x.AppointmentHour == hourItem).Data.Count();
                        if (appointmentCount == 0) // dr'un randevusu müsait
                        {
                            AppointmentViewModel m = new AppointmentViewModel()
                            {
                                AppointmentDate = appointmentDate,
                                AppointmentHour = hourItem,
                                AppointmentStatus = AppointmentStatus.Active,
                                HospitalClinicId = item.Id,
                                Doctor = item.Doctor,
                                Hospital = item.Hospital,
                                Clinic = item.Clinic
                            };
                            returnList.Add(m);
                            break;
                        }
                    }
                }

                return View(returnList);
            }
            catch (Exception ex)
            {
                ViewBag.FindAppoinmentErrorMessage = "Beklenmedik bir hata oluştu! ";
                return View();
            }
        }

        [Authorize]
        public IActionResult FindAppointmentHours(int hcid)
        {
            try
            {
                var data = new List<AvailableDoctorAppointmentViewModel>();

                var hospitalClinicData = _hospitalClinicManager
                    .GetAll(x => x.Id == hcid).Data.FirstOrDefault();

                var appointmentHoursData = _appointmentHourManager.
                    GetAll(x => x.HospitalClinicId == hcid).Data.FirstOrDefault();

                // tarih
                var appointmentDate = DateTime.Now.AddDays(1);
                // Eğer haftasonuna denk geliyorsa tarihi pztye çekmelisin!
                DayOfWeek day = appointmentDate.DayOfWeek;
                if (day == DayOfWeek.Saturday)
                {
                    appointmentDate = appointmentDate.AddDays(2);
                }
                else if (day == DayOfWeek.Sunday)
                {
                    appointmentDate = appointmentDate.AddDays(1);
                }
                ViewBag.AppointmentDate = appointmentDate.ToShortDateString();
                ViewBag.Doctor = $"Dr. {hospitalClinicData.Doctor.Name} {hospitalClinicData.Doctor.Surname}";

                // randevular
                var appointments = _appointmentManager.GetAll(
                    x => x.HospitalClinicId == hcid
                    &&
                    x.AppointmentStatus == AppointmentStatus.Active
                    &&
                    (x.AppointmentDate > DateTime.Now.AddDays(-1))
                    &&
                    (x.AppointmentDate < appointmentDate.AddDays(1))).Data;

                foreach (var hourItem in appointmentHoursData.Hours.Split(','))
                {
                    string myHourBase =
                        hourItem.Substring(0, 2) + ":00"; // 09:00 10:00 11:00

                    var dataAppointment = new AvailableDoctorAppointmentViewModel()
                    {
                        AppointmentDate = appointmentDate,
                        Doctor = hospitalClinicData.Doctor,
                        HospitalClinicId = hcid,
                        HourBase = myHourBase
                    };
                    if (data.Count(x => x.HourBase == myHourBase) == 0)
                    {
                        data.Add(dataAppointment);
                    }
                    if (appointments.Count(x =>
                    x.AppointmentDate == Convert.ToDateTime(
                        appointmentDate.ToShortDateString())
                    &&
                    x.AppointmentHour == hourItem) == 0) //Dr Meryem'in yarın saat 09:30'a randevusu yok mu? 
                    {
                        // eğer yoksa listeme ekleyeceğim
                        if (data.Count(x => x.HourBase == myHourBase) > 0)
                        {
                            data.Find(x => x.HourBase == myHourBase).Hours
                                .Add(hourItem);
                        }

                    }
                }
                return View(data);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Beklenmedik bir hata oluştu!");
                return View();
            }
        }

        [Authorize]
        public IActionResult SaveAppointment(int hcid, string date,string hour)
        {
            try
            {
                //bu kişinin aynı saate aynı tarihe baika bir randevusu var mı?
                var user = _userManager.FindByNameAsync(HttpContext.User.Identity.Name).Result;
                var controlDate = Convert.ToDateTime(date);
                var appointments = _appointmentManager.GetAll(x =>
                 x.AppointmentStatus == AppointmentStatus.Active
                 && x.HospitalClinicId == hcid
                 &&
                 x.AppointmentDate == controlDate
                 && x.AppointmentHour == hour
                 && x.PatientId == user.IdentificationNumber
               ).Data;
                if (appointments.Count>0)
                {
                    //başka bir yere randevusu var
                    return Json(new { isSuccess = false, message = $"{date}i{hour} tarihinde başka bir randevunuz bulunmaktadır! LAynı tarih ve saatte birden fazla randevu alamazsınız" });
                }
                //randevu kayıt edilsin
                AppointmentViewModel model = new AppointmentViewModel()
                {
                    AppointmentDate = controlDate,
                    AppointmentHour = hour,
                    HospitalClinicId = hcid,
                    PatientId = user.Id,
                    CreatedDate = DateTime.Now,
                    AppointmentStatus = AppointmentStatus.Active
                };
                var result = _appointmentManager.Add(model);
                return Json(new { isSuccesss = true, message = result.Message });
            }
            catch (Exception ex)
            {
                return Json(new { isSuccesss = false, message = ex.Message });
            }
        }
    }
}
