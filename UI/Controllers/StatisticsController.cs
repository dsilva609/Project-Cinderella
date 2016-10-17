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
					NumGames = _statisticService.GetNumGames()
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
						NumGames = _statisticService.GetNumGames(userID)
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
	}
}