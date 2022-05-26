using MHRS_ApplicationEntityLayer.Enums;
using MHRS_ApplicationEntityLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationEntityLayer.IdentityModels
{
    [Index(nameof(IdentificationNumber),IsUnique =true)]
    public class AppUser:IdentityUser
    {
        [StringLength(50,MinimumLength =2, ErrorMessage ="İsim en az 2 en çok 50 karakter olmalıdır!")]
        [Required(ErrorMessage ="İsim alanı gereklidir!")]
        public string Name { get; set; }
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Soyisim en az 2 en çok 50 karakter olmalıdır!")]
        [Required(ErrorMessage = "Soyisim alanı gereklidir!")]
        public string Surname { get; set; }
        [StringLength(50, MinimumLength = 2, ErrorMessage = "TC Kimlik Numarası 11 karakter olmalıdır!")]
        [Required(ErrorMessage = "TC Kimlik Numarası gereklidir!")]
        public string IdentificationNumber { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        public string Picture { get; set; }
        public DateTime? BirthDate { get; set; }
        public Genders Gender { get; set; }
        public ICollection<HospitalClinic> HospitalClinics { get; set; }
    }
}
