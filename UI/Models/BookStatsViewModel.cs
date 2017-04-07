using System.Collections.Generic;

namespace UI.Models
{
	public class BookStatsViewModel
	{
		public int NumNovel { get; set; }
		public int NumComic { get; set; }
		public int NumManga { get; set; }
		public int NumHardcover { get; set; }
		public int NumFirstEdition { get; set; }
		public int TotalPageCount { get; set; }
		public List<string> TopPublishers { get; set; }
		public List<string> TopCountriesOfOrigin { get; set; }
		public List<string> TopPurchaseCountries { get; set; }
		public List<string> MostCompleted { get; set; }
		public List<string> TopLocationsPurchased { get; set; }
		public List<int> TopReleaseYears { get; set; }
	}
}