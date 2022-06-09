using MHRS_ApplicationEntityLayer.PagingListModels;
using MHRS_ApplicationEntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MHRS_ApplicationUI.Models
{
    public class PastandFutureAppointmentViewModel
    { //paginatedlist sayfalama yapmak için
        public PaginatedList<AppointmentViewModel>PastAppointments
        {
            get;set;
        }
        public PaginatedList<AppointmentViewModel> FutureAppointments
        {
            get; set;
        }
    }
}
