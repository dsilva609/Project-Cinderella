using AutoMapper;
using BusinessLogic.DAL;
using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Repositories;
using BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
	public partial class RecordController : ProjectCinderellaControllerBase
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
				try
				{
					this._service.Add(model);
				}
				catch (Exception e)
				{
					ShowStatusMessage(MessageTypeEnum.error, e.Message, "Duplicate Record");
					return View(MVC.Record.Views.Edit, model);
				}

				return RedirectToAction(MVC.Record.Index());
			}
			return View(MVC.Record.Views.Edit, model);
		}

		//	[Authorize(Roles = "Admin")]
		[HttpGet]
		public virtual ActionResult Delete(int id)
		{
			_service.Delete(id);

			return RedirectToAction(MVC.Record.Index());
		}
	}
}