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
    public partial class AlbumController : ProjectCinderellaControllerBase
    {
        private readonly IAlbumService _service;
        private readonly IDiscogsService _discogsService;
        private const int NUM_ALBUMS_TO_GET = 25;

        public AlbumController(IAlbumService service, IDiscogsService discogsService)
        {
            _service = service;
            _discogsService = discogsService;
        }

        [HttpGet]
        public virtual ActionResult Index(string albumQuery, string filter, int? page)
        {
            if (string.IsNullOrWhiteSpace(albumQuery) && !string.IsNullOrWhiteSpace(Session["query"]?.ToString()))
            {
                albumQuery = Session["query"].ToString();
                Session["query"] = string.Empty;
            }
            ViewBag.Filter = string.IsNullOrWhiteSpace(albumQuery) ? filter : albumQuery;

            var viewModel = new AlbumViewModel
            {
                ViewTitle = "Index",
                Albums = (_service.GetAll(User.Identity.GetUserId(), ViewBag.Filter) as List<Album>).ToPagedList(page ?? 1, NUM_ALBUMS_TO_GET),
                PageSize = NUM_ALBUMS_TO_GET
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpGet]
        public virtual ActionResult Create()
        {
            var model = Session["albumResult"] ?? new Album { UserID = User.Identity.GetUserId() };
            ViewBag.Title = "Create";
            Session["albumResult"] = null;

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public virtual ActionResult CreateFromSearchResult(int releaseID)
        {
            var release = _discogsService.GetRelease(releaseID);

            release.UserID = User.Identity.GetUserId();

            ViewBag.Title = "Create";

            Session["albumResult"] = release;

            return RedirectToAction(MVC.Album.Create());
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(Album model)
        {
            //TODO: need to do user checks
            if (ModelState.IsValid)
            {
                try
                {
                    model.DateAdded = DateTime.Now;
                    this._service.Add(model);
                }
                catch (Exception e)
                {
                    ShowStatusMessage(MessageTypeEnum.error, e.Message, "Duplicate Album");
                    return View(model);
                }
                ShowStatusMessage(MessageTypeEnum.success, "New Album Added Successfully.", "Add Successful");
                return RedirectToAction(MVC.Album.Index());
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
                ShowStatusMessage(MessageTypeEnum.warning, "This album cannot be edited by another user.", "Edit Failure");
                return RedirectToAction(MVC.Album.Index());
            }

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public virtual ActionResult Update(int id)
        {
            var model = _service.GetByID(id, User.Identity.GetUserId());

            //TODO--check if id exists
            if (model.DiscogsID == 0)
            {
                ShowStatusMessage(MessageTypeEnum.error, "No ID found to update.", "Missing ID");
                return RedirectToAction(MVC.Album.Edit(id));
            }
            var release = _discogsService.GetRelease(model.DiscogsID);

            //TODO: does this have to be here?
            model.Artist = release.Artist;
            model.Title = release.Title;
            model.YearReleased = release.YearReleased;
            model.RecordLabel = release.RecordLabel;
            model.Genre = release.Genre;
            if (string.IsNullOrWhiteSpace(model.ImageUrl))
                model.ImageUrl = release.ImageUrl;
            //model.Tracklist = release.Tracklist;
            //model.Tracklist.ForEach(x => x.AlbumID = model.ID);

            return View(MVC.Album.Views.Edit, model);
        }

        [Authorize]
        [HttpPost]
        public virtual ActionResult Edit(Album model)
        {
            if (!ModelState.IsValid) return View(model);
            var existingAlbums = _service.GetAll(User.Identity.GetUserId());
            if (existingAlbums.Count > 0 && existingAlbums.Any(x => x.ID != model.ID && x.Artist == model.Artist && x.Title == model.Title
                                                                    && x.MediaType == model.MediaType && x.DiscogsID == model.DiscogsID))
            {
                ShowStatusMessage(MessageTypeEnum.error,
                    $"An album of Artist: {model.Artist}, Album: {model.Title}, Media Type: {model.MediaType} already exists.", "Duplicate Record");
                return View(model);
            }

            //TODO: make sure user id is the same so as not to change other users data
            model.DateUpdated = DateTime.Now;
            _service.Edit(model);

            ShowStatusMessage(MessageTypeEnum.success,
                $"Album of Artist: {model.Artist}, Album: {model.Title}, Media Type: {model.MediaType} updated.", "Update Successful");
            return RedirectToAction(MVC.Album.Index());
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
                ShowStatusMessage(MessageTypeEnum.error, "This album cannot be deleted by another user", "Delete Failure");
                return RedirectToAction(MVC.Album.Index());
            }

            _service.Delete(id, User.Identity.GetUserId());

            ShowStatusMessage(MessageTypeEnum.success, "", "Album Deleted Successfully");
            return RedirectToAction(MVC.Album.Index());
        }

        //TODO: add tests and validation
        [Authorize]
        [HttpGet]
        public virtual ActionResult Search(DiscogsSearchModel searchModel)
        {
            if (Request.UrlReferrer?.LocalPath == "/Album/Search" && string.IsNullOrWhiteSpace(searchModel.Artist) &&
                string.IsNullOrWhiteSpace(searchModel.AlbumName))
            {
                ShowStatusMessage(MessageTypeEnum.error, "Please enter search terms.", "Search Error");
                return View(searchModel);
            }

            if (!string.IsNullOrWhiteSpace(searchModel.Artist) || !string.IsNullOrWhiteSpace(searchModel.AlbumName))
            {
                searchModel.Results = _discogsService.Search(searchModel.Artist, searchModel.AlbumName);
                searchModel.Results = searchModel.Results.OrderByDescending(x => x.Year).ToList();
            }
            ViewBag.Title = "Album Search";
            return View(searchModel);
        }
    }
}