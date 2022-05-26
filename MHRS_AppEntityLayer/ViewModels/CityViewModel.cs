using MHRS_ApplicationEntityLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationEntityLayer.ViewModels
{
    public class CityViewModel
    {
        public byte Id { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "İl adı en az 3 en çok 50 karakter aralığında olmalıdır!")]
        public string CityName { get; set; }
        [Required]
        public byte PlateCode { get; set; }
        public ICollection<DistrictViewModel> Districts { get; set; }

    }
}
