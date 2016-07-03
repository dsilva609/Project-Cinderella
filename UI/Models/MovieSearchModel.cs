using BusinessLogic.Models.TMDBModels;
using System.Collections.Generic;

namespace UI.Models
{
	public class MovieSearchModel
	{
		public string Title { get; set; }
		public List<TMDBMovie> Results { get; set; }
	}
}