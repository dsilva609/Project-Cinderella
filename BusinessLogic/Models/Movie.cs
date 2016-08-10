using BusinessLogic.Enums;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
	public class Movie : BaseItem
	{
		[Required]
		public string Director { get; set; }

		public MovieMediaTypeEnum Type { get; set; }
		public string Distributor { get; set; }
		public MovieRatingEnum Rating { get; set; }
		public int TMDBID { get; set; }
	}
}