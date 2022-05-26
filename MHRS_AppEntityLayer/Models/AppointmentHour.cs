using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationEntityLayer.Models
{
    [Table("AppointmentHours")]
    public class AppointmentHour : Base<int>
    {
        public int HospitalClinicId { get; set; } //hastane klinik doktor geliyor

        [Required]
        public string Hours { get; set; } //09:00,09:15,10:00 randevular diyelim, virgül ile saat dilimleri olacak. mavi buton şeklinde dizeceğiz

        [ForeignKey("HospitalClinicId")]
        public virtual HospitalClinic HospitalClinic { get; set; }
    }
}
