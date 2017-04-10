using System.Collections.Generic;

namespace UI.Models
{
    public class PopStatsViewModel
    {
        public List<string> TopSeries { get; set; }

        public List<string> TopLines { get; set; }

        public List<string> TopCountriesOfOrigin { get; set; }

        public List<string> TopPurchaseCountries { get; set; }

        public List<string> TopLocationsPurchased { get; set; }

        public List<int> TopReleaseYears { get; set; }

        public List<string> TopSeriesUser { get; set; }

        public List<string> TopLinesUser { get; set; }

        public List<string> TopCountriesOfOriginUser { get; set; }

        public List<string> TopPurchaseCountriesUser { get; set; }

        public List<string> TopLocationsPurchasedUser { get; set; }

        public List<int> TopReleaseYearsUser { get; set; }
    }
}