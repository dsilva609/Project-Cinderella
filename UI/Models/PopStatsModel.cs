using System;
using System.Collections.Generic;

namespace UI.Models
{
	public class PopStatsModel : ChartData
	{
		public List<Tuple<string, int>> TopSeries { get; set; }

		public List<Tuple<string, int>> TopLines { get; set; }

		public List<Tuple<string, int>> TopCountriesOfOrigin { get; set; }
		public List<Tuple<string, int>> TopPurchaseCountries { get; set; }
		public List<Tuple<string, int>> MostCompleted { get; set; }
		public List<Tuple<string, int>> TopLocationsPurchased { get; set; }
		public List<Tuple<int, int>> TopReleaseYears { get; set; }
	}
}