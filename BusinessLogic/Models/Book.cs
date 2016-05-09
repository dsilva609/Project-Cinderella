using BusinessLogic.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
	public class Book
	{
		public int ID { get; set; }

		[Required]
		public string UserID { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		public string Author { get; set; }

		[Required]
		public BookTypeEnum Type { get; set; }

		[Required]
		public BookMediaTypeEnum Media { get; set; }

		public bool Hardcover { get; set; }

		[Required]
		public string Publisher { get; set; }

		[Required]
		[Display(Name = "Year Published")]
		public int YearPublished { get; set; } = DateTime.Today.Year;

		[Display(Name = "Date Purchased")]
		public DateTime DatePurchased { get; set; } = DateTime.Today;

		[Display(Name = "Location Purchased")]
		public string LocationPurchased { get; set; }

		[Display(Name = "New?")]
		public bool IsNew { get; set; }

		public string ISBN { get; set; }

		[Display(Name = "Reissue?")]
		public bool IsReissue { get; set; }

		//TODO: make enum or some auto generated value
		public string Language { get; set; }

		public string Notes { get; set; }

		public DateTime DateAdded { get; set; }
		public DateTime DateUpdated { get; set; } = Convert.ToDateTime("1/1/1900");
	}
}