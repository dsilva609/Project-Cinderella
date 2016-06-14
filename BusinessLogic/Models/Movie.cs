using BusinessLogic.Enums;

namespace BusinessLogic.Models
{
	public class Movie : BaseItem
	{
		public string Director { get; set; }
		public MovieMediaTypeEnum Type { get; set; }
		public string Distributor { get; set; }
		public MovieRatingEnum Rating { get; set; }
	}
}