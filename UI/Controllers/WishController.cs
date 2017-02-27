using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNet.Identity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public partial class WishController : ProjectCinderellaControllerBase
    {
        private readonly IWishService _service;
        private const int NUM_WISHES_TO_GET = 25;

        public WishController(IWishService service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual ActionResult Index(string wishQuery, string filter, int? page)
        {
            if (string.IsNullOrWhiteSpace(wishQuery) && !string.IsNullOrWhiteSpace(Session["query"]?.ToString()))
            {
                wishQuery = Session["query"].ToString();
                Session["query"] = string.Empty;
            }
            ViewBag.Filter = (string.IsNullOrWhiteSpace(wishQuery) ? filter : wishQuery)?.Trim();

            var wishes = _service.GetAll(User.Identity.GetUserId(), ViewBag.Filter) as List<Wish>;

            var viewModel = new WishViewModel
            {
                ViewTitle = "Index",
                Wishes = wishes?.ToPagedList(page ?? 1, NUM_WISHES_TO_GET),
                PageSize = NUM_WISHES_TO_GET
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpGet]
        public virtual ActionResult Create()
        {
            var model = new Wish { UserID = User.Identity.GetUserId() };
            ViewBag.Title = "Create";

            return View(model);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult Create(Wish model)
        {
            //TODO: need to do user checks
            if (ModelState.IsValid)
            {
                try
                {
                    model.DateAdded = DateTime.UtcNow;
                    this._service.Add(model);
                }
                catch (Exception e)
                {
                    ShowStatusMessage(MessageTypeEnum.error, e.Message, "Duplicate Wish");
                    return View(model);
                }

                ShowStatusMessage(MessageTypeEnum.success, "New Wish Added Successfully.", "Add Successful");
                return RedirectToAction(MVC.Wish.Index());
            }
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public virtual ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit";
            var model = _service.GetByID(id, User.Identity.GetUserId());

            if (model.UserID != User.Identity.GetUserId())
            {
                ShowStatusMessage(MessageTypeEnum.warning, "This wish cannot be edited by another user.", "Edit Failure");
                return RedirectToAction(MVC.Wish.Index());
            }

            return View(model);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult Edit(Wish model)
        {
            if (!ModelState.IsValid) return View(model);
            var existingWishes = _service.GetAll(User.Identity.GetUserId());
            //TODO: update this to just use an Any() call
            if (existingWishes.Count > 0 && existingWishes.Any(x => x.ID != model.ID && x.Title == model.Title && x.ItemType == model.ItemType))
            {
                ShowStatusMessage(MessageTypeEnum.error, $"An wish of Title: {model.Title} and Type: {model.ItemType.ToString()} already exists.",
                    "Duplicate Record");
                return View(model);
            }

            //TODO: make sure user id is the same so as not to change other users data
            if (model.UserID != User.Identity.GetUserId())
            {
                ShowStatusMessage(MessageTypeEnum.warning, "This wish cannot be edited by another user.", "Edit Failure");
                return RedirectToAction(MVC.Wish.Index());
            }

            model.DateModified = DateTime.UtcNow;
            _service.Edit(model);

            ShowStatusMessage(MessageTypeEnum.success, "Wish updated.", "Update Successful");
            return RedirectToAction(MVC.Wish.Index());
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
            var model = _service.GetByID(id, User.Identity.GetUserId());
            if (model.UserID != User.Identity.GetUserId())
            {
                ShowStatusMessage(MessageTypeEnum.error, "This wish cannot be deleted by another user", "Delete Failure");
                return RedirectToAction(MVC.Wish.Index());
            }

            _service.Delete(id, User.Identity.GetUserId());

            ShowStatusMessage(MessageTypeEnum.success, string.Empty, "Wish Deleted Successfully");
            return RedirectToAction(MVC.Wish.Index());
        }
    }
}