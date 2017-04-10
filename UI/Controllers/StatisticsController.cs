using BusinessLogic.Models.Interfaces;
using BusinessLogic.Services.Interfaces;
using System.Linq;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public partial class StatisticsController : ProjectCinderellaControllerBase
    {
        private readonly IUserContext _user;
        private readonly IStatisticService _statisticService;
        private readonly IAlbumStatisticService _albumStatisticService;
        private readonly IBookStatisticService _bookStatisticService;
        private readonly IMovieStatisticService _movieStatisticService;
        private readonly IGameStatisticService _gameStatisticService;
        private readonly IPopStatisticService _popStatisticService;
        private const int NUM_OF_TOP_TO_TAKE = 10;

        public StatisticsController(IUserContext user, IStatisticService statisticService, IAlbumStatisticService albumStatisticService,
            IBookStatisticService bookStatisticService, IMovieStatisticService movieStatisticService, IGameStatisticService gameStatisticService,
            IPopStatisticService popStatisticService)
        {
            _user = user;
            _statisticService = statisticService;
            _albumStatisticService = albumStatisticService;
            _bookStatisticService = bookStatisticService;
            _movieStatisticService = movieStatisticService;
            _gameStatisticService = gameStatisticService;
            _popStatisticService = popStatisticService;
        }

        [HttpGet]
        public virtual ActionResult Index()
        {
            var universalStats = new StatsViewModel
            {
                Title = "Global",
                CollectionCount = _statisticService.GetCollectionCount(),
                Condition = new Condition
                {
                    Title = "Global Item Conditions",
                    ID = "global-item-conditions",
                    NumNew = _statisticService.GetNumNew(),
                    NumUsed = _statisticService.GetNumUsed()
                },
                MediaTypes = new MediaTypes
                {
                    Title = "Global Media Types",
                    ID = "global-media-types",
                    NumPhysical = _statisticService.GetNumPhysical(),
                    NumDigital = _statisticService.GetNumDigital()
                },
                TimesCompleted = _statisticService.GetTimesCompleted(),
                CompletionStatus = new CompletionStatus
                {
                    Title = "Global Completion Status",
                    ID = "global-completion-status",
                    NumCompleted = _statisticService.GetNumCompleted(),
                    NumInProgress = _statisticService.GetNumInProgress(),
                    NumNotStarted = _statisticService.GetNumNotStarted(),
                },
                NumCheckedOut = _statisticService.GetNumCheckedOut(),
                ItemTypes = new ItemTypes
                {
                    Title = "Global Item Types",
                    ID = "global-item-types",
                    NumAlbums = _statisticService.GetNumAlbums(),
                    NumBooks = _statisticService.GetNumBooks(),
                    NumMoviesAndShows = _statisticService.GetNumMoviesShows(),
                    NumGames = _statisticService.GetNumGames(),
                    NumPops = _statisticService.GetNumPops(),
                    NumWishes = _statisticService.GetNumWishes(),
                    NumShowcased = _statisticService.GetNumShowcased()
                }
            };

            var userID = _user.GetUserID();
            var userStats = string.IsNullOrWhiteSpace(userID)
                ? null
                : new StatsViewModel
                {
                    Title = "User",
                    CollectionCount = _statisticService.GetCollectionCount(userID),
                    Condition = new Condition
                    {
                        Title = "User Item Conditions",
                        ID = "user-item-conditions",
                        NumNew = _statisticService.GetNumNew(userID),
                        NumUsed = _statisticService.GetNumUsed(userID)
                    },
                    MediaTypes = new MediaTypes
                    {
                        Title = "User Media Types",
                        ID = "user-media-types",
                        NumPhysical = _statisticService.GetNumPhysical(userID),
                        NumDigital = _statisticService.GetNumDigital(userID)
                    },
                    TimesCompleted = _statisticService.GetTimesCompleted(userID),
                    CompletionStatus = new CompletionStatus
                    {
                        Title = "User Completion Status",
                        ID = "user-completion-status",
                        NumCompleted = _statisticService.GetNumCompleted(userID),
                        NumInProgress = _statisticService.GetNumInProgress(userID),
                        NumNotStarted = _statisticService.GetNumNotStarted(userID)
                    },
                    NumCheckedOut = _statisticService.GetNumCheckedOut(userID),
                    ItemTypes = new ItemTypes
                    {
                        Title = "User Item Types",
                        ID = "user-item-types",
                        NumAlbums = _statisticService.GetNumAlbums(userID),
                        NumBooks = _statisticService.GetNumBooks(userID),
                        NumMoviesAndShows = _statisticService.GetNumMoviesShows(userID),
                        NumGames = _statisticService.GetNumGames(userID),
                        NumPops = _statisticService.GetNumPops(userID),
                        NumWishes = _statisticService.GetNumWishes(userID),
                        NumShowcased = _statisticService.GetNumShowcased(userID)
                    }
                };

            var model = new StatisticsViewModel
            {
                Universal = universalStats,
                User = userStats
            };

            ViewBag.Title = "Global Statistics";

            return View(model);
        }

        [HttpGet]
        public virtual ActionResult AlbumStats()
        {
            ViewBag.Title = "Album Stats";

            var model = new AlbumStatsViewModel
            {
                NumVinyl = _albumStatisticService.NumVinyl(),
                NumCD = _albumStatisticService.NumCD(),
                Num33RPM = _albumStatisticService.Num3313RPM(),
                Num45RPM = _albumStatisticService.Num45RPM(),
                Num78RPM = _albumStatisticService.Num78RPM(),
                Num12Inch = _albumStatisticService.Num12Inch(),
                Num10Inch = _albumStatisticService.Num10Inch(),
                Num7Inch = _albumStatisticService.Num7Inch(),
                TopArtists = _albumStatisticService.TopArtists(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),
                TopGenres = _albumStatisticService.TopGenres(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),
                TopRecordLabels = _albumStatisticService.TopRecordLabels(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),
                TopCountriesOfOrigin = _albumStatisticService.TopCountriesOfOrigin(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),
                TopPurchaseCountries = _albumStatisticService.TopPurchaseCountries(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),
                MostCompleted = _albumStatisticService.MostCompleted(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),
                TopLocationsPurchased = _albumStatisticService.TopLocationsPurchased(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),
                TopReleaseYears = _albumStatisticService.TopReleaseYears(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),

                NumVinylUser = _albumStatisticService.NumVinyl(_user.GetUserID()),
                NumCDUser = _albumStatisticService.NumCD(_user.GetUserID()),
                Num33RPMUser = _albumStatisticService.Num3313RPM(_user.GetUserID()),
                Num45RPMUser = _albumStatisticService.Num45RPM(_user.GetUserID()),
                Num78RPMUser = _albumStatisticService.Num78RPM(_user.GetUserID()),
                Num12InchUser = _albumStatisticService.Num12Inch(_user.GetUserID()),
                Num10InchUser = _albumStatisticService.Num10Inch(_user.GetUserID()),
                Num7InchUser = _albumStatisticService.Num7Inch(_user.GetUserID()),
                TopArtistsUser = _albumStatisticService.TopArtists(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList(),
                TopGenresUser = _albumStatisticService.TopGenres(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList(),
                TopRecordLabelsUser = _albumStatisticService.TopRecordLabels(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList(),
                TopCountriesOfOriginUser = _albumStatisticService.TopCountriesOfOrigin(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList(),
                TopPurchaseCountriesUser = _albumStatisticService.TopPurchaseCountries(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList(),
                MostCompletedUser = _albumStatisticService.MostCompleted(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList(),
                TopLocationsPurchasedUser = _albumStatisticService.TopLocationsPurchased(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList(),
                TopReleaseYearsUser = _albumStatisticService.TopReleaseYears(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList()
            };

            return View(model);
        }

        [HttpGet]
        public virtual ActionResult BookStats()
        {
            ViewBag.Title = "Book Stats";

            var model = new BookStatsViewModel
            {
                NumNovel = _bookStatisticService.NumNovel(),
                NumComic = _bookStatisticService.NumComic(),
                NumManga = _bookStatisticService.NumManga(),
                NumHardcover = _bookStatisticService.NumHardcover(),
                NumFirstEdition = _bookStatisticService.NumFirstEdition(),
                TotalPageCount = _bookStatisticService.TotalPageCount(),
                TopPublishers = _bookStatisticService.TopPublishers(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),
                TopCountriesOfOrigin = _bookStatisticService.TopCountriesOfOrigin(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),
                TopPurchaseCountries = _bookStatisticService.TopPurchaseCountries(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),
                MostCompleted = _bookStatisticService.MostCompleted(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),
                TopLocationsPurchased = _bookStatisticService.TopLocationsPurchased(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),
                TopReleaseYears = _bookStatisticService.TopReleaseYears(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),

                NumNovelUser = _bookStatisticService.NumNovel(_user.GetUserID()),
                NumComicUser = _bookStatisticService.NumComic(_user.GetUserID()),
                NumMangaUser = _bookStatisticService.NumManga(_user.GetUserID()),
                NumHardcoverUser = _bookStatisticService.NumHardcover(_user.GetUserID()),
                NumFirstEditionUser = _bookStatisticService.NumFirstEdition(_user.GetUserID()),
                TotalPageCountUser = _bookStatisticService.TotalPageCount(_user.GetUserID()),
                TopPublishersUser = _bookStatisticService.TopPublishers(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList(),
                TopCountriesOfOriginUser = _bookStatisticService.TopCountriesOfOrigin(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList(),
                TopPurchaseCountriesUser = _bookStatisticService.TopPurchaseCountries(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList(),
                MostCompletedUser = _bookStatisticService.MostCompleted(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList(),
                TopLocationsPurchasedUser = _bookStatisticService.TopLocationsPurchased(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList(),
                TopReleaseYearsUser = _bookStatisticService.TopReleaseYears(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList()
            };

            return View(model);
        }

        [HttpGet]
        public virtual ActionResult GameStats()
        {
            ViewBag.Title = "Game Stats";

            var model = new GameStatsViewModel
            {
                TopDevelopers = _gameStatisticService.TopDevelopers(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),
                TopPublishers = _gameStatisticService.TopPublishers(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),
                NumFullGame = _gameStatisticService.NumFullGame(),
                NumDLC = _gameStatisticService.NumDLC(),
                NumExpansion = _gameStatisticService.NumExpansion(),
                NumRatedEC = _gameStatisticService.NumRatedEC(),
                NumRatedE = _gameStatisticService.NumRatedE(),
                NumRatedE10 = _gameStatisticService.NumRatedE10(),
                NumRatedT = _gameStatisticService.NumRatedT(),
                NumRatedM = _gameStatisticService.NumRatedM(),
                NumRatedA = _gameStatisticService.NumRatedA(),
                NumBoardGame = _gameStatisticService.NumBoardGame(),
                NumPC = _gameStatisticService.NumPC(),
                NumPlayStation = _gameStatisticService.NumPlayStation(),
                NumPlayStation2 = _gameStatisticService.NumPlayStation2(),
                NumPlayStation3 = _gameStatisticService.NumPlayStation3(),
                NumPlayStation4 = _gameStatisticService.NumPlayStation4(),
                NumXbox = _gameStatisticService.NumXbox(),
                NumXbox360 = _gameStatisticService.NumXbox360(),
                NumXboxOne = _gameStatisticService.NumXboxOne(),
                NumNintendo64 = _gameStatisticService.NumNintendo64(),
                NumGameCube = _gameStatisticService.NumGameCube(),
                NumWii = _gameStatisticService.NumWii(),
                NumWiiU = _gameStatisticService.NumWiiU(),
                NumNintendoSwitch = _gameStatisticService.NumNintendoSwitch(),
                NumGameBoy = _gameStatisticService.NumGameBoy(),
                NumGameBoyAdvance = _gameStatisticService.NumGameBoyAdvance(),
                NumNintendoDS = _gameStatisticService.NumNintendoDS(),
                NumNintendo3DS = _gameStatisticService.NumNintendo3DS(),
                NumPSP = _gameStatisticService.NumPSP(),
                NumPSVita = _gameStatisticService.NumPSVita(),
                TopCountriesOfOrigin = _gameStatisticService.TopCountriesOfOrigin(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),
                TopPurchaseCountries = _gameStatisticService.TopPurchaseCountries(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),
                MostCompleted = _gameStatisticService.MostCompleted(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),
                TopLocationsPurchased = _gameStatisticService.TopLocationsPurchased(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),
                TopReleaseYears = _gameStatisticService.TopReleaseYears(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),

                TopDevelopersUser = _gameStatisticService.TopDevelopers(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList(),
                TopPublishersUser = _gameStatisticService.TopPublishers(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList(),
                NumFullGameUser = _gameStatisticService.NumFullGame(_user.GetUserID()),
                NumDLCUser = _gameStatisticService.NumDLC(_user.GetUserID()),
                NumExpansionUser = _gameStatisticService.NumExpansion(_user.GetUserID()),
                NumRatedECUser = _gameStatisticService.NumRatedEC(_user.GetUserID()),
                NumRatedEUser = _gameStatisticService.NumRatedE(_user.GetUserID()),
                NumRatedE10User = _gameStatisticService.NumRatedE10(_user.GetUserID()),
                NumRatedTUser = _gameStatisticService.NumRatedT(_user.GetUserID()),
                NumRatedMUser = _gameStatisticService.NumRatedM(_user.GetUserID()),
                NumRatedAUser = _gameStatisticService.NumRatedA(_user.GetUserID()),
                NumBoardGameUser = _gameStatisticService.NumBoardGame(_user.GetUserID()),
                NumPCUser = _gameStatisticService.NumPC(_user.GetUserID()),
                NumPlayStationUser = _gameStatisticService.NumPlayStation(_user.GetUserID()),
                NumPlayStation2User = _gameStatisticService.NumPlayStation2(_user.GetUserID()),
                NumPlayStation3User = _gameStatisticService.NumPlayStation3(_user.GetUserID()),
                NumPlayStation4User = _gameStatisticService.NumPlayStation4(_user.GetUserID()),
                NumXboxUser = _gameStatisticService.NumXbox(_user.GetUserID()),
                NumXbox360User = _gameStatisticService.NumXbox360(_user.GetUserID()),
                NumXboxOneUser = _gameStatisticService.NumXboxOne(_user.GetUserID()),
                NumNintendo64User = _gameStatisticService.NumNintendo64(_user.GetUserID()),
                NumGameCubeUser = _gameStatisticService.NumGameCube(_user.GetUserID()),
                NumWiiUser = _gameStatisticService.NumWii(_user.GetUserID()),
                NumWiiUUser = _gameStatisticService.NumWiiU(_user.GetUserID()),
                NumNintendoSwitchUser = _gameStatisticService.NumNintendoSwitch(_user.GetUserID()),
                NumGameBoyUser = _gameStatisticService.NumGameBoy(_user.GetUserID()),
                NumGameBoyAdvanceUser = _gameStatisticService.NumGameBoyAdvance(_user.GetUserID()),
                NumNintendoDSUser = _gameStatisticService.NumNintendoDS(_user.GetUserID()),
                NumNintendo3DSUser = _gameStatisticService.NumNintendo3DS(_user.GetUserID()),
                NumPSPUser = _gameStatisticService.NumPSP(_user.GetUserID()),
                NumPSVitaUser = _gameStatisticService.NumPSVita(_user.GetUserID()),
                TopCountriesOfOriginUser = _gameStatisticService.TopCountriesOfOrigin(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList(),
                TopPurchaseCountriesUser = _gameStatisticService.TopPurchaseCountries(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList(),
                MostCompletedUser = _gameStatisticService.MostCompleted(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList(),
                TopLocationsPurchasedUser = _gameStatisticService.TopLocationsPurchased(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList(),
                TopReleaseYearsUser = _gameStatisticService.TopReleaseYears(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList()
            };

            return View(model);
        }

        [HttpGet]
        public virtual ActionResult MovieStats()
        {
            ViewBag.Title = "Movie Stats";

            var model = new MovieStatsViewModel
            {
                TopDirectors = _movieStatisticService.TopDirectors(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),
                NumDVD = _movieStatisticService.NumDVD(),
                NumBluRay = _movieStatisticService.NumBluRay(),
                NumRatedG = _movieStatisticService.NumRatedG(),
                NumRatedPG = _movieStatisticService.NumRatedPG(),
                NumRatedPG13 = _movieStatisticService.NumRatedPG13(),
                NumRatedR = _movieStatisticService.NumRatedR(),
                NumRatedNR = _movieStatisticService.NumRatedNR(),
                TopCountriesOfOrigin = _movieStatisticService.TopCountriesOfOrigin(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),
                TopPurchaseCountries = _movieStatisticService.TopPurchaseCountries(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),
                MostCompleted = _movieStatisticService.MostCompleted(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),
                TopLocationsPurchased = _movieStatisticService.TopLocationsPurchased(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),
                TopReleaseYears = _movieStatisticService.TopReleaseYears(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),

                TopDirectorsUser = _movieStatisticService.TopDirectors(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList(),
                NumDVDUser = _movieStatisticService.NumDVD(),
                NumBluRayUser = _movieStatisticService.NumBluRay(),
                NumRatedGUser = _movieStatisticService.NumRatedG(),
                NumRatedPGUser = _movieStatisticService.NumRatedPG(),
                NumRatedPG13User = _movieStatisticService.NumRatedPG13(),
                NumRatedRUser = _movieStatisticService.NumRatedR(),
                NumRatedNRUser = _movieStatisticService.NumRatedNR(),
                TopCountriesOfOriginUser = _movieStatisticService.TopCountriesOfOrigin(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList(),
                TopPurchaseCountriesUser = _movieStatisticService.TopPurchaseCountries(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList(),
                MostCompletedUser = _movieStatisticService.MostCompleted(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList(),
                TopLocationsPurchasedUser = _movieStatisticService.TopLocationsPurchased(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList(),
                TopReleaseYearsUser = _movieStatisticService.TopReleaseYears(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList()
            };

            return View(model);
        }

        [HttpGet]
        public virtual ActionResult PopStats()
        {
            ViewBag.Title = "Pop Stats";

            var model = new PopStatsViewModel
            {
                TopSeries = _popStatisticService.TopSeries(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),
                TopLines = _popStatisticService.TopLines(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),
                TopCountriesOfOrigin = _popStatisticService.TopCountriesOfOrigin(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),
                TopPurchaseCountries = _popStatisticService.TopPurchaseCountries(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),
                TopLocationsPurchased = _popStatisticService.TopLocationsPurchased(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),
                TopReleaseYears = _popStatisticService.TopReleaseYears(numToTake: NUM_OF_TOP_TO_TAKE).ToList(),

                TopSeriesUser = _popStatisticService.TopSeries(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList(),
                TopLinesUser = _popStatisticService.TopLines(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList(),
                TopCountriesOfOriginUser = _popStatisticService.TopCountriesOfOrigin(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList(),
                TopPurchaseCountriesUser = _popStatisticService.TopPurchaseCountries(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList(),
                TopLocationsPurchasedUser = _popStatisticService.TopLocationsPurchased(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList(),
                TopReleaseYearsUser = _popStatisticService.TopReleaseYears(_user.GetUserID(), NUM_OF_TOP_TO_TAKE).ToList()
            };

            return View(model);
        }
    }
}