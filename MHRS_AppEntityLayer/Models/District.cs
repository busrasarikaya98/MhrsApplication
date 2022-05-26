﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationEntityLayer.Models
{
    [Table("District")]
    public class District : Base<int>
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "İlçe adı en az 2 en çok 50 karakter olmalıdır!")]
        public string DistrictName { get; set; }
        public byte CityId { get; set; }
        //ilişki
        //code first 
        [ForeignKey("CityId")]
       public virtual City City { get; set; }
        public virtual ICollection<Hospital> Hospitals { get; set; }
        //hospitalın içinde datası var,virtual icollection data döndürecek ancak view modeli virtual olmayacak
    }
}
