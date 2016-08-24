using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
    public class BaseItem
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string UserID { get; set; }

        [Required]
        public string Title { get; set; }

        public string Genre { get; set; }
        public string Language { get; set; }
        public string Notes { get; set; }

        [DisplayName("Image Url")]
        public string ImageUrl { get; set; }

        [DisplayName("Year Released")]
        public int YearReleased { get; set; } = DateTime.Today.Year;

        [Required]
        [DisplayName("Physical?")]
        public bool IsPhysical { get; set; }

        [Display(Name = "Purchased New?")]
        public bool IsNew { get; set; }

        [DisplayName("Location Purchased")]
        public string LocationPurchased { get; set; }

        [Display(Name = "Date Purchased")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DatePurchased { get; set; } = DateTime.Today;

        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; } = Convert.ToDateTime("1/1/1900");
    }
}