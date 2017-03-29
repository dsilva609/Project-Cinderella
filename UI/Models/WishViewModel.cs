using BusinessLogic.Models;
using System.Collections.Generic;

namespace UI.Models
{
	public class WishViewModel : BaseViewModel
	{
		public Dictionary<string, List<Wish>> AlbumWishes { get; set; }
		public Dictionary<string, List<Wish>> BookWishes { get; set; }
		public Dictionary<string, List<Wish>> MovieWishes { get; set; }
		public Dictionary<string, List<Wish>> GameWishes { get; set; }
		public Dictionary<string, List<Wish>> PopWishes { get; set; }
	}
}