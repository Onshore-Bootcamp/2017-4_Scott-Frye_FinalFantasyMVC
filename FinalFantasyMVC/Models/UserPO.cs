using System;
using System.ComponentModel.DataAnnotations;

namespace FinalFantasyMVC.Models
{
    public class UserPO
    {
        public Int64 UserID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage ="Too long")]
        [Display(Name ="Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name ="Username")]
        [RegularExpression("^([0-9]+[a-zA-Z]+|[a-zA-Z]+[0-9]+)[0-9a-zA-Z]*$", ErrorMessage = "Must have atleast one number and letter")]
        [StringLength(15, ErrorMessage ="Must have 8 to 15 letters and numbers", MinimumLength = 8)]
        public string UserName { get; set; }

        [Required]
        [Display(Name ="Password")]
        [RegularExpression("^([0-9]+[a-zA-Z]+|[a-zA-Z]+[0-9]+)[0-9a-zA-Z]*$", ErrorMessage ="Must have atleast one number and letter")]
        [StringLength(15, ErrorMessage ="Must have 8 to 15 letters and numbers", MinimumLength =8)]
        public string UserPassword { get; set; }

        public Int64 RoleID { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}