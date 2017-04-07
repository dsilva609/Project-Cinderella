using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Models.Interfaces;
using BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public partial class WishController : ProjectCinderellaControllerBase
    {
        private readonly IUserContext _user;
        private readonly IWishService _service;
        private const int NUM_WISHES_TO_GET = 25;

        public WishController(IUserContext user, IWishService service)
        {
            _user = user;
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public virtual ActionResult Index(string wishQuery, string filter, int? page)
        {
            if (string.IsNullOrWhiteSpace(wishQuery) && !string.IsNullOrWhiteSpace(Session["query"]?.ToString()))
            {
                wishQuery = Session["query"].ToString();
                Session["query"] = string.Empty;
            }
            ViewBag.Filter = (string.IsNullOrWhiteSpace(wishQuery) ? filter : wishQuery)?.Trim();

            var wishes = _service.GetAll(_user.GetUserID(), ViewBag.Filter) as List<Wish>;

            var viewModel = new WishViewModel
            {
                ViewTitle = "Wish List",
                AlbumWishes = wishes?.Where(x => x.ItemType == ItemType.Album)
                    .ToList()
                    ?
                    .GroupBy(y => y.Category)
                    ?.ToDictionary(d => string.IsNullOrWhiteSpace(d.Key) ? string.Empty : d.Key, d => d.ToList()),
                BookWishes = wishes?.Where(x => x.ItemType == ItemType.Book)
                    .ToList()
                    ?
                    .GroupBy(y => y.Category)
                    ?.ToDictionary(d => string.IsNullOrWhiteSpace(d.Key) ? string.Empty : d.Key, d => d.ToList()),
                MovieWishes = wishes?.Where(x => x.ItemType == ItemType.Movie)
                    .ToList()
                    ?
                    .GroupBy(y => y.Category)
                    ?.ToDictionary(d => string.IsNullOrWhiteSpace(d.Key) ? string.Empty : d.Key, d => d.ToList()),
                GameWishes = wishes?.Where(x => x.ItemType == ItemType.Game)
                    .ToList()
                    ?
                    .GroupBy(y => y.Category)
                    ?.ToDictionary(d => string.IsNullOrWhiteSpace(d.Key) ? string.Empty : d.Key, d => d.ToList()),
                PopWishes = wishes?.Where(x => x.ItemType == ItemType.Pop)
                    .ToList()
                    ?
                    .GroupBy(y => y.Category)
                    ?.ToDictionary(d => string.IsNullOrWhiteSpace(d.Key) ? string.Empty : d.Key, d => d.ToList()),
                PageSize = NUM_WISHES_TO_GET
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpGet]
        public virtual ActionResult Create()
        {
            var model = new WishFormModel
            {
                Wish = new Wish { UserID = _user.GetUserID() },
                Categories =
                    new SelectList(
                        _service.GetAll(_user.GetUserID())
                            .OrderBy(z => z.ItemType)
                            .GroupBy(x => new { x.ItemType, x.Category })
                            .Select(y => y.First()), "Category", "Category", "ItemType", string.Empty, string.Empty,
                        _service.GetAll(_user.GetUserID()).Where(x => string.IsNullOrWhiteSpace(x.Category)).ToList())
            };
            ViewBag.Title = "Create";

            return View(model);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult Create(WishFormModel model)
        {
            //TODO: need to do user checks
            if (ModelState.IsValid)
            {
                try
                {
                    model.Wish.DateAdded = DateTime.UtcNow;
                    this._service.Add(model.Wish);
                }
                catch (Exception e)
                {
                    ShowStatusMessage(MessageTypeEnum.error, e.Message, "Duplicate Wish");
                    return View(model);
                }

                ShowStatusMessage(MessageTypeEnum.success, "New Wish Added Successfully.", "Add Successful");
                return RedirectToAction(MVC.Wish.Index());
            }

            model.Categories =
                new SelectList(
                    _service.GetAll(_user.GetUserID())
                        .OrderBy(z => z.ItemType)
                        .GroupBy(x => new { x.ItemType, x.Category })
                        .Select(y => y.First()), "Category", "Category", "ItemType", string.Empty, string.Empty,
                    _service.GetAll(_user.GetUserID()).Where(x => string.IsNullOrWhiteSpace(x.Category)).ToList());
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public virtual ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit";

            var wish = _service.GetByID(id, _user.GetUserID());

            if (wish.UserID != _user.GetUserID())
            {
                ShowStatusMessage(MessageTypeEnum.warning, "This wish cannot be edited by another user.", "Edit Failure");
                return RedirectToAction(MVC.Wish.Index());
            }
            var model = new WishFormModel
            {
                Categories =
                    new SelectList(
                        _service.GetAll(_user.GetUserID())
                            .OrderBy(z => z.ItemType)
                            .GroupBy(x => new { x.ItemType, x.Category })
                            .Select(y => y.First()), "Category", "Category", "ItemType", string.Empty, string.Empty,
                        _service.GetAll(_user.GetUserID()).Where(x => string.IsNullOrWhiteSpace(x.Category)).ToList()),
                //_service.GetAll(_user.GetUserID()).Where(x => !string.IsNullOrWhiteSpace(x.Category)).Select(y => new SelectListItem
                //{
                //	Group = new SelectListGroup { Name = y.ItemType.ToString() },
                //	Text = y.Category,
                //	Value = y.Category,
                //	Selected = wish.Category == y.Category
                //}).OrderBy(z => z.Group.Name).ToList(),
                Wish = wish
            };

            return View(model);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult Edit(WishFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories =
                    new SelectList(
                        _service.GetAll(_user.GetUserID())
                            .OrderBy(z => z.ItemType)
                            .GroupBy(x => new { x.ItemType, x.Category })
                            .Select(y => y.First()), "Category", "Category", "ItemType", string.Empty, string.Empty,
                        _service.GetAll(_user.GetUserID()).Where(x => string.IsNullOrWhiteSpace(x.Category)).ToList());

                return View(model);
            }
            var existingWishes = _service.GetAll(_user.GetUserID());

            if (existingWishes.Any(x => x.ID != model.Wish.ID && x.Title == model.Wish.Title && x.ItemType == model.Wish.ItemType))
            {
                ShowStatusMessage(MessageTypeEnum.error,
                    $"An wish of Title: {model.Wish.Title} and Type: {model.Wish.ItemType.ToString()} already exists.",
                    "Duplicate Record");
                model.Categories =
                    new SelectList(
                        _service.GetAll(_user.GetUserID())
                            .OrderBy(z => z.ItemType)
                            .GroupBy(x => new { x.ItemType, x.Category })
                            .Select(y => y.First()), "Category", "Category", "ItemType", string.Empty, string.Empty,
                        _service.GetAll(_user.GetUserID()).Where(x => string.IsNullOrWhiteSpace(x.Category)).ToList());
                return View(model);
            }

            //TODO: make sure user id is the same so as not to change other users data
            if (model.Wish.UserID != _user.GetUserID())
            {
                ShowStatusMessage(MessageTypeEnum.warning, "This wish cannot be edited by another user.", "Edit Failure");
                return RedirectToAction(MVC.Wish.Index());
            }

            model.Wish.DateModified = DateTime.UtcNow;
            _service.Edit(model.Wish);

            ShowStatusMessage(MessageTypeEnum.success, "Wish updated.", "Update Successful");
            return RedirectToAction(MVC.Wish.Index());
        }

        [HttpGet]
        [Authorize]
        public virtual ActionResult Details(int id)
        {
            var model = _service.GetByID(id, _user.GetUserID());

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public virtual ActionResult Delete(int id)
        {
            var model = _service.GetByID(id, _user.GetUserID());
            if (model.UserID != _user.GetUserID())
            {
                ShowStatusMessage(MessageTypeEnum.error, "This wish cannot be deleted by another user", "Delete Failure");
                return RedirectToAction(MVC.Wish.Index());
            }

            _service.Delete(id, _user.GetUserID());

            ShowStatusMessage(MessageTypeEnum.success, string.Empty, "Wish Deleted Successfully");
            return RedirectToAction(MVC.Wish.Index());
        }

        [Authorize]
        [HttpGet]
        public virtual ActionResult FinishWish(int id)
        {
            var model = _service.GetByID(id, _user.GetUserID());
            if (model.UserID != _user.GetUserID())
            {
                ShowStatusMessage(MessageTypeEnum.error, "This wish cannot be edited by another user", "Edit Failure");
                return RedirectToAction(MVC.Wish.Index());
            }
            model.Owned = true;
            model.DateModified = DateTime.UtcNow;

            _service.Edit(model);

            ShowStatusMessage(MessageTypeEnum.success, string.Empty, "Wish Completed");
            return RedirectToAction(MVC.Wish.Index());
        }

        [Authorize]
        [HttpGet]
        public virtual ActionResult Search(int id)
        {
            var model = _service.GetByID(id, _user.GetUserID());
            Session["wish"] = model.Title;
            Session["wishID"] = model.ID;

            return RedirectToAction("Search", model.ItemType.ToString());
        }
    }
}