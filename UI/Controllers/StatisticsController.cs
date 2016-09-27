using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using System.Web.Mvc;

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
            var model = new CollectionStatistic
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
                NumCheckedOut = _statisticService.GetNumCheckedOut()
            };

            ViewBag.Title = "Global Statistics";

            return View(model);
        }
    }
}