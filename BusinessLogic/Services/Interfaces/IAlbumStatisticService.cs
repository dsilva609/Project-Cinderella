using System.Collections.Generic;

namespace BusinessLogic.Services.Interfaces
{
    public interface IAlbumStatisticService
    {
        int NumVinyl(string userID);

        int NumCD(string userID);

        int Num3313RPM(string userID);

        int Num45RPM(string userID);

        int Num78RPM(string userID);

        int Num12Inch(string userID);

        int Num10Inch(string userID);

        int Num7Inch(string userID);

        List<string> TopArtists(string userID);

        List<string> TopStyles(string userID);

        List<string> TopRecordLabels(string userID);

        List<string> TopCountriesOfOrigin(string userID);

        List<string> TopPurchaseCountries(string userID);

        List<string> MostCompleted(string userID);

        List<string> TopLocationsPurchased(string userID);

        List<int> TopReleaseYears(string userID);
    }
}