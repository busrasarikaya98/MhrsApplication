using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationEntityLayer.Models
{
    [Table("QuartzTimerDenemeler")]
    public class Deneme:Base<int>
    {
        [Required]
        [StringLength(400,ErrorMessage ="Maksimum 400 karakter!")]
        public string Mesaj { get; set; }
    }
}
