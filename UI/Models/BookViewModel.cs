using BusinessLogic.Models;
using System.Collections.Generic;

namespace UI.Models
{
	public class BookViewModel
	{
		public string ViewTitle { get; set; }
		public List<Book> Books { get; set; }
		public int PageSize { get; set; }
		public int PageCount { get; set; }
		public int TotalBooks { get; set; }
	}
}