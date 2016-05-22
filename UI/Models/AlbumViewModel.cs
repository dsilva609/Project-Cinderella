using BusinessLogic.Models;
using System.Collections.Generic;

namespace UI.Models
{
	public class AlbumViewModel
	{
		public string ViewTitle { get; set; }
		public List<Album> Albums { get; set; }
		public int PageSize { get; set; }
		public int PageCount { get; set; }
		public int TotalRecords { get; set; }
	}
}