using BusinessLogic.Models;
using BusinessLogic.Models.ComicVineModels;
using System.Collections.Generic;

namespace UI.Models
{
	public class BookSearchModel
	{
		public string Title { get; set; }

		public string Author { get; set; }

		public List<Book> Volumes { get; set; }

		public ComicVineResult ComicsVineResult { get; set; }
	}
}