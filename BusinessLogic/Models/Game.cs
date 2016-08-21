using BusinessLogic.Enums;
using System.ComponentModel;
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
		[DisplayName("Media Type")]
		public GameMediaTypeEnum MediaType { get; set; }

		public GamePlatformEnum Platform { get; set; }

		[DisplayName("Is DLC?")]
		public bool IsDLC { get; set; }

		[DisplayName("Part of Series")]
		public bool PartOfSeries { get; set; }

		public string Series { get; set; }
		public string Country { get; set; }
	}
}