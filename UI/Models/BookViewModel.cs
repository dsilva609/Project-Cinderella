using BusinessLogic.Models;
using PagedList;

namespace UI.Models
{
	public class BookViewModel : BaseViewModel
	{
		public IPagedList<Book> Books { get; set; }
	}
}