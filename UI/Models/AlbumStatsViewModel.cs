using System.Collections.Generic;

namespace UI.Models
{
    public class AlbumStatsViewModel
    {
        public int NumVinyl { get; set; }
        public int NumCD { get; set; }
        public int Num33RPM { get; set; }
        public int Num45RPM { get; set; }
        public int Num78RPM { get; set; }
        public int Num12Inch { get; set; }
        public int Num10Inch { get; set; }
        public int Num7Inch { get; set; }
        public List<string> TopArtists { get; set; }
        public List<string> TopGenres { get; set; }
        public List<string> TopRecordLabels { get; set; }
        public List<string> TopCountriesOfOrigin { get; set; }
        public List<string> TopPurchaseCountries { get; set; }
        public List<string> MostCompleted { get; set; }
        public List<string> TopLocationsPurchased { get; set; }
        public List<int> TopReleaseYears { get; set; }

        public int NumVinylUser { get; set; }
        public int NumCDUser { get; set; }
        public int Num33RPMUser { get; set; }
        public int Num45RPMUser { get; set; }
        public int Num78RPMUser { get; set; }
        public int Num12InchUser { get; set; }
        public int Num10InchUser { get; set; }
        public int Num7InchUser { get; set; }
        public List<string> TopArtistsUser { get; set; }
        public List<string> TopGenresUser { get; set; }
        public List<string> TopRecordLabelsUser { get; set; }
        public List<string> TopCountriesOfOriginUser { get; set; }
        public List<string> TopPurchaseCountriesUser { get; set; }
        public List<string> MostCompletedUser { get; set; }
        public List<string> TopLocationsPurchasedUser { get; set; }
        public List<int> TopReleaseYearsUser { get; set; }
    }
}