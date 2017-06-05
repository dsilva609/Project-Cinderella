using System.ComponentModel.DataAnnotations;
using ProjectCinderella.Model.Enums;

namespace ProjectCinderella.Model.Common
{
	public class Movie : BaseItem
	{
		[Required]
		public string Director { get; set; }

		public MovieMediaTypeEnum Type { get; set; }
		public string Distributor { get; set; }
		public MovieRatingEnum Rating { get; set; }
		public int TMDBID { get; set; }
		public int SeasonNumber { get; set; }
	}
}