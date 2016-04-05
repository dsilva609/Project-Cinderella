using AutoMapper;
using BusinessLogic.DAL;
using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Repositories;
using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public partial class RecordController : ProjectCinderellaControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IRecordService _service;
        private const int NUM_RECORDS_TO_GET = 2;

        //--TODO: needs Dependency injection
        public RecordController()
        {
            _uow = new UnitOfWork<ProjectCinderellaContext>();
            _service = new RecordService(_uow);
        }

        [HttpGet]
        public virtual ActionResult Index(int? pageNum = 1)
        {
            var viewModel = new List<RecordViewModel>();
            var recordList = _service.GetAll(NUM_RECORDS_TO_GET, pageNum.GetValueOrDefault());
            Mapper.Map(recordList, viewModel);
            return View(viewModel);
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            var model = new RecordModel();
            ViewBag.Title = "Create";

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(RecordModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
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

        [HttpGet]
        public virtual ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit";
            var model = _service.GetByID(id);

            return View(model);
        }

        [HttpPost]
        public virtual ActionResult Edit(RecordModel model)
        {
            if (ModelState.IsValid)
            {
                var existingRecord = _service.GetAll().Where(x => x.ID != model.ID && x.Artist == model.Artist && x.AlbumName == model.AlbumName && x.MediaType == model.MediaType).ToList();
                if (existingRecord.Count > 0)
                {
                    ShowStatusMessage(MessageTypeEnum.error, $"A record of Artist: {model.Artist}, Album: {model.AlbumName}, Media Type: {model.MediaType} already exists.", "Duplicate Record");
                    return View(model);
                }
                //--TODO: why is id needed?
                _service.Edit(model.ID, model);

                ShowStatusMessage(MessageTypeEnum.success, $"Record of Artist: {model.Artist}, Album: {model.AlbumName}, Media Type: {model.MediaType} updated.", "Update Successful");
                return RedirectToAction(MVC.Record.Index());
            }
            return View(model);
        }

        [HttpGet]
        public virtual ActionResult Details(int id)
        {
            var model = _service.GetByID(id);

            return View(model);
        }

        //	[Authorize(Roles = "Admin")]
        [HttpGet]
        public virtual ActionResult Delete(int id)
        {
            _service.Delete(id);

            ShowStatusMessage(MessageTypeEnum.success, "", "Delete Successful");
            return RedirectToAction(MVC.Record.Index());
        }
    }
}