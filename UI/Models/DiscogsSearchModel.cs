﻿using BusinessLogic.Models.DiscogsModels;
using System.Collections.Generic;
using System.ComponentModel;

namespace UI.Models
{
	public class DiscogsSearchModel
	{
		public string Artist { get; set; }

		[DisplayName("Album Name")]
		public string AlbumName { get; set; }

		public List<DiscogsResult> Results { get; set; }
	}
}