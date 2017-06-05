using System;
using System.Collections.Generic;

namespace ProjectCinderella.BusinessLogic.Services.Interfaces
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

		List<Tuple<string, int>> TopArtists(string userID = "", int numToTake = 0);

		List<Tuple<string, int>> TopGenres(string userID = "", int numToTake = 0);

		List<Tuple<string, int>> TopRecordLabels(string userID = "", int numToTake = 0);

		List<Tuple<string, int>> TopCountriesOfOrigin(string userID = "", int numToTake = 0);

		List<Tuple<string, int>> TopPurchaseCountries(string userID = "", int numToTake = 0);

		List<Tuple<string, int>> MostCompleted(string userID = "", int numToTake = 0);

		List<Tuple<string, int>> TopLocationsPurchased(string userID = "", int numToTake = 0);

		List<Tuple<int, int>> TopReleaseYears(string userID = "", int numToTake = 0);
	}
}