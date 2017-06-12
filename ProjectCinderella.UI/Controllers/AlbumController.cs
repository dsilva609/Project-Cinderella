using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PagedList;
using ProjectCinderella.Model.Interfaces;
using ProjectCinderella.BusinessLogic.Services.Interfaces;
using ProjectCinderella.Model.Enums;
using ProjectCinderella.Model.Common;
using ProjectCinderella.Model.UI;
using System.Linq;

namespace ProjectCinderella.UI.Controllers
{
	public class AlbumController : ProjectCinderellaControllerBase
	{
		private readonly IUserContext _user;
		private readonly IAlbumService _service;
		private readonly IDiscogsService _discogsService;
		private readonly IWishService _wishService;
		private const int NUM_ALBUMS_TO_GET = 25;

		public AlbumController(IUserContext user, IAlbumService service, IDiscogsService discogsService, IWishService wishService)
		{
			_user = user;
			_service = service;
			_discogsService = discogsService;
			_wishService = wishService;
		}

		[HttpGet]
		public virtual ActionResult Index(string albumQuery, string filter, int? page)
		{
			if (string.IsNullOrWhiteSpace(albumQuery) && !string.IsNullOrWhiteSpace(HttpContext.Session.GetString("album-query")))
			{
				albumQuery = HttpContext.Session.GetString("album-query");
				HttpContext.Session.SetString("album-query", string.Empty);
			}
			ViewBag.Filter = (string.IsNullOrWhiteSpace(albumQuery) ? filter : albumQuery)?.Trim();

			var albums = _service.GetAll(string.Empty, ViewBag.Filter) as List<Album>;

			var viewModel = new AlbumViewModel
			{
				ViewTitle = "Albums",
				Albums = albums?.ToPagedList(page ?? 1, NUM_ALBUMS_TO_GET),
				PageSize = NUM_ALBUMS_TO_GET
			};

			return View(viewModel);
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Create()
		{
			var albumResultStr = HttpContext.Session.GetString("albumResult");
			var model = string.IsNullOrWhiteSpace(albumResultStr) ? new Album { UserID = _user.GetUserID(), UserNum = _user.GetUserNum() }: JsonConvert.DeserializeObject<Album>(albumResultStr);
			ViewBag.Title = "Create";
			HttpContext.Session.Set("albumResult", null);

			return View(model);
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult CreateFromSearchResult(int releaseID)
		{
			var release = _discogsService.GetRelease(releaseID);

			release.UserID = _user.GetUserID();
			release.UserNum = _user.GetUserNum();

			ViewBag.Title = "Create";

			HttpContext.Session.SetString("albumResult", JsonConvert.SerializeObject(release));

			return RedirectToAction("Create", "Album");
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
					if (model.CompletionStatus == ProjectCinderella.Model.Enums.CompletionStatus.Completed && model.TimesCompleted == 0)
						model.TimesCompleted = 1;
					model.DateAdded = DateTime.UtcNow;
					SetTimeStamps(model);
					this._service.Add(model);
				}
				catch (Exception e)
				{
					ShowStatusMessage(MessageTypeEnum.error, e.Message, "Duplicate Album");
					return View(model);
				}
				HttpContext.Session.Set("album-query",null);

				if (!string.IsNullOrWhiteSpace(HttpContext.Session.GetString("wish")))
				{
					_wishService.Delete(Convert.ToInt32(HttpContext.Session.GetString("wishID")), _user.GetUserID());
					HttpContext.Session.Set("wish", null);
					HttpContext.Session.Set("wishID", null);
					ShowStatusMessage(MessageTypeEnum.info, "Wish list has been updated", "Wish list");
				}
				ShowStatusMessage(MessageTypeEnum.success, "New Album Added Successfully.", "Add Successful");
				return RedirectToAction("Index", "Album");
			}
			return View(model);
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Edit(int id)
		{
			var model = _service.GetByID(id, _user.GetUserID());
			ViewBag.Title = $"Edit - {model.Title}";
			if (model.UserID != _user.GetUserID()) return RedirectToAction("Details", "Album",(object) model.ID);

			return View(model);
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Update(int id)
		{
			var model = _service.GetByID(id, _user.GetUserID());
			if (model.UserID != _user.GetUserID()) return RedirectToAction("Details", "Album",(object) model.ID);

			//TODO--check if id exists
			if (model.DiscogsID == 0)
			{
				ShowStatusMessage(MessageTypeEnum.error, "No ID found to update.", "Missing ID");
				return RedirectToAction("Edit", "Album", id);
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

			return View("Edit", model);
		}

		[Authorize]
		[HttpPost]
		public virtual ActionResult Edit(Album model)
		{
			if (!ModelState.IsValid) return View(model);
			var existingAlbums = _service.GetAll(_user.GetUserID());
			//TODO: update this to just use an Any() call
			if (existingAlbums.Count > 0 && existingAlbums.Any(x => x.ID != model.ID && x.Artist == model.Artist && x.Title == model.Title
																	&& x.MediaType == model.MediaType && x.DiscogsID == model.DiscogsID))
			{
				ShowStatusMessage(MessageTypeEnum.error,
					$"An album of Artist: {model.Artist}, Album: {model.Title}, Media Type: {model.MediaType} already exists.", "Duplicate Record");
				return View(model);
			}

			if (model.CompletionStatus == ProjectCinderella.Model.Enums.CompletionStatus.Completed && model.TimesCompleted == 0) model.TimesCompleted = 1;
			if (model.TimesCompleted > 0) model.CompletionStatus = ProjectCinderella.Model.Enums.CompletionStatus.Completed;
			SetTimeStamps(model);
			//TODO: make sure user id is the same so as not to change other users data
			model.DateUpdated = DateTime.UtcNow;

			_service.Edit(model);

			UpdateGenreAndStatus(model.ID);

			ShowStatusMessage(MessageTypeEnum.success,
				$"Album of Artist: {model.Artist}, Album: {model.Title}, Media Type: {model.MediaType} updated.", "Update Successful");
			return RedirectToAction("Index", "Album");
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
				ShowStatusMessage(MessageTypeEnum.error, "This album cannot be deleted by another user", "Delete Failure");
				return RedirectToAction("Index", "Album");
			}

			_service.Delete(id, _user.GetUserID());

			ShowStatusMessage(MessageTypeEnum.success, "", "Album Deleted Successfully");
			return RedirectToAction("Index", "Album");
		}

		//TODO: add tests and validation
		[Authorize]
		[HttpGet]
		public virtual ActionResult Search(DiscogsSearchModel searchModel)
		{
			if (!string.IsNullOrWhiteSpace(searchModel.Artist)) searchModel.Artist = searchModel.Artist.Trim();
			if (!string.IsNullOrWhiteSpace(searchModel.AlbumName)) searchModel.AlbumName = searchModel.AlbumName.Trim();
			if (!string.IsNullOrWhiteSpace(HttpContext.Session.GetString("album-query"))) searchModel.AlbumName = HttpContext.Session.GetString("album-query");
			if (!string.IsNullOrWhiteSpace(HttpContext.Session.GetString("wish"))) searchModel.AlbumName = HttpContext.Session.GetString("wish");

			//TODO: check for correct value
			if (Request.Path.Value == "/Album/Search" && string.IsNullOrWhiteSpace(searchModel.Artist) &&
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

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public virtual ActionResult AddToShowcase(int id)
		{
			var album = _service.GetByID(id, _user.GetUserID());
			album.IsShowcased = true;
			album.DateUpdated = DateTime.UtcNow;
			_service.Edit(album);

			ShowStatusMessage(MessageTypeEnum.info, "Album added to showcase", "Showcase");
			return RedirectToAction("Index", "Showcase",(object) _user.GetUserNum());
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public virtual ActionResult RemoveFromShowcase(int id)
		{
			var album = _service.GetByID(id, _user.GetUserID());
			album.IsShowcased = false;
			album.DateUpdated = DateTime.UtcNow;
			_service.Edit(album);

			ShowStatusMessage(MessageTypeEnum.info, "Album removed from showcase", "Showcase");
			return RedirectToAction("Index", "Showcase",(object) _user.GetUserNum());
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult IncreaseCompletionCount(int id)
		{
			var album = _service.GetByID(id, _user.GetUserID());

			if (album.UserID != _user.GetUserID())
			{
				ShowStatusMessage(MessageTypeEnum.warning, "This album cannot be edited by another user.", "Edit Failure");
				return RedirectToAction("Index", "Album");
			}

			album.TimesCompleted += 1;
			album.CompletionStatus = ProjectCinderella.Model.Enums.CompletionStatus.Completed;
			album.DateUpdated = DateTime.UtcNow;
			_service.Edit(album);

			ShowStatusMessage(MessageTypeEnum.info, "Album was updated.", "Update");
			return RedirectToAction("Index", "Album");
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult DecreaseCompletionCount(int id)
		{
			var album = _service.GetByID(id, _user.GetUserID());

			if (album.UserID != _user.GetUserID())
			{
				ShowStatusMessage(MessageTypeEnum.warning, "This album cannot be edited by another user.", "Edit Failure");
				return RedirectToAction("Index", "Album");
			}

			if (album.TimesCompleted > 0) album.TimesCompleted -= 1;

			if (album.TimesCompleted == 0) album.CompletionStatus = ProjectCinderella.Model.Enums.CompletionStatus.NotStarted;
			album.DateUpdated = DateTime.UtcNow;
			_service.Edit(album);

			ShowStatusMessage(MessageTypeEnum.info, "Album was updated.", "Update");
			return RedirectToAction("Index", "Album");
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult AddToQueue(int id)
		{
			var album = _service.GetByID(id, _user.GetUserID());

			if (album.UserID != _user.GetUserID())
			{
				ShowStatusMessage(MessageTypeEnum.error, "This album cannot be edited by another user.", "Edit Failure");
				return RedirectToAction("Index", "Album");
			}

			if (album.IsQueued)
			{
				ShowStatusMessage(MessageTypeEnum.warning, "This album is already queued.", "Edit Failure");
				return RedirectToAction("Index", "Album");
			}

			album.IsQueued = true;
			var currentHighestRank = _service.GetHighestQueueRank(_user.GetUserID());
			album.QueueRank = currentHighestRank + 1;

			_service.Edit(album);

			ShowStatusMessage(MessageTypeEnum.info, "Album added to queue", "Queue");
			return RedirectToAction("Index", "Queue");
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult RemoveFromQueue(int id)
		{
			var album = _service.GetByID(id, _user.GetUserID());

			if (album.UserID != _user.GetUserID())
			{
				ShowStatusMessage(MessageTypeEnum.error, "This album cannot be edited by another user.", "Edit Failure");
				return RedirectToAction("Index", "Album");
			}

			album.IsQueued = false;
			album.QueueRank = 0;

			_service.Edit(album);

			ShowStatusMessage(MessageTypeEnum.info, "Album removed from queue,", "Queue");
			return RedirectToAction("Index", "Queue");
		}

		private void UpdateGenreAndStatus(int id)
		{
			var album = _service.GetByID(id, _user.GetUserID());

			if (!string.IsNullOrWhiteSpace(album.Style)) return;
			var origGenre = album.Genre;
			if (string.IsNullOrWhiteSpace(origGenre)) return;
			else
			{
				var firstDashIndex = origGenre.IndexOf('-');
				var firstCommaIndex = origGenre.IndexOf(',');
				var genre = string.Empty;
				var style = string.Empty;

				if (firstDashIndex < firstCommaIndex && firstCommaIndex != -1 && firstDashIndex != -1)
				{
					genre = origGenre.Substring(0, firstDashIndex);
					style = origGenre.Substring(firstDashIndex + 1);
				}
				else if (firstCommaIndex == -1 && firstDashIndex == -1)
				{
					return;
				}
				else if (firstCommaIndex < firstDashIndex && firstCommaIndex != -1)
				{
					genre = origGenre.Substring(0, firstCommaIndex);
					style = origGenre.Substring(firstCommaIndex + 1);
				}
				else if (firstDashIndex > 0 && firstCommaIndex == -1)
				{
					genre = origGenre.Substring(0, firstDashIndex);
					style = origGenre.Substring(firstDashIndex + 1);
				}
				else if (firstCommaIndex > 0 && firstDashIndex == -1)
				{
					genre = origGenre.Substring(0, firstCommaIndex);
					style = origGenre.Substring(firstCommaIndex + 1);
				}
				album.Genre = genre.Trim();
				style = style.TrimStart(',');
				album.Style = style.Trim();
				album.DateUpdated = DateTime.UtcNow;
				_service.Edit(album);
				ShowStatusMessage(MessageTypeEnum.info, $"Updated album genre to: {album.Genre}, style to: {album.Style}", "Update");
			}
		}
	}
}