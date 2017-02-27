using BusinessLogic.Models;
using PagedList;

namespace UI.Models
{
    public class WishViewModel : BaseViewModel
    {
        public IPagedList<Wish> Wishes { get; set; }
    }
}