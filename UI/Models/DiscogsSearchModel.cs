using BusinessLogic.Models.DiscogsModels;
using System.Collections.Generic;

namespace UI.Models
{
	public class DiscogsSearchModel
	{
		public string Artist { get; set; }

		public string AlbumName { get; set; }

		public List<DiscogsResult> Results { get; set; }
	}
}