using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class ItemViewModel
    {
        public ItemInfoViewModel InfoView { get; set; }
        public MediaInfoViewModel MediaInfo { get; set; }
        public PurchaseInfoViewModel PurchaseInfo { get; set; }
        public ItemStatusViewModel ItemStatus { get; set; }
    }

    public class ItemInfoViewModel
    {
        [Required]
        public string Title { get; set; }

        public string Genre { get; set; }
        public string Language { get; set; }
        public string Notes { get; set; }

        [DisplayName("Image Url")]
        public string ImageUrl { get; set; }

        [DisplayName("Year Released")]
        public int YearReleased { get; set; } = DateTime.Today.Year;

        public string Category { get; set; }
    }

    public class MediaInfoViewModel
    {
    }

    public class PurchaseInfoViewModel
    {
        [Display(Name = "Date Purchased")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DatePurchased { get; set; } = DateTime.Today;

        [DisplayName("Location Purchased")]
        public string LocationPurchased { get; set; }

        [Display(Name = "Purchased New?")]
        public bool IsNew { get; set; }

        [DisplayName("Country Purchased")]
        public string CountryPurchased { get; set; }
    }

    public class ItemStatusViewModel
    {
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; } = Convert.ToDateTime("1/1/1900");

        [DisplayName("Completion Status")]
        public CompletionStatus CompletionStatus { get; set; }

        [DisplayName("Checked Out?")]
        public bool CheckedOut { get; set; }

        [DisplayName("Times Completed")]
        public int TimesCompleted { get; set; }

        public bool IsShowcased { get; set; }
    }
}