using MHRS_ApplicationEntityLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationEntityLayer.ViewModels
{
    public class AppointmentHourViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        public string Hours { get; set; }
        [Required]
        public int HospitalClinicId { get; set; }
        public HospitalClinicViewModel HospitalClinic { get; set; }
        public bool AppointmentStatus { get; set; }
        //viewmodel virtual olmaz, virtual ilişki kurarken yazılır burada datanın kendisi olmalı
    }
}
