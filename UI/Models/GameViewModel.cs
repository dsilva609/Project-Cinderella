using BusinessLogic.Models;
using System.Collections.Generic;

namespace UI.Models
{
	public class GameViewModel
	{
		public string ViewTitle { get; set; }
		public List<Game> Games { get; set; }
		public int PageSize { get; set; }
		public int PageCount { get; set; }
		public int TotalGames { get; set; }
	}
}