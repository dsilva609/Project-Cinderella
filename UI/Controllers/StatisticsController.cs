using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public partial class StatisticsController : ProjectCinderellaControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticsController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet]
        public virtual ActionResult Index()
        {
            var universalStats = new GlobalStats
            {
                CollectionCount = _statisticService.GetCollectionCount(),
                NumNew = _statisticService.GetNumNew(),
                NumUsed = _statisticService.GetNumUsed(),
                NumPhysical = _statisticService.GetNumPhysical(),
                NumDigital = _statisticService.GetNumDigital(),
                TimesCompleted = _statisticService.GetTimesCompleted(),
                NumCompleted = _statisticService.GetNumCompleted(),
                NumInProgress = _statisticService.GetNumInProgress(),
                NumNotStarted = _statisticService.GetNumNotStarted(),
                NumCheckedOut = _statisticService.GetNumCheckedOut(),
                NumAlbums = _statisticService.GetNumAlbums(),
                NumBooks = _statisticService.GetNumBooks(),
                NumMoviesAndShows = _statisticService.GetNumMoviesShows(),
                NumGames = _statisticService.GetNumGames()
            };

            var userID = User.Identity.GetUserId();
            var userStats = string.IsNullOrWhiteSpace(userID)
                ? null
                : new GlobalStats
                {
                    CollectionCount = _statisticService.GetCollectionCount(userID),
                    NumNew = _statisticService.GetNumNew(userID),
                    NumUsed = _statisticService.GetNumUsed(userID),
                    NumPhysical = _statisticService.GetNumPhysical(userID),
                    NumDigital = _statisticService.GetNumDigital(userID),
                    TimesCompleted = _statisticService.GetTimesCompleted(userID),
                    NumCompleted = _statisticService.GetNumCompleted(userID),
                    NumInProgress = _statisticService.GetNumInProgress(userID),
                    NumNotStarted = _statisticService.GetNumNotStarted(userID),
                    NumCheckedOut = _statisticService.GetNumCheckedOut(userID),
                    NumAlbums = _statisticService.GetNumAlbums(userID),
                    NumBooks = _statisticService.GetNumBooks(userID),
                    NumMoviesAndShows = _statisticService.GetNumMoviesShows(userID),
                    NumGames = _statisticService.GetNumGames(userID)
                };

            var model = new StatisticsViewModel
            {
                Universal = universalStats,
                User = userStats
            };

            ViewBag.Title = "Global Statistics";

            return View(model);
        }
    }
}