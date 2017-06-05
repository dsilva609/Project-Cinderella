using System;
using System.Collections.Generic;

namespace ProjectCinderella.BusinessLogic.Services.Interfaces
{
	public interface IBookStatisticService
	{
		int NumNovel(string userID = "");

		int NumComic(string userID = "");

		int NumManga(string userID = "");

		int NumHardcover(string userID = "");

		int NumFirstEdition(string userID = "");

		int TotalPageCount(string userID = "");

		List<Tuple<string, int>> TopPublishers(string userID = "", int numToTake = 0);

		List<Tuple<string, int>> TopCountriesOfOrigin(string userID = "", int numToTake = 0);

		List<Tuple<string, int>> TopPurchaseCountries(string userID = "", int numToTake = 0);

		List<Tuple<string, int>> MostCompleted(string userID = "", int numToTake = 0);

		List<Tuple<string, int>> TopLocationsPurchased(string userID = "", int numToTake = 0);

		List<Tuple<int, int>> TopReleaseYears(string userID = "", int numToTake = 0);
	}
}