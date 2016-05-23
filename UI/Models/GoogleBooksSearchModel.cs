using BusinessLogic.Models;
using System.Collections.Generic;

namespace UI.Models
{
	public class GoogleBooksSearchModel
	{
		public string Title { get; set; }

		public string Author { get; set; }

		public List<Book> Volumes { get; set; }
	}
}