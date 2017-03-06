using BusinessLogic.Enums;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public partial class ShowcaseController : Controller
    {
        [HttpGet]
        public virtual ActionResult Index()
        {
            var model = new ShowcaseViewModel
            {
                ViewTitle = "Index"
            };

            return View(model);
        }

        [HttpGet]
        public virtual ActionResult Add()
        {
            ViewBag.Title = "Add";

            return View();
        }

        [HttpGet]
        public virtual ActionResult SearchItems(string query, ItemType type)
        {
            Session["query"] = query.Trim();
            return RedirectToAction("Index", type.ToString());
        }
    }
}