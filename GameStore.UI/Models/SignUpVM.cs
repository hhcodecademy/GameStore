using System.ComponentModel.DataAnnotations;

namespace GameStore.UI.Models
{
    public class SignUpVM
    {
        [Display(Name ="Istifadeci adi")]
        [Required]
        public string UserName { get; set; }
        [Display(Name = "Mail")]
        [Required]
        public string Email { get; set; }
        [Display(Name = "Sifre")]
        [Required]
        public string Password { get; set; }
        [Display(Name = "Sifre tekrar")]
        [Required]
        [Compare(nameof(Password),ErrorMessage ="Eyni sifreni daxil ediniz")]
        public string ConfirmPassword { get; set; }
    }
}
