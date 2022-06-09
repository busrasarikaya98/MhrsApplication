using MHRS_ApplicationEntityLayer.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MHRS_ApplicationUI.Models
{
    public class AvailableDoctorAppointmentViewModel
    {
        public AppUser Doctor { get; set; }
        public int HospitalClinicId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string HourBase { get; set; } // saat başları 10:00
        public List<string> Hours { get; set; } = new List<string>();
        // saat detay 10:05 10:30 vb
    }
}
