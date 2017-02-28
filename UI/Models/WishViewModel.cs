using BusinessLogic.Models;
using PagedList;

namespace UI.Models
{
	public class WishViewModel : BaseViewModel
	{
		public IPagedList<Wish> AlbumWishes { get; set; }
		public IPagedList<Wish> BookWishes { get; set; }
		public IPagedList<Wish> MovieWishes { get; set; }
		public IPagedList<Wish> GameWishes { get; set; }
	}
}