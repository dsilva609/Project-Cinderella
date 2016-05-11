using BusinessLogic.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
	public class Movie
	{
		public int ID { get; set; }

		[Required]
		public string UserID { get; set; }

		[Required]
		public string Title { get; set; }

		public string Director { get; set; }
		public string Genre { get; set; }
		public MovieMediaTypeEnum Type { get; set; }
		public string Distributor { get; set; }

		[DisplayName("Is New?")]
		public bool IsNew { get; set; }

		public MovieRatingEnum Rating { get; set; }

		[DisplayName("Year Released")]
		public int YearReleased { get; set; } = DateTime.Today.Year;

		public string Language { get; set; }
		public string Notes { get; set; }

		[DisplayName("Date Purchased")]
		[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime DatePurchased { get; set; } = DateTime.Today;

		[DisplayName("Location Purchased")]
		public string LocationPurchased { get; set; }

		public DateTime DateAdded { get; set; }
		public DateTime DateUpdated { get; set; } = Convert.ToDateTime("1/1/1900");
	}
}