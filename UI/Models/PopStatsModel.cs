using System.Collections.Generic;

namespace UI.Models
{
	public class PopStatsModel : ChartData
	{
		public List<string> TopSeries { get; set; }

		public List<string> TopLines { get; set; }

		public List<string> TopCountriesOfOrigin { get; set; }

		public List<string> TopPurchaseCountries { get; set; }

		public List<string> TopLocationsPurchased { get; set; }

		public List<int> TopReleaseYears { get; set; }
	}
}