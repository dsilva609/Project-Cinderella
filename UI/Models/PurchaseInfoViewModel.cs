using System;

namespace UI.Models
{
	public class PurchaseInfoViewModel
	{
		public DateTime DatePurchased { get; set; }
		public string LocationPurchased { get; set; }
		public bool IsNew { get; set; }
	}
}