using System.Collections.Generic;

namespace BusinessLogic.Services.Interfaces
{
    public interface IAlbumStatisticService
    {
        int NumVinyl(string userID = "");

        int NumCD(string userID = "");

        int Num3313RPM(string userID = "");

        int Num45RPM(string userID = "");

        int Num78RPM(string userID = "");

        int Num12Inch(string userID = "");

        int Num10Inch(string userID = "");

        int Num7Inch(string userID = "");

        List<string> TopArtists(string userID = "", int numToTake = 0);

        List<string> TopGenres(string userID = "", int numToTake = 0);

        List<string> TopRecordLabels(string userID = "", int numToTake = 0);

        List<string> TopCountriesOfOrigin(string userID = "", int numToTake = 0);

        List<string> TopPurchaseCountries(string userID = "", int numToTake = 0);

        List<string> MostCompleted(string userID = "", int numToTake = 0);

        List<string> TopLocationsPurchased(string userID = "", int numToTake = 0);

        List<int> TopReleaseYears(string userID = "", int numToTake = 0);
    }
}