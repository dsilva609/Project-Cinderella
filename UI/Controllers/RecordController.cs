using AutoMapper;
using BusinessLogic.DAL;
using BusinessLogic.Models;
using BusinessLogic.Repositories;
using BusinessLogic.Services;
using System.Collections.Generic;
using System.Web.Mvc;
using UI.Models;

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
            var viewModel = new List<RecordViewModel>();
            var recordList = _service.GetAll();
            Mapper.Map(recordList, viewModel);
            return View(viewModel);
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

                return RedirectToAction(MVC.Record.Index());
            }
            return View(MVC.Record.Views.Edit, model);
        }
    }
}