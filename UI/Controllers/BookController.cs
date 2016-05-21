using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using Google.Apis.Books.v1.Data;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
	public partial class BookController : ProjectCinderellaControllerBase
	{
		private readonly IBookService _service;
		private readonly IGoogleBookService _googleBookService;
		private List<Volume> result;

		public BookController(IBookService service, IGoogleBookService googleBookService)
		{
			_service = service;
			_googleBookService = googleBookService;
		}

		[HttpGet]
		public virtual ActionResult Index(string query, int pageNum = 1)
		{
			var viewModel = new BookViewModel
			{
				ViewTitle = "Index",
				Books = _service.GetAll(User.Identity.GetUserId())
				//, query, NUM_RECORDS_TO_GET, pageNum.GetValueOrDefault()),
				//PageSize = NUM_RECORDS_TO_GET,
				//TotalBooks = _service.GetCount()
			};
			//var pages = Math.Ceiling((double)viewModel.TotalRecords / viewModel.PageSize);
			//viewModel.PageCount = (int)pages;
			return View(viewModel);
		}

		[HttpGet]
		public virtual ActionResult Details(int id)
		{
			ViewBag.Title = "Details";
			var model = _service.GetByID(id, User.Identity.GetUserId());

			return View(model);
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Create()
		{
			ViewBag.Title = "Create";
			var model = Session["BookResult"] ?? new Book { UserID = User.Identity.GetUserId() };
			Session["BookResult"] = null;

			return View(model);
		}

		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult Create(Book book)
		{
			book.UserID = User.Identity.GetUserId();
			if (!ModelState.IsValid) return View(book);
			try
			{
				book.DateAdded = DateTime.Now;
				this._service.Add(book);
			}
			catch (Exception e)
			{
				ShowStatusMessage(MessageTypeEnum.error, e.Message, "Duplicate Book");
				return View(book);
			}
			ShowStatusMessage(MessageTypeEnum.success, "New Book Added Successfully.", "Add Successful");
			return RedirectToAction(MVC.Book.Index());
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
		[ValidateAntiForgeryToken]
		public virtual ActionResult Edit(Book book)
		{
			if (!ModelState.IsValid) return View(book);
			var existingBook = _service.GetAll(User.Identity.GetUserId()).Where(x => x.ID != book.ID && x.Title == book.Title && x.Author == book.Author && x.Media == book.Media).ToList();
			if (existingBook.Count > 0)
			{
				ShowStatusMessage(MessageTypeEnum.error, $"A book of Title: {book.Title}, Author: {book.Author}, Media Type: {book.Media} already exists.", "Duplicate Book");
				return View(book);
			}
			//--TODO: why is id needed?
			//TODO: make sure user id is the same so as not to change other users data
			book.UserID = User.Identity.GetUserId();
			book.DateUpdated = DateTime.Now;
			_service.Edit(book.ID, book);

			ShowStatusMessage(MessageTypeEnum.success, $"Book of Title {book.Title}, Author: {book.Author}, Media Type: {book.Media} updated.", "Update Successful");
			return RedirectToAction(MVC.Book.Index());
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Delete(int id)
		{
			_service.Delete(id, User.Identity.GetUserId());

			ShowStatusMessage(MessageTypeEnum.success, "", "Book Deleted Successfully");

			return RedirectToAction(MVC.Book.Index());
		}

		//TODO: add tests and validation
		[Authorize]
		[HttpGet]
		public virtual ActionResult Search(GoogleBooksSearchModel searchModel)
		{
			if (searchModel == null)
				searchModel = new GoogleBooksSearchModel();
			if (!string.IsNullOrWhiteSpace(searchModel.Author) && !string.IsNullOrWhiteSpace(searchModel.Title))
			{
				//model.Artist = artist;
				//model.AlbumName = album;
				//TODO: change this to local variable
				result = new List<Volume>();
				result = (List<Volume>)_googleBookService.Search(searchModel.Author, searchModel.Title)?.Items;

				searchModel.Volumes = new List<Book>();

				if (result?.Count > 0)
					foreach (var volume in result)
					{
						searchModel.Volumes.Add(new Book
						{
							UserID = User.Identity.GetUserId(),
							//ID = Convert.ToInt32(x.VolumeInfo.IndustryIdentifiers.First().Identifier),
							Title = volume.VolumeInfo.Title,
							Author = string.Join(", ", volume.VolumeInfo.Authors),
							YearPublished = string.IsNullOrWhiteSpace(volume.VolumeInfo.PublishedDate) ? 0 : Convert.ToInt32(volume.VolumeInfo.PublishedDate.Substring(0, 4)),
							Publisher = volume.VolumeInfo.Publisher
						});
					}
			}
			ViewBag.Title = "Book Search";
			return View(searchModel);
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult CreateFromSearchModel(Book book)
		{
			//var model = new Book
			//{
			//	UserID = User.Identity.GetUserId(),
			//	Author = string.Join(", ", volume.VolumeInfo.Authors.ToString()),
			//	Title = volume.VolumeInfo.Title,
			//	YearPublished = DateTime.Parse(volume.VolumeInfo.PublishedDate).Year,
			//	Publisher = volume.VolumeInfo.Publisher,
			//	//Genre = volume.SearchInfo.GenreString
			//};

			ViewBag.Title = "Create";

			//TODO: is this still needed?
			Session["BookResult"] = book;

			return RedirectToAction(MVC.Book.Create());
		}
	}
}