using BusinessLogic.Models;
using System.Collections.Generic;

namespace UI.Models
{
	public class MovieViewModel
	{
		public string ViewTitle { get; set; }
		public List<Movie> Movies { get; set; }
		public int PageSize { get; set; }
		public int PageCount { get; set; }
		public int TotalMovies { get; set; }
	}
}