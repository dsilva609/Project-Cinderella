using System.Collections.Generic;

namespace BusinessLogic.Services.Interfaces
{
    public interface IMovieStatisticService
    {
        List<string> TopDirectors(string userID = "");

        int NumDVD(string userID = "");

        int NumBluRay(string userID = "");

        int NumRatedG(string userID = "");

        int NumRatedPG(string userID = "");

        int NumRatedPG13(string userID = "");

        int NumRatedR(string userID = "");

        int NumRatedNR(string userID = "");

        List<string> TopCountriesOfOrigin(string userID = "");

        List<string> TopPurchaseCountries(string userID = "");

        List<string> MostCompleted(string userID = "");

        List<string> TopLocationsPurchased(string userID = "");

        List<int> TopReleaseYears(string userID = "");
    }
}