﻿using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Models.Interfaces;
using BusinessLogic.Services.Interfaces;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
	public partial class PopController : ProjectCinderellaControllerBase
	{
		private readonly IUserContext _user;
		private readonly IPopService _service;
		private readonly IWishService _wishService;
		private const int NUM_POPS_TO_GET = 25;

		public PopController(IUserContext user, IPopService service, IWishService wishService)
		{
			_user = user;
			_service = service;
			_wishService = wishService;
		}

		[HttpGet]
		public virtual ActionResult Index(string popQuery, string filter, int? page)
		{
			if (string.IsNullOrWhiteSpace(popQuery) && !string.IsNullOrWhiteSpace(Session["pop-Query"]?.ToString()))
			{
				popQuery = Session["pop-Query"].ToString();
				Session["pop-Query"] = string.Empty;
			}
			ViewBag.Filter = (string.IsNullOrWhiteSpace(popQuery) ? filter : popQuery)?.Trim();

			var pops = _service.GetAll(string.Empty, ViewBag.Filter) as List<FunkoModel>;

			var viewModel = new PopViewModel
			{
				ViewTitle = "Pops",
				Pops = pops?.ToPagedList(page ?? 1, NUM_POPS_TO_GET),
				PageSize = NUM_POPS_TO_GET
			};

			return View(viewModel);
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Create()
		{
			var model = new FunkoModel { UserID = _user.GetUserID(), UserNum = _user.GetUserNum() };
			ViewBag.Title = "Create";

			return View(model);
		}

		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult Create(FunkoModel model)
		{
			//TODO: need to do user checks
			if (!ModelState.IsValid) return View(model);
			try
			{
				model.DateAdded = DateTime.UtcNow;
				_service.Add(model);
			}
			catch (Exception e)
			{
				ShowStatusMessage(MessageTypeEnum.error, e.Message, "Duplicate Pop");
				return View(model);
			}

			if (!string.IsNullOrWhiteSpace(Session["popWish"]?.ToString()))
			{
				_wishService.Delete(Convert.ToInt32(Session["popWishID"].ToString()), _user.GetUserID());
				Session["popWish"] = null;
				Session["popWishID"] = null;
				ShowStatusMessage(MessageTypeEnum.info, "Wish list has been updated", "Wish list");
			}
			ShowStatusMessage(MessageTypeEnum.success, "New Pop Added Successfully.", "Add Successful");
			return RedirectToAction(MVC.Pop.Index());
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Edit(int id)
		{
			var model = _service.GetByID(id, _user.GetUserID());
			ViewBag.Title = $"Edit - {model.Title}";
			if (model.UserID != _user.GetUserID()) return RedirectToAction(MVC.Pop.Details(model.ID));

			return View(model);
		}

		[Authorize]
		[HttpPost]
		public virtual ActionResult Edit(FunkoModel model)
		{
			if (!ModelState.IsValid) return View(model);
			var existingFunkoModels = _service.GetAll(_user.GetUserID());
			if (existingFunkoModels.Any(x => x.ID != model.ID && x.Title == model.Title && x.Series == model.Series && x.Number == model.Number))
			{
				ShowStatusMessage(MessageTypeEnum.error,
					$"A Pop of Name: {model.Title}, Series: {model.Series}, Line: {model.PopLine} already exists.", "Duplicate Pop");
				return View(model);
			}

			//TODO: make sure user id is the same so as not to change other users data
			model.DateUpdated = DateTime.UtcNow;
			_service.Edit(model);

			ShowStatusMessage(MessageTypeEnum.success,
				$"Pop of Name: {model.Title}, Series: {model.Series}, Line: {model.PopLine} updated.", "Update Successful");
			return RedirectToAction(MVC.Pop.Index());
		}

		[HttpGet]
		public virtual ActionResult Details(int id)
		{
			var model = _service.GetByID(id, _user.GetUserID());
			ViewBag.Title = $"Details - {model.Title}";
			return View(model);
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Delete(int id)
		{
			var model = _service.GetByID(id, _user.GetUserID());
			if (model.UserID != _user.GetUserID())
			{
				ShowStatusMessage(MessageTypeEnum.error, "This pop cannot be deleted by another user", "Delete Failure");
				return RedirectToAction(MVC.Pop.Index());
			}

			_service.Delete(id, _user.GetUserID());

			ShowStatusMessage(MessageTypeEnum.success, "", "Pop Deleted Successfully");
			return RedirectToAction(MVC.Pop.Index());
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public virtual ActionResult AddToShowcase(int id)
		{
			var pop = _service.GetByID(id, _user.GetUserID());

			if (pop.UserID != _user.GetUserID())
			{
				ShowStatusMessage(MessageTypeEnum.warning, "This pop cannot be edited by another user.", "Edit Failure");
				return RedirectToAction(MVC.Showcase.Index(_user.GetUserNum()));
			}

			pop.IsShowcased = true;
			pop.DateUpdated = DateTime.UtcNow;

			_service.Edit(pop);

			ShowStatusMessage(MessageTypeEnum.info, "Pop added to showcase", "Showcase");
			return RedirectToAction(MVC.Showcase.Index(_user.GetUserNum()));
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public virtual ActionResult RemoveFromShowcase(int id)
		{
			var pop = _service.GetByID(id, _user.GetUserID());
			pop.IsShowcased = false;
			pop.DateUpdated = DateTime.UtcNow;

			_service.Edit(pop);

			ShowStatusMessage(MessageTypeEnum.info, "Pop removed from showcase", "Showcase");
			return RedirectToAction(MVC.Showcase.Index());
		}
	}
}