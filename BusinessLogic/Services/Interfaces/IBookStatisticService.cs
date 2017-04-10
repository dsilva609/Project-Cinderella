using System.Collections.Generic;

namespace BusinessLogic.Services.Interfaces
{
    public interface IBookStatisticService
    {
        int NumNovel(string userID = "");

        int NumComic(string userID = "");

        int NumManga(string userID = "");

        int NumHardcover(string userID = "");

        int NumFirstEdition(string userID = "");

        int TotalPageCount(string userID = "");

        List<string> TopPublishers(string userID = "", int numToTake = 0);

        List<string> TopCountriesOfOrigin(string userID = "", int numToTake = 0);

        List<string> TopPurchaseCountries(string userID = "", int numToTake = 0);

        List<string> MostCompleted(string userID = "", int numToTake = 0);

        List<string> TopLocationsPurchased(string userID = "", int numToTake = 0);

        List<int> TopReleaseYears(string userID = "", int numToTake = 0);
    }
}