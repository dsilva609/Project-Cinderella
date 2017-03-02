using BusinessLogic.Models;
using System.Collections.Generic;

namespace UI.Models
{
    public class WishViewModel : BaseViewModel
    {
        public List<Wish> AlbumWishes { get; set; }
        public List<Wish> BookWishes { get; set; }
        public List<Wish> MovieWishes { get; set; }
        public List<Wish> GameWishes { get; set; }
    }
}