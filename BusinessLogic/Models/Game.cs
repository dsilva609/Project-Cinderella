using BusinessLogic.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
	public class Game
	{
		public int ID { get; set; }

		[Required]
		public string UserID { get; set; }

		[Required]
		public string Title { get; set; }

		public string Developer { get; set; }

		[Required]
		public string Publisher { get; set; }

		public string Genre { get; set; }

		[Required]
		public GameTypeEnum Type { get; set; }

		public GameRatingEnum Rating { get; set; }

		[Required]
		public GameMediaTypeEnum MediaType { get; set; }

		public GamePlatformEnum Platform { get; set; }

		public bool IsDLC { get; set; }
		public bool PartOfSeries { get; set; }

		public string Series { get; set; }

		public int YearReleased { get; set; } = DateTime.Today.Year;

		[Display(Name = "Date Purchased")]
		[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime DatePurchased { get; set; } = DateTime.Today;

		public string Country { get; set; }

		[Display(Name = "Location Purchased")]
		public string LocationPurchased { get; set; }

		[Display(Name = "New?")]
		public bool IsNew { get; set; }

		public string Language { get; set; }

		public string Notes { get; set; }

		public DateTime DateAdded { get; set; }
		public DateTime DateUpdated { get; set; } = Convert.ToDateTime("1/1/1900");
	}
}