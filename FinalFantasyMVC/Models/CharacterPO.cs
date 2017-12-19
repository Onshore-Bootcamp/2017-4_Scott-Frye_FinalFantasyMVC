using System;
using System.ComponentModel.DataAnnotations;

namespace FinalFantasyMVC.Models
{
    public class CharacterPO
    {
        public Int64 CharacterID { get; set; }
        [Required]
        [StringLength(25, ErrorMessage ="Too long")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(25, ErrorMessage ="Too long")]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        public Int64 GameID { get; set; }
        public string Alignment { get; set; }
        [Required]
        [StringLength(25, ErrorMessage ="Too long")]
        [Display(Name ="Weapon Of Choice")]
        public string WeaponOfChoice { get; set; }
        [Required]
        [StringLength(255, ErrorMessage ="Too long")]
        public string Bio { get; set; }
        public string MaleOrFemale { get; set; }
    }
}