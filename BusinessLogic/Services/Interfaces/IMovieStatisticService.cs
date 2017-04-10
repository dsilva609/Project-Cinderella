using System.Collections.Generic;

namespace BusinessLogic.Services.Interfaces
{
    public interface IMovieStatisticService
    {
        List<string> TopDirectors(string userID = "", int numToTake = 0);

        int NumDVD(string userID = "");

        int NumBluRay(string userID = "");

        int NumRatedG(string userID = "");

        int NumRatedPG(string userID = "");

        int NumRatedPG13(string userID = "");

        int NumRatedR(string userID = "");

        int NumRatedNR(string userID = "");

        List<string> TopCountriesOfOrigin(string userID = "", int numToTake = 0);

        List<string> TopPurchaseCountries(string userID = "", int numToTake = 0);

        List<string> MostCompleted(string userID = "", int numToTake = 0);

        List<string> TopLocationsPurchased(string userID = "", int numToTake = 0);

        List<int> TopReleaseYears(string userID = "", int numToTake = 0);
    }
}