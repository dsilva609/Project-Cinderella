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

        List<string> TopPublishers(string userID = "");

        List<string> TopCountriesOfOrigin(string userID = "");

        List<string> TopPurchaseCountries(string userID = "");

        List<string> MostCompleted(string userID = "");

        List<string> TopLocationsPurchased(string userID = "");

        List<int> TopReleaseYears(string userID = "");
    }
}