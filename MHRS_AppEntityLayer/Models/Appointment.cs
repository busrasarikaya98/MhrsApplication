using MHRS_ApplicationEntityLayer.Enums;
using MHRS_ApplicationEntityLayer.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationEntityLayer.Models
{
    [Table("Appointments")]
    public class Appointment : Base<int>
    {
 
        public string PatientId { get; set; } //busra

        public int HospitalClinicId { get; set; } //100 hastane doktor klinik

        [Required]
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Randevu saati XX:XX şeklinde olmalıdır!")]
        public string AppointmentHour { get; set; } //10:00

        public AppointmentStatus AppointmentStatus { get; set; }

        [ForeignKey("PatientId")]
        public virtual AppUser Patient { get; set; }
        [ForeignKey("HospitalClinicId")]
        public virtual HospitalClinic HospitalClinic { get; set; }
    }
}
