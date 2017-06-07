using System;
using System.Collections.Generic;

namespace ProjectCinderella.Model.UI
{
	public class MovieStatsModel
	{
		public MovieTypesModel Types { get; set; }
		public MovieRatingModel Ratings { get; set; }

		public List<Tuple<string, int>> TopDirectors { get; set; }

		public List<Tuple<string, int>> TopCountriesOfOrigin { get; set; }
		public List<Tuple<string, int>> TopPurchaseCountries { get; set; }
		public List<Tuple<string, int>> MostCompleted { get; set; }
		public List<Tuple<string, int>> TopLocationsPurchased { get; set; }
		public List<Tuple<int, int>> TopReleaseYears { get; set; }
	}

	public class MovieTypesModel : ChartData
	{
		public int NumDVD { get; set; }

		public int NumBluRay { get; set; }
	}

	public class MovieRatingModel : ChartData
	{
		public int NumRatedG { get; set; }

		public int NumRatedPG { get; set; }

		public int NumRatedPG13 { get; set; }

		public int NumRatedR { get; set; }

		public int NumRatedNR { get; set; }
	}
}