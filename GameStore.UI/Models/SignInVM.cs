using System.ComponentModel.DataAnnotations;

namespace GameStore.UI.Models
{
    public class SignInVM
    {
        [Required]
        [Display(Name = "Mail")]   
        public string Email { get; set; }
       
        [Required]
        [Display(Name = "Sifre")]
        public string Password { get; set; }
  
    }
}
