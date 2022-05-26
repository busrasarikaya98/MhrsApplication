using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationEntityLayer.Models
{
    [Table("Clinics")] //datadaki tablo code first
    public class Clinic : Base<int>
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Klinik adı en az 2 en çok 100 karakter olabilir!")]
        public string ClinicName { get; set; }
        public virtual ICollection<HospitalClinic> HospitalClinics { get; set; }

    }
    
}
