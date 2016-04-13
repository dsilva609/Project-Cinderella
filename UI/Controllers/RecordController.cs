using BusinessLogic.DAL;
using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Repositories;
using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public partial class RecordController : ProjectCinderellaControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IRecordService _service;
        private const int NUM_RECORDS_TO_GET = 25;

        //--TODO: needs Dependency injection
        public RecordController()
        {
            _uow = new UnitOfWork<ProjectCinderellaContext>();
            _service = new RecordService(_uow);
        }

        [HttpGet]
        public virtual ActionResult Index(string query, int? pageNum = 1)
        {
            var viewModel = new RecordViewModel
            {
                ViewTitle = "Index",
                Records = _service.GetAll(User.Identity.GetUserId(), query, NUM_RECORDS_TO_GET, pageNum.GetValueOrDefault()),
                PageSize = NUM_RECORDS_TO_GET,
                TotalRecords = _service.GetCount()
            };
            var pages = Math.Ceiling((double)viewModel.TotalRecords / viewModel.PageSize);
            viewModel.PageCount = (int)pages;
            return View(viewModel);
        }

        [Authorize]
        [HttpGet]
        public virtual ActionResult Create()
        {
            var model = new RecordModel { UserID = User.Identity.GetUserId() };
            ViewBag.Title = "Create";

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(RecordModel model)
        {//TODO: need to do user checks
            model.UserID = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                try
                {
                    model.DateAdded = DateTime.Now;
                    this._service.Add(model);
                }
                catch (Exception e)
                {
                    ShowStatusMessage(MessageTypeEnum.error, e.Message, "Duplicate Record");
                    return View(model);
                }
                ShowStatusMessage(MessageTypeEnum.success, "New Record Added Successfully.", "Add Successful");
                return RedirectToAction(MVC.Record.Index());
            }
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public virtual ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit";
            var model = _service.GetByID(id, User.Identity.GetUserId());

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public virtual ActionResult Edit(RecordModel model)
        {
            if (ModelState.IsValid)
            {
                var existingRecord = _service.GetAll(User.Identity.GetUserId()).Where(x => x.ID != model.ID && x.Artist == model.Artist && x.AlbumName == model.AlbumName && x.MediaType == model.MediaType).ToList();
                if (existingRecord.Count > 0)
                {
                    ShowStatusMessage(MessageTypeEnum.error, $"A record of Artist: {model.Artist}, Album: {model.AlbumName}, Media Type: {model.MediaType} already exists.", "Duplicate Record");
                    return View(model);
                }
                //--TODO: why is id needed?
                //TODO: make sure user id is the same so as not to change other users data
                model.UserID = User.Identity.GetUserId();
                model.DateUpdated = DateTime.Now;
                _service.Edit(model.ID, model);

                ShowStatusMessage(MessageTypeEnum.success, $"Record of Artist: {model.Artist}, Album: {model.AlbumName}, Media Type: {model.MediaType} updated.", "Update Successful");
                return RedirectToAction(MVC.Record.Index());
            }
            return View(model);
        }

        [HttpGet]
        public virtual ActionResult Details(int id)
        {
            var model = _service.GetByID(id, User.Identity.GetUserId());

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public virtual ActionResult Delete(int id)
        {
            _service.Delete(id, User.Identity.GetUserId());

            ShowStatusMessage(MessageTypeEnum.success, "", "Delete Successful");
            return RedirectToAction(MVC.Record.Index());
        }
    }
}