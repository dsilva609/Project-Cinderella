using BusinessLogic.Models;
using System.Collections.Generic;

namespace UI.Models
{
	public class MovieViewModel : BaseViewModel
	{
		public List<Movie> Movies { get; set; }
	}
}