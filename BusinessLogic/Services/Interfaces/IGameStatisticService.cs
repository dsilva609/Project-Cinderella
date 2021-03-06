﻿using System;
using System.Collections.Generic;

namespace BusinessLogic.Services.Interfaces
{
	public interface IGameStatisticService
	{
		int NumFullGame(string userID = "");

		int NumDLC(string userID = "");

		int NumExpansion(string userID = "");

		int NumRatedEC(string userID = "");

		int NumRatedE(string userID = "");

		int NumRatedE10(string userID = "");

		int NumRatedT(string userID = "");

		int NumRatedM(string userID = "");

		int NumRatedA(string userID = "");

		int NumBoardGame(string userID = "");

		int NumPC(string userID = "");

		int NumPlayStation(string userID = "");

		int NumPlayStation2(string userID = "");

		int NumPlayStation3(string userID = "");

		int NumPlayStation4(string userID = "");

		int NumXbox(string userID = "");

		int NumXbox360(string userID = "");

		int NumXboxOne(string userID = "");

		int NumNintendo64(string userID = "");

		int NumGameCube(string userID = "");

		int NumWii(string userID = "");

		int NumWiiU(string userID = "");

		int NumNintendoSwitch(string userID = "");

		int NumGameBoy(string userID = "");

		int NumGameBoyAdvance(string userID = "");

		int NumNintendoDS(string userID = "");

		int NumNintendo3DS(string userID = "");

		int NumPSP(string userID = "");

		int NumPSVita(string userID = "");

		List<Tuple<string, int>> TopDevelopers(string userID = "", int numToTake = 0);

		List<Tuple<string, int>> TopPublishers(string userID = "", int numToTake = 0);

		List<Tuple<string, int>> TopCountriesOfOrigin(string userID = "", int numToTake = 0);

		List<Tuple<string, int>> TopPurchaseCountries(string userID = "", int numToTake = 0);

		List<Tuple<string, int>> MostCompleted(string userID = "", int numToTake = 0);

		List<Tuple<string, int>> TopLocationsPurchased(string userID = "", int numToTake = 0);

		List<Tuple<int, int>> TopReleaseYears(string userID = "", int numToTake = 0);
	}
}