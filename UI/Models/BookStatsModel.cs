using System;
using System.Collections.Generic;

namespace UI.Models
{
	public class BookStatsModel
	{
		public BookTypesModel Types { get; set; }
		public int NumHardcover { get; set; }
		public int NumFirstEdition { get; set; }
		public int TotalPageCount { get; set; }
		public List<Tuple<string, int>> TopPublishers { get; set; }
		public List<Tuple<string, int>> TopCountriesOfOrigin { get; set; }
		public List<Tuple<string, int>> TopPurchaseCountries { get; set; }
		public List<Tuple<string, int>> MostCompleted { get; set; }
		public List<Tuple<string, int>> TopLocationsPurchased { get; set; }
		public List<Tuple<int, int>> TopReleaseYears { get; set; }
	}

	public class BookTypesModel : ChartData
	{
		public int NumNovel { get; set; }
		public int NumComic { get; set; }
		public int NumManga { get; set; }
	}
}