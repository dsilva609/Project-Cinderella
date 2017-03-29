using BusinessLogic.Models;
using PagedList;

namespace UI.Models
{
	public class PopViewModel : BaseViewModel
	{
		public IPagedList<FunkoModel> Pops { get; set; }
	}
}