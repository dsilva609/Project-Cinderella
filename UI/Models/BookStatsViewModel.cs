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

        public int NumNovelUser { get; set; }
        public int NumComicUser { get; set; }
        public int NumMangaUser { get; set; }
        public int NumHardcoverUser { get; set; }
        public int NumFirstEditionUser { get; set; }
        public int TotalPageCountUser { get; set; }
        public List<string> TopPublishersUser { get; set; }
        public List<string> TopCountriesOfOriginUser { get; set; }
        public List<string> TopPurchaseCountriesUser { get; set; }
        public List<string> MostCompletedUser { get; set; }
        public List<string> TopLocationsPurchasedUser { get; set; }
        public List<int> TopReleaseYearsUser { get; set; }
    }
}