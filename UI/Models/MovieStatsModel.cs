using System.Collections.Generic;

namespace UI.Models
{
    public class MovieStatsModel
    {
        public List<string> TopDirectors { get; set; }

        public int NumDVD { get; set; }

        public int NumBluRay { get; set; }

        public int NumRatedG { get; set; }

        public int NumRatedPG { get; set; }

        public int NumRatedPG13 { get; set; }

        public int NumRatedR { get; set; }

        public int NumRatedNR { get; set; }

        public List<string> TopCountriesOfOrigin { get; set; }

        public List<string> TopPurchaseCountries { get; set; }

        public List<string> MostCompleted { get; set; }

        public List<string> TopLocationsPurchased { get; set; }

        public List<int> TopReleaseYears { get; set; }
    }
}