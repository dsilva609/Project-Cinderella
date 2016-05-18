using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Models.DiscogsModels;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
	public partial class AlbumController : ProjectCinderellaControllerBase
	{
		private readonly IAlbumService _service;
		private const int NUM_RECORDS_TO_GET = 25;
		private string test;
		private List<DiscogsResult> results;

		public AlbumController(IAlbumService service)
		{
			_service = service;
			test = SearchDiscogs();
			results = JsonConvert.DeserializeObject<List<DiscogsResult>>(test);
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
			var result = test;
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
		public virtual ActionResult Edit(RecordModel model)
		{
			if (ModelState.IsValid)
			{
				var existingRecord = _service.GetAll(User.Identity.GetUserId()).Where(x => x.ID != model.ID && x.Artist == model.Artist && x.AlbumName == model.AlbumName && x.MediaType == model.MediaType).ToList();
				if (existingRecord.Count > 0)
				{
					ShowStatusMessage(MessageTypeEnum.error, $"An album of Artist: {model.Artist}, Album: {model.AlbumName}, Media Type: {model.MediaType} already exists.", "Duplicate Record");
					return View(model);
				}
				//--TODO: why is id needed?
				//TODO: make sure user id is the same so as not to change other users data
				model.UserID = User.Identity.GetUserId();
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

		private string SearchDiscogs()
		{
			var client = new HttpClient();

			client.BaseAddress = new Uri("https://api.discogs.com/");
			client.DefaultRequestHeaders.Add("Authorization", "Discogs token=VihLsjGHOaqfiRLhNZMZydxTWUTcidbHkuZgCALD");
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			client.DefaultRequestHeaders.Add("User-Agent", "Project-Cinderella/1.0 +projectcinderella.azurewebsites.net");
			var response = client.GetAsync("database/search?q=dio&type=artist");
			var result = JObject.Parse(response.Result.Content.ReadAsStringAsync().Result);
			//	if (result.IsSuccessStatusCode)
			//{
			return result["results"].ToString();
			//}
		}
	}
}