﻿using BusinessLogic.Enums;
using BusinessLogic.Models.DiscogsModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Models
{
	public class Album : BaseItem
	{
		[Column(Order = 2)]
		[Required]
		public string Artist { get; set; }

		[Column(Order = 3)]
		[Required]
		[DisplayName("Media Type")]
		public AlbumMediaTypeEnum MediaType { get; set; }

		public string Style { get; set; }

		public SpeedEnum Speed { get; set; }
		public SizeEnum Size { get; set; }

		[DisplayName("Record Label")]
		public string RecordLabel { get; set; }

		public int DiscogsID { get; set; }

		public List<Tracklist> Tracklist { get; set; } = new List<Tracklist>();
	}
}