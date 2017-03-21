using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
	public class ItemInfoViewModel
	{
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

		public string Category { get; set; }
	}

	public class MediaInfoViewModel
	{
		[Required]
		[DisplayName("Physical?")]
		public bool IsPhysical { get; set; }

		[DisplayName("Country Of Origin")]
		public string CountryOfOrigin { get; set; }
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

		[DisplayName("Date Started")]
		public DateTime DateStarted { get; set; } = Convert.ToDateTime("1/1/1900");

		[DisplayName("Date Completed")]
		public DateTime DateCompleted { get; set; } = Convert.ToDateTime("1/1/1900");

		[DisplayName("Completion Status")]
		public BusinessLogic.Enums.CompletionStatus CompletionStatus { get; set; }

		[DisplayName("Checked Out?")]
		public bool CheckedOut { get; set; }

		[DisplayName("Times Completed")]
		public int TimesCompleted { get; set; }

		public bool IsShowcased { get; set; }
	}
}