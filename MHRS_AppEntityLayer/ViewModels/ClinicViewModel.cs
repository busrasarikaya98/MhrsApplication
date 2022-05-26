using MHRS_ApplicationEntityLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationEntityLayer.ViewModels
{
    public class ClinicViewModel
    {
        public byte Id { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Klinik adı en az 2 en çok 100 karakter olabilir!")]
        public string ClinicName { get; set; }
        public ICollection<HospitalClinicViewModel> HospitalClinics { get; set; }
    }
}
