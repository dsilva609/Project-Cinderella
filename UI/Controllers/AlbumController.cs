﻿using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNet.Identity;
using System;
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
		public virtual ActionResult Index(string query, int? pageNum = 1)
		{
			var viewModel = new AlbumViewModel
			{
				ViewTitle = "Index",
				Albums = _service.GetAll(User.Identity.GetUserId(), query, NUM_ALBUMS_TO_GET, pageNum.GetValueOrDefault()),
				PageSize = NUM_ALBUMS_TO_GET,
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

			var model = new Album
			{
				UserID = User.Identity.GetUserId(),
				Artist = release.artists.First().name,
				AlbumName = release.title,
				AlbumYear = release.year,
				RecordLabel = release.LabelString,
				Genre = release.GenreString,
				DiscogsID = release.id,
				ImageUrl = release.images?.First().uri
			};

			ViewBag.Title = "Create";

			//TODO: is this still needed?
			Session["albumResult"] = model;

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

			return View(model);
		}

		[Authorize]
		[HttpPost]
		public virtual ActionResult Edit(Album model)
		{
			if (ModelState.IsValid)
			{
				var existingAlbums = _service.GetAll(User.Identity.GetUserId()).Where(x => x.ID != model.ID && x.Artist == model.Artist && x.AlbumName == model.AlbumName && x.MediaType == model.MediaType).ToList();
				if (existingAlbums.Count > 0)
				{
					ShowStatusMessage(MessageTypeEnum.error, $"An album of Artist: {model.Artist}, Album: {model.AlbumName}, Media Type: {model.MediaType} already exists.", "Duplicate Record");
					return View(model);
				}
				//--TODO: why is id needed?
				//TODO: make sure user id is the same so as not to change other users data
				model.DateUpdated = DateTime.Now;
				_service.Edit(model.ID, model);

				ShowStatusMessage(MessageTypeEnum.success, $"Album of Artist: {model.Artist}, Album: {model.AlbumName}, Media Type: {model.MediaType} updated.", "Update Successful");
				return RedirectToAction(MVC.Album.Index());
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

			ShowStatusMessage(MessageTypeEnum.success, "", "Album Deleted Successfully");
			return RedirectToAction(MVC.Album.Index());
		}

		//TODO: add tests and validation
		[Authorize]
		[HttpGet]
		public virtual ActionResult Search(DiscogsSearchModel searchModel)
		{
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