using BusinessLogic.Models.DiscogsModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
	public class DiscogsSearchModel
	{
		[Required]
		public string Artist { get; set; }

		[Required]
		public string AlbumName { get; set; }

		public List<DiscogsResult> Results { get; set; }
	}
}