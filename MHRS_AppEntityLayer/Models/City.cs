using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationEntityLayer.Models
{
    [Index(nameof(PlateCode), IsUnique = true)]
    [Table("Cities")]
    public class City : Base<byte>//iller tablosunun Pk'sı byte tipinde olsun.ÇÜNKÜ TÜRKİYEDE  81 il var
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "İL ADI EN AZ 3 KARAKTER EN ÇOK 50 KARAKTER OLMALI")]
        public string CityName { get; set; }
        [Required]
        public byte PlateCode { get; set; }
        //ilişkinin karşılığı
        //1 ilin 1den çok ilişkisi olabilir
        public virtual ICollection<District> Districts { get; set; }
    }
}
