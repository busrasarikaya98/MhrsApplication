using MHRS_ApplicationBusinessLayer.Abstracts;
using MHRS_ApplicationEntityLayer.Enums;
using MHRS_ApplicationEntityLayer.IdentityModels;
using MHRS_ApplicationEntityLayer.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MHRS303UI.Controllers
{
    public class HospitalController : Controller
    {

        private readonly IHospitalClinicService _hospitalClinicManager;
        private readonly IAppointmentHourService _appointmentHourManager;
        private readonly IAppointmentService _appointmentManager;
        private readonly UserManager<AppUser> _userManager;

        public HospitalController(IHospitalClinicService hospitalClinicManager, IAppointmentHourService appointmentHourManager, IAppointmentService appointmentManager, UserManager<AppUser> userManager)
        {
            _hospitalClinicManager = hospitalClinicManager;
            _appointmentHourManager = appointmentHourManager;
            _appointmentManager = appointmentManager;
            _userManager = userManager;
        }

        public JsonResult GetHospitalsByClinicIdandDistrictId(int clinicId, int districtId)
        {
            try
            {
                //not: Buradaki kod bloğu bussinesstaki HospitalClinicManagerdan alınabilirdi
                //Fakat lakin ama çünkü :D Çok üşendiğim için get all ile hepsini çekip
                //linqladım.
                var data = new List<HospitalViewModel>();
                data = _hospitalClinicManager.GetAll
                     (
                     x => x.ClinicId == clinicId //filter
                     ).Data
                     .Select(y => y.Hospital)
                     .Where(x => x.DistrictId == districtId)
                     .Distinct().ToList();
                return Json(new { isSucces = true, data });

            }
            catch (Exception ex)
            {
                return Json(new { isSucces = false });
            }
        }

        public JsonResult GetDoctorsByHospitalClinicData(int clinicId, int hospitalId)
        {
            try
            {
                if (clinicId > 0 && hospitalId > 0)
                {
                    var data = new List<AppUser>(); // doktoru burada tutacağız

                    var hospitalClinicData = _hospitalClinicManager.GetAll(x =>
                   x.ClinicId == clinicId
                   && x.HospitalId == hospitalId).Data.Distinct().ToList();

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

                    //hospitalclinic datasından gelen verileri tek tek dön -foreach
                    foreach (var item in hospitalClinicData)
                    {
                        // acaba bu doktorın çalışma saatleri nedir?
                        var drAppointmentHoursList = _appointmentHourManager.GetAll(
                            x => x.HospitalClinicId == item.Id).Data.FirstOrDefault();

                        // dr'nin çalışma saatleri
                        foreach (var hourItem in drAppointmentHoursList.Hours.Split(','))
                        {
                            //o hastanede o klinikte o doktorun yarın o saatte randevusu var mı?
                            var appointmentCount = _appointmentManager.GetAll
                                (x => x.HospitalClinicId == item.Id
                                &&
                                x.AppointmentStatus == AppointmentStatus.Active
                                &&
                                x.AppointmentDate == appointmentDate.Date
                                && x.AppointmentHour == hourItem).Data.Count();
                            if (appointmentCount == 0) // dr'un randevusu müsait
                            {
                                AppUser dr = _userManager.FindByIdAsync(item.DoctorId).Result;
                                data.Add(dr);
                                break;
                            }
                        } // foreach bitti

                    } // foreach bitti

                    data = data.ToList();
                    return Json(new { isSucces = true, data });

                }
                else
                {
                    return Json(new { isSucces = false });
                }
            }
            catch (Exception)
            {

                return Json(new { isSucces = false });
            }
        }
    }
}