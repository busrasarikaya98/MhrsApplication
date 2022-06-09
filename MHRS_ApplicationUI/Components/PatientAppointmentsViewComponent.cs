using MHRS_ApplicationBusinessLayer.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MHRS_ApplicationUI.Models;
using Microsoft.AspNetCore.Identity;
using MHRS_ApplicationEntityLayer.IdentityModels;
using MHRS_ApplicationEntityLayer.PagingListModels;
using MHRS_ApplicationEntityLayer.ViewModels;

namespace MHRS_ApplicationUI.Components
{
    public class PatientAppointmentsViewComponent:ViewComponent
    {
        private readonly IAppointmentService _appointmentManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHospitalService _hospitalManager;
        private readonly IClinicService _clinicManager;

        public PatientAppointmentsViewComponent(IAppointmentService appointmentManager, UserManager<AppUser> userManager, IHospitalService hospitalManager, IClinicService clinicManager)
        {
            _appointmentManager = appointmentManager;
            _userManager = userManager;
            _hospitalManager = hospitalManager;
            _clinicManager = clinicManager;
        }

        public IViewComponentResult Invoke(int pageNumberPast=1,int pageNumberFuture=1)
        {
          
            PastandFutureAppointmentViewModel data = new PastandFutureAppointmentViewModel();
            var user = _userManager.FindByNameAsync(HttpContext.User.Identity.Name).Result;
            //aktif randevuları alalım
            var activeAppointments = _appointmentManager.GetUpComingAppoinments(user.Id).Data.ToList();

            data.FutureAppointments = PaginatedList<AppointmentViewModel>.Create(activeAppointments, pageNumberFuture, 4);

            //geçmiş ve iptal randevular
            var pastAndCancelledAppointments = _appointmentManager.GetPastandCancelledAppointments(user.Id).Data.ToList();
            data.PastAppointments = PaginatedList<AppointmentViewModel>.Create(pastAndCancelledAppointments, pageNumberPast, 4);
            return View(data);
        }
    }
}
