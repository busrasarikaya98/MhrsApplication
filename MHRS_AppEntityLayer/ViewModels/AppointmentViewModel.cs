using MHRS_ApplicationEntityLayer.Enums;
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
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        public string PatientId { get; set; } //betül
        [Required]
        public int HospitalClinicId { get; set; } //100--> 
        [Required]
        public DateTime AppointmentDate { get; set; } //27 mayıs
        [Required]
        public string AppointmentHour { get; set; } //10:00
        [Required]
        public AppointmentStatus AppointmentStatus { get; set; } //Aktif
        public AppUser Patient { get; set; }
        public HospitalClinicViewModel HospitalClinic { get; set; }
        public HospitalViewModel Hospital { get; set; }
        public ClinicViewModel Clinic { get; set; }
        public AppUser Doctor { get; set; }
    }
}
