using BusinessLogic.Services.Interfaces;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public partial class StatisticsController : ProjectCinderellaControllerBase
    {
        private readonly IStatisticService _statisticService;
        private readonly IAlbumStatisticService _albumStatisticService;
        private readonly IBookStatisticService _bookStatisticService;
        private readonly IMovieStatisticService _movieStatisticService;
        private readonly IGameStatisticService _gameStatisticService;
        private readonly IPopStatisticService _popStatisticService;
        private const int NUM_OF_TOP_TO_TAKE = 10;

        public StatisticsController(IStatisticService statisticService, IAlbumStatisticService albumStatisticService,
            IBookStatisticService bookStatisticService, IMovieStatisticService movieStatisticService, IGameStatisticService gameStatisticService,
            IPopStatisticService popStatisticService)
        {
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

            var userID = User.Identity.GetUserId();
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
                TopArtists = _albumStatisticService.TopArtists()?.Take(10).ToList(),
                TopGenres = _albumStatisticService.TopGenres()?.Take(10).ToList(),
                TopRecordLabels = _albumStatisticService.TopRecordLabels()?.Take(10).ToList(),
                TopCountriesOfOrigin = _albumStatisticService.TopCountriesOfOrigin()?.Take(10).ToList(),
                TopPurchaseCountries = _albumStatisticService.TopPurchaseCountries()?.Take(10).ToList(),
                MostCompleted = _albumStatisticService.MostCompleted()?.Take(10).ToList(),
                TopLocationsPurchased = _albumStatisticService.TopLocationsPurchased()?.Take(10).ToList(),
                TopReleaseYears = _albumStatisticService.TopReleaseYears()?.Take(10).ToList()
            };

            return View(model);
        }
    }
}