using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Services.Statistics
{
	public class GameStatisticService : IGameStatisticService
	{
		private readonly IGameService _gameService;
		private readonly List<Game> _games;

		public GameStatisticService(IGameService gameService)
		{
			_gameService = gameService;
			_games = GetGames();
		}

		public int NumFullGame(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.Count(x => x.Type == GameTypeEnum.FullGame)
				: _games.Count(x => x.UserID == userID && x.Type == GameTypeEnum.FullGame);

		public int NumDLC(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.Count(x => x.Type == GameTypeEnum.DLC)
				: _games.Count(x => x.UserID == userID && x.Type == GameTypeEnum.DLC);

		public int NumExpansion(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.Count(x => x.Type == GameTypeEnum.Expansion)
				: _games.Count(x => x.UserID == userID && x.Type == GameTypeEnum.Expansion);

		public int NumRatedEC(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.Count(x => x.Rating == GameRatingEnum.EC && x.Platform != GamePlatformEnum.Boardgame)
				: _games.Count(x => x.UserID == userID && x.Rating == GameRatingEnum.EC && x.Platform != GamePlatformEnum.Boardgame);

		public int NumRatedE(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.Count(x => x.Rating == GameRatingEnum.E && x.Platform != GamePlatformEnum.Boardgame)
				: _games.Count(x => x.UserID == userID && x.Rating == GameRatingEnum.E && x.Platform != GamePlatformEnum.Boardgame);

		public int NumRatedE10(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.Count(x => x.Rating == GameRatingEnum.E10 && x.Platform != GamePlatformEnum.Boardgame)
				: _games.Count(x => x.UserID == userID && x.Rating == GameRatingEnum.E10 && x.Platform != GamePlatformEnum.Boardgame);

		public int NumRatedT(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.Count(x => x.Rating == GameRatingEnum.T && x.Platform != GamePlatformEnum.Boardgame)
				: _games.Count(x => x.UserID == userID && x.Rating == GameRatingEnum.T && x.Platform != GamePlatformEnum.Boardgame);

		public int NumRatedM(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.Count(x => x.Rating == GameRatingEnum.M && x.Platform != GamePlatformEnum.Boardgame)
				: _games.Count(x => x.UserID == userID && x.Rating == GameRatingEnum.M && x.Platform != GamePlatformEnum.Boardgame);

		public int NumRatedA(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.Count(x => x.Rating == GameRatingEnum.A && x.Platform != GamePlatformEnum.Boardgame)
				: _games.Count(x => x.UserID == userID && x.Rating == GameRatingEnum.A && x.Platform != GamePlatformEnum.Boardgame);

		public int NumBoardGame(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.Count(x => x.Platform == GamePlatformEnum.Boardgame)
				: _games.Count(x => x.UserID == userID && x.Platform == GamePlatformEnum.Boardgame);

		public int NumPC(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.Count(x => x.Platform == GamePlatformEnum.PC)
				: _games.Count(x => x.UserID == userID && x.Platform == GamePlatformEnum.PC);

		public int NumPlayStation(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.Count(x => x.Platform == GamePlatformEnum.PlayStation)
				: _games.Count(x => x.UserID == userID && x.Platform == GamePlatformEnum.PlayStation);

		public int NumPlayStation2(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.Count(x => x.Platform == GamePlatformEnum.PlayStation2)
				: _games.Count(x => x.UserID == userID && x.Platform == GamePlatformEnum.PlayStation2);

		public int NumPlayStation3(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.Count(x => x.Platform == GamePlatformEnum.PlayStation3)
				: _games.Count(x => x.UserID == userID && x.Platform == GamePlatformEnum.PlayStation3);

		public int NumPlayStation4(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.Count(x => x.Platform == GamePlatformEnum.PlayStation4)
				: _games.Count(x => x.UserID == userID && x.Platform == GamePlatformEnum.PlayStation4);

		public int NumXbox(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.Count(x => x.Platform == GamePlatformEnum.Xbox)
				: _games.Count(x => x.UserID == userID && x.Platform == GamePlatformEnum.Xbox);

		public int NumXbox360(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.Count(x => x.Platform == GamePlatformEnum.Xbox360)
				: _games.Count(x => x.UserID == userID && x.Platform == GamePlatformEnum.Xbox360);

		public int NumXboxOne(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.Count(x => x.Platform == GamePlatformEnum.XboxOne)
				: _games.Count(x => x.UserID == userID && x.Platform == GamePlatformEnum.XboxOne);

		public int NumNintendo64(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.Count(x => x.Platform == GamePlatformEnum.Nintendo64)
				: _games.Count(x => x.UserID == userID && x.Platform == GamePlatformEnum.Nintendo64);

		public int NumGameCube(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.Count(x => x.Platform == GamePlatformEnum.GameCube)
				: _games.Count(x => x.UserID == userID && x.Platform == GamePlatformEnum.GameCube);

		public int NumWii(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.Count(x => x.Platform == GamePlatformEnum.Wii)
				: _games.Count(x => x.UserID == userID && x.Platform == GamePlatformEnum.Wii);

		public int NumWiiU(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.Count(x => x.Platform == GamePlatformEnum.WiiU)
				: _games.Count(x => x.UserID == userID && x.Platform == GamePlatformEnum.WiiU);

		public int NumNintendoSwitch(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.Count(x => x.Platform == GamePlatformEnum.NintendoSwitch)
				: _games.Count(x => x.UserID == userID && x.Platform == GamePlatformEnum.NintendoSwitch);

		public int NumGameBoy(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.Count(x => x.Platform == GamePlatformEnum.GameBoy)
				: _games.Count(x => x.UserID == userID && x.Platform == GamePlatformEnum.GameBoy);

		public int NumGameBoyAdvance(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.Count(x => x.Platform == GamePlatformEnum.GameBoyAdvance)
				: _games.Count(x => x.UserID == userID && x.Platform == GamePlatformEnum.GameBoyAdvance);

		public int NumNintendoDS(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.Count(x => x.Platform == GamePlatformEnum.NintendoDS)
				: _games.Count(x => x.UserID == userID && x.Platform == GamePlatformEnum.NintendoDS);

		public int NumNintendo3DS(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.Count(x => x.Platform == GamePlatformEnum.Nintendo3DS)
				: _games.Count(x => x.UserID == userID && x.Platform == GamePlatformEnum.Nintendo3DS);

		public int NumPSVita(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.Count(x => x.Platform == GamePlatformEnum.PSVita)
				: _games.Count(x => x.UserID == userID && x.Platform == GamePlatformEnum.PSVita);

		public int NumPSP(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.Count(x => x.Platform == GamePlatformEnum.PSP)
				: _games.Count(x => x.UserID == userID && x.Platform == GamePlatformEnum.PSP);

		public List<string> TopDevelopers(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.GroupBy(x => x.Developer).OrderByDescending(y => y.Count()).Select(z => z.Key).ToList()
				: _games.Where(x => x.UserID == userID).GroupBy(y => y.Developer).OrderByDescending(z => z.Count()).Select(w => w.Key).ToList();

		public List<string> TopPublishers(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.GroupBy(x => x.Publisher).OrderByDescending(y => y.Count()).Select(z => z.Key).ToList()
				: _games.Where(x => x.UserID == userID).GroupBy(y => y.Publisher).OrderByDescending(z => z.Count()).Select(w => w.Key).ToList();

		public List<string> TopCountriesOfOrigin(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.GroupBy(x => x.CountryOfOrigin).OrderByDescending(y => y.Count()).Select(z => z.Key).ToList()
				: _games.Where(x => x.UserID == userID).GroupBy(y => y.CountryOfOrigin).OrderByDescending(z => z.Count()).Select(w => w.Key).ToList();

		public List<string> TopPurchaseCountries(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.GroupBy(x => x.CountryPurchased).OrderByDescending(y => y.Count()).Select(z => z.Key).ToList()
				: _games.Where(x => x.UserID == userID)
					.GroupBy(y => y.CountryPurchased)
					.OrderByDescending(z => z.Count())
					.Select(w => w.Key)
					.ToList();

		public List<string> MostCompleted(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.OrderByDescending(x => x.TimesCompleted).Select(y => y.Title).ToList()
				: _games.Where(x => x.UserID == userID).OrderByDescending(y => y.TimesCompleted).Select(z => z.Title).ToList();

		public List<string> TopLocationsPurchased(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.GroupBy(x => x.LocationPurchased).OrderByDescending(y => y.Count()).Select(z => z.Key).ToList()
				: _games.Where(x => x.UserID == userID)
					.GroupBy(y => y.LocationPurchased)
					.OrderByDescending(z => z.Count())
					.Select(w => w.Key)
					.ToList();

		public List<int> TopReleaseYears(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _games.GroupBy(x => x.YearReleased).OrderByDescending(y => y.Count()).Select(z => z.Key).ToList()
				: _games.Where(x => x.UserID == userID).GroupBy(y => y.YearReleased).OrderByDescending(z => z.Count()).Select(w => w.Key).ToList();

		private List<Game> GetGames() => _gameService.GetAll();
	}
}