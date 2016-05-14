using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
	public class BaseItem
	{
		public int ID { get; set; }
		public string UserID { get; set; }
		public string Title { get; set; }
		public string Genre { get; set; }

		[Display(Name = "New?")]
		public bool IsNew { get; set; }

		public int YearReleased { get; set; } = DateTime.Today.Year;

		[DisplayName("Location Purchased")]
		public string LocationPurchased { get; set; }

		[Display(Name = "Date Purchased")]
		[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime DatePurchased { get; set; } = DateTime.Today;

		public string Notes { get; set; }

		public DateTime DateAdded { get; set; }
		public DateTime DateUpdated { get; set; } = Convert.ToDateTime("1/1/1900");
	}
}