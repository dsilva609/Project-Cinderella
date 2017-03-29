using BusinessLogic.Models;
using System.Collections.Generic;

namespace UI.Models
{
	public class ShowcaseViewModel : BaseViewModel
	{
		public List<Album> Albums { get; set; }

		public List<Book> Books { get; set; }

		public List<Game> Games { get; set; }
		public List<Movie> Movies { get; set; }

		public List<FunkoModel> Pops { get; set; }
	}
}