using System.ComponentModel.DataAnnotations;

namespace FinalFantasyMVC.Models
{
    public class LoginPO
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }
    }
}