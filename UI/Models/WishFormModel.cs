using BusinessLogic.Models;
using System.Web.Mvc;

namespace UI.Models
{
	public class WishFormModel
	{
		public Wish Wish { get; set; }

		//public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();

		public SelectList Categories { get; set; }
	}
}