using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectCinderella.Model.Enums;

namespace ProjectCinderella.Model.Common
{
	public class Game : BaseItem
	{
		[Required]
		public string Developer { get; set; }

		[Required]
		public string Publisher { get; set; }

		[Required]
		public GameTypeEnum Type { get; set; }

		public GameRatingEnum Rating { get; set; }

		public GamePlatformEnum Platform { get; set; }

		[DisplayName("Is DLC?")]
		public bool IsDLC { get; set; }

		[DisplayName("Part of Series")]
		public bool PartOfSeries { get; set; }

		public string Series { get; set; }

		public int GiantBombID { get; set; }
		public int BGGID { get; set; }
	}
}