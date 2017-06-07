using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PagedList;
using ProjectCinderella.Model.Common;
using ProjectCinderella.Model.Enums;

namespace ProjectCinderella.Model.UI
{
	public class GameViewModel : BaseViewModel
	{
		public IPagedList<Game> Games { get; set; }
		public GameInfoModel GameInfo { get; set; }
		public GameMediaInfoModel MediaInfo { get; set; }
		public PurchaseInfoViewModel PurchaseInfo { get; set; }
		public ItemStatusViewModel StatusInfo { get; set; }
	}

	public class GameInfoModel : ItemInfoViewModel
	{
		[Required]
		public string Developer { get; set; }

		[Required]
		public string Publisher { get; set; }

		public int GiantBombID { get; set; }
		public int BGGID { get; set; }
	}

	public class GameMediaInfoModel : MediaInfoViewModel
	{
		[Required]
		public GameTypeEnum Type { get; set; }

		public GameRatingEnum Rating { get; set; }

		public GamePlatformEnum Platform { get; set; }

		[DisplayName("Is DLC?")]
		public bool IsDLC { get; set; }

		[DisplayName("Part of Series")]
		public bool PartOfSeries { get; set; }

		public string Series { get; set; }
	}
}