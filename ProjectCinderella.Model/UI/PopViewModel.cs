using PagedList;
using ProjectCinderella.Model.Common;

namespace ProjectCinderella.Model.UI
{
	public class PopViewModel : BaseViewModel
	{
		public IPagedList<FunkoModel> Pops { get; set; }
	}
}