using System.Collections.Generic;

namespace BusinessLogic.Services.Interfaces
{
	public interface IPopStatisticService
	{
		List<string> TopSeries(string userID);

		List<string> TopLines(string userID);

		List<string> TopCountriesOfOrigin(string userID);

		List<string> TopPurchaseCountries(string userID);

		List<string> TopLocationsPurchased(string userID);

		List<int> TopReleaseYears(string userID);
	}
}