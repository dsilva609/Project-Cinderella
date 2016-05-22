using BusinessLogic.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Models
{
	public class Album
	{
		public int ID { get; set; }

		[Required]
		public string UserID { get; set; }

		[Column(Order = 1)]
		[Required]
		[DisplayName("Album Name")]
		public string AlbumName { get; set; }

		[Column(Order = 2)]
		[Required]
		public string Artist { get; set; }

		public string Genre { get; set; }

		[DisplayName("Album Year")]
		public int AlbumYear { get; set; } = DateTime.Today.Year;

		[Column(Order = 3)]
		[Required]
		[DisplayName("Media Type")]
		public AlbumMediaTypeEnum MediaType { get; set; }

		[Required]
		[DisplayName("Physical?")]
		public bool IsPhysical { get; set; }

		[Required]
		[DisplayName("Purchased New?")]
		public bool IsNew { get; set; }

		[DisplayName("Location Purchased")]
		public string LocationPurchased { get; set; }

		[DisplayName("Date Purchased")]
		[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime DatePurchased { get; set; } = DateTime.Today;

		public DateTime DateAdded { get; set; }
		public DateTime DateUpdated { get; set; } = Convert.ToDateTime("1/1/1900");

		public string Notes { get; set; }

		[DisplayName("Record Label")]
		public string RecordLabel { get; set; }

		public int DiscogsID { get; set; }
	}
}