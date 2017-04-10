using System.Collections.Generic;

namespace BusinessLogic.Services.Interfaces
{
    public interface IPopStatisticService
    {
        List<string> TopSeries(string userID = "", int numToTake = 0);

        List<string> TopLines(string userID = "", int numToTake = 0);

        List<string> TopCountriesOfOrigin(string userID = "", int numToTake = 0);

        List<string> TopPurchaseCountries(string userID = "", int numToTake = 0);

        List<string> TopLocationsPurchased(string userID = "", int numToTake = 0);

        List<int> TopReleaseYears(string userID = "", int numToTake = 0);
    }
}