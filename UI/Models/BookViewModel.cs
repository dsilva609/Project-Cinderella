using BusinessLogic.Models;
using System.Collections.Generic;

namespace UI.Models
{
	public class BookViewModel : BaseViewModel
	{
		public List<Book> Books { get; set; }
	}
}