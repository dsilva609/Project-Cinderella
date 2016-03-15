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

        [HttpPost]
        public virtual ActionResult Create(RecordModel model)
        {
            if (ModelState.IsValid)
            {
                //--TODO: save model to database

                RedirectToAction(MVC.Record.Index());
            }
            return View(MVC.Record.Views.Edit, model);
        }
    }
}