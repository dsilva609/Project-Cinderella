using BusinessLogic.Models;
using PagedList;

namespace UI.Models
{
	public class GameViewModel : BaseViewModel
	{
		public IPagedList<Game> Games { get; set; }
	}
}