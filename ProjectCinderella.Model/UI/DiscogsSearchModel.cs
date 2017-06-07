using System.Collections.Generic;
using System.ComponentModel;
using ProjectCinderella.Model.DiscogsModels;

namespace ProjectCinderella.Model.UI
{
	public class DiscogsSearchModel
	{
		public string Artist { get; set; }

		[DisplayName("Album Name")]
		public string AlbumName { get; set; }

		public List<DiscogsResult> Results { get; set; }
	}
}