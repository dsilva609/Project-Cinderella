using BusinessLogic.Models;
using System.Web.Mvc;

namespace UI.Controllers
{
    public partial class RecordController : Controller
    {
        [HttpGet]
        public virtual ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            var model = new RecordModel();

            return View(MVC.Record.Views.Edit, model);
        }
    }
}