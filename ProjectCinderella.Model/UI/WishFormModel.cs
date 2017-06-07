using System.Collections.Generic;
using ProjectCinderella.Model.Common;

namespace ProjectCinderella.Model.UI
{
	public class WishFormModel
	{
		public Wish Wish { get; set; }
		//TODO:needs to be select list for combo box select
		//public SelectList Categories { get; set; }
		public List<string> Categories { get; set; }
	}
}