using BusinessLogic.Models;
using PagedList;

namespace UI.Models
{
    public class AlbumViewModel : BaseViewModel
    {
        public IPagedList<Album> Albums { get; set; }
    }
}