using MHRS_ApplicationEntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MHRS_ApplicationUI.Models
{
    public class RegisterViewModel
    {
        [StringLength(50, MinimumLength = 2, ErrorMessage = "TC Kimlik Numarası 11 karakter olmalıdır!")]
        [Required(ErrorMessage = "TC Kimlik Numarası gereklidir!")]
        [Display(Name="Tc Kimlik Numarası")]

        public string IdentificationNumber { get; set; }
        [StringLength(50, MinimumLength = 2, ErrorMessage = "İsim en az 2 en çok 50 karakter olmalıdır!")]
        [Required(ErrorMessage = "İsim alanı gereklidir!")]
        [Display(Name = "İsminiz")]

        public string Name { get; set; }
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Soyisim en az 2 en çok 50 karakter olmalıdır!")]
        [Required(ErrorMessage = "Soyisim alanı gereklidir!")]
        [Display(Name = "Soyisiminiz")]

        public string Surname { get; set; }
        [Required(ErrorMessage = "Email alanı gereklidir!")]
        [Display(Name = "Email Adresiniz")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Parola alanı gereklidir!")]
        [Display(Name = "Parolanız")]
        [DataType(DataType.Password)] //yıldız şeklinde görünüm

        public string Password { get; set; }
        [Display(Name = "Doğum Tarihiniz")]

        public DateTime? BirthDate { get; set; }
        [Required(ErrorMessage = "Cinsiyet alanı gereklidir!")]
        [Display(Name = "Cinsiyetiniz")]
        public Genders Gender { get; set; }
    }
}
