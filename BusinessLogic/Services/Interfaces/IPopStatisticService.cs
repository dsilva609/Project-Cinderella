using System;
using System.Collections.Generic;

namespace BusinessLogic.Services.Interfaces
{
	public interface IPopStatisticService
	{
		List<Tuple<string, int>> TopSeries(string userID = "", int numToTake = 0);

		List<Tuple<string, int>> TopLines(string userID = "", int numToTake = 0);

		List<Tuple<string, int>> TopCountriesOfOrigin(string userID = "", int numToTake = 0);

		List<Tuple<string, int>> TopPurchaseCountries(string userID = "", int numToTake = 0);

		List<Tuple<string, int>> TopLocationsPurchased(string userID = "", int numToTake = 0);

		List<Tuple<int, int>> TopReleaseYears(string userID = "", int numToTake = 0);
	}
}