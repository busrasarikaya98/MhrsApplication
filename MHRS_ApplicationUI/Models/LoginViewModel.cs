using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MHRS_ApplicationUI.Models
{
    public class LoginViewModel
    {
        [StringLength(50, MinimumLength = 2, ErrorMessage = "TC Kimlik Numarası 11 karakter olmalıdır!")]
        [Required(ErrorMessage = "TC Kimlik Numarası gereklidir!")]
        [Display(Name = "Tc Kimlik Numarası")]
        public string IdentificationNumber { get; set; }

        [Required(ErrorMessage = "Parola alanı gereklidir!")]
        [Display(Name = "Parolanız")]
        [DataType(DataType.Password)] //yıldız şeklinde görünüm
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
