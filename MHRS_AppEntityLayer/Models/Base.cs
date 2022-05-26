using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationEntityLayer.Models
{
    public class Base<T>
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//İDENTİTY BİR BİR ARTSIN
        public T Id { get; set; }

        [DataType(DataType.DateTime)]//bunun dakika ve saniyede tutmasını istiyorum sadece tarih isteseydik.Date derdik .Datetime yerine
        [Column(Order = 2)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;


    }
}
