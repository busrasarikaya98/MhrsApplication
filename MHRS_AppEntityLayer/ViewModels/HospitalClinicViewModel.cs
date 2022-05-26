using MHRS_ApplicationEntityLayer.IdentityModels;
using MHRS_ApplicationEntityLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationEntityLayer.ViewModels
{
    public class HospitalClinicViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        public int HospitalId { get; set; }
        public HospitalViewModel Hospital { get; set; }
        [Required]
        public int ClinicId { get; set; }
        public ClinicViewModel Clinic { get; set; }
        [Required]
        public string DoctorId { get; set; }
        public AppUser Doctor { get; set; }
        public ICollection<AppointmentViewModel> Appointments { get; set; }
        public ICollection<AppointmentHourViewModel> AppointmentHours { get; set; }
    }
}
