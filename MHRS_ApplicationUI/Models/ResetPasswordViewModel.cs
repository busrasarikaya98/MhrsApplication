using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MHRS_ApplicationUI.Models
{
    public class ResetPasswordViewModel
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Yeni şifre alanı gereklidir!")]
        [Display(Name ="Yeni Şifre")]
        [StringLength(20,MinimumLength =4,ErrorMessage ="Şifreniz en az 4 en fazla 20 karakter olmalıdır!")]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Yeni şifre alanı tekrar gereklidir!")]
        [Display(Name = "Yeni Şifre Tekrarı")]
        [Compare(nameof(NewPassword),ErrorMessage ="Şifreler Uyuşmuyor!")]
        public string ConfirmNewPassword { get; set; }
    }
}
