using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Models.DiscogsModels;
using PagedList;

namespace UI.Models
{
	public class AlbumViewModel : BaseViewModel
	{
		public IPagedList<Album> Albums { get; set; }
		public List<Tracklist> Tracklist { get; set; } = new List<Tracklist>();

		public AlbumInfoModel AlbumInfo { get; set; }
		public AlbumMediaInfo MediaInfo { get; set; }
		public PurchaseInfoViewModel PurchaseInfo { get; set; }
		public ItemStatusViewModel ItemStatus { get; set; }
	}

	public class AlbumInfoModel : ItemInfoViewModel
	{
		[Required]
		public string Artist { get; set; }

		public string Style { get; set; }

		[DisplayName("Record Label")]
		public string RecordLabel { get; set; }

		public int DiscogsID { get; set; }
	}

	public class AlbumMediaInfo : MediaInfoViewModel
	{
		[Required]
		[DisplayName("Media Type")]
		public AlbumMediaTypeEnum MediaType { get; set; }

		public SpeedEnum Speed { get; set; }
		public SizeEnum Size { get; set; }
	}
}