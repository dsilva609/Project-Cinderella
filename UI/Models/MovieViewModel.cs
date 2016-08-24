using BusinessLogic.Models;
using PagedList;

namespace UI.Models
{
	public class MovieViewModel : BaseViewModel
	{
		public IPagedList<Movie> Movies { get; set; }
	}
}