using BusinessLogic.DAL;
using BusinessLogic.Models;
using BusinessLogic.Repositories;
using BusinessLogic.Services;
using System.Web.Mvc;

namespace UI.Controllers
{
    public partial class RecordController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly RecordService _service;

        public RecordController()
        {
            _uow = new UnitOfWork<ProjectCinderellaContext>();
            _service = new RecordService(_uow);
        }

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
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(RecordModel model)
        {
            if (ModelState.IsValid)
            {
                this._service.Add(model);

                RedirectToAction(MVC.Record.Index());
            }
            return View(MVC.Record.Views.Edit, model);
        }
    }
}