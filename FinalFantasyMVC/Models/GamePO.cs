using System;
using System.ComponentModel.DataAnnotations;

namespace FinalFantasyMVC.Models
{
    public class GamePO
    {
        public Int64 GameID { get; set; }
        [Required]
        [StringLength(30, ErrorMessage ="Too big, please abbreviate")]
        [Display(Name ="Game Title")]
        public string GameTitle { get; set; }
        [Required]
        [Display(Name ="Roman Numeral")]
        [RegularExpression("[IVXLM]*", ErrorMessage ="Must be a Roman Numeral")]
        public string RomanNumeral { get; set; }
        [Required]
        [Display(Name ="Release Date(12-25-1999)")]
        [RegularExpression("[0-9][0-9][/-]+[0-9][0-9][/-]+[0-9][0-9][0-9][0-9]", ErrorMessage ="Must Be a full Date(12/25/1999")]
        public string ReleaseDate { get; set; }
        [Display(Name ="Copies Sold")]
        [RegularExpression("[0-9]*", ErrorMessage ="Must be a number")]
        public int CopiesSold { get; set; }
        [Required]
        [Display(Name ="Game Summary")]
        [StringLength(255, ErrorMessage ="Too long")]
        public string GameSummary { get; set; }
        [RegularExpression("^\\d{0,5}(\\.\\d{0,2})?$", ErrorMessage ="Example: 22.15")]
        public decimal Price { get; set; }
    }
}