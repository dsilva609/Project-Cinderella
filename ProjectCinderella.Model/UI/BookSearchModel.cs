using System.Collections.Generic;
using ProjectCinderella.Model.ComicVineModels;
using ProjectCinderella.Model.Common;

namespace ProjectCinderella.Model.UI
{
	public class BookSearchModel
	{
		public string Title { get; set; }

		public string Author { get; set; }

		public List<Book> Volumes { get; set; }

		public ComicVineResult ComicsVineResult { get; set; }
	}
}