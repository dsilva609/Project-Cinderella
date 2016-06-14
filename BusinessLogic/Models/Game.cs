using BusinessLogic.Enums;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
	public class Game : BaseItem
	{
		public string Developer { get; set; }

		[Required]
		public string Publisher { get; set; }

		[Required]
		public GameTypeEnum Type { get; set; }

		public GameRatingEnum Rating { get; set; }

		[Required]
		public GameMediaTypeEnum MediaType { get; set; }

		public GamePlatformEnum Platform { get; set; }
		public bool IsDLC { get; set; }
		public bool PartOfSeries { get; set; }
		public string Series { get; set; }
		public string Country { get; set; }
	}
}