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
		private const int NUM_BOOKS_TO_GET = 25;

		public BookController(IBookService service, IGoogleBookService googleBookService)
		{
			_service = service;
			_googleBookService = googleBookService;
		}

		[HttpGet]
		public virtual ActionResult Index(string query, int? pageNum = 1)
		{
			var viewModel = new BookViewModel
			{
				ViewTitle = "Index",
				Books = _service.GetAll(User.Identity.GetUserId(), query, NUM_BOOKS_TO_GET, pageNum.GetValueOrDefault()),
				PageSize = NUM_BOOKS_TO_GET,
				TotalBooks = _service.GetCount()
			};
			var pages = Math.Ceiling((double)viewModel.TotalBooks / viewModel.PageSize);
			viewModel.PageCount = (int)pages;

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

			if (model.UserID != User.Identity.GetUserId())
			{
				ShowStatusMessage(MessageTypeEnum.warning, "This book cannot be edited by another user.", "Edit Failure");
				return RedirectToAction(MVC.Book.Index());
			}

			return View(model);
		}

		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult Edit(Book book)
		{
			if (!ModelState.IsValid) return View(book);
			var existingBooks = _service.GetAll(User.Identity.GetUserId());
			if (existingBooks.Count > 0 && existingBooks.Any(x => x.ID != book.ID && x.Title == book.Title && x.Author == book.Author && x.Media == book.Media))
			{
				ShowStatusMessage(MessageTypeEnum.error, $"A book of Title: {book.Title}, Author: {book.Author}, Media Type: {book.Media} already exists.", "Duplicate Book");
				return View(book);
			}
			//--TODO: why is id needed?
			//TODO: make sure user id is the same so as not to change other users data
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
			if (!string.IsNullOrWhiteSpace(searchModel.Author) || !string.IsNullOrWhiteSpace(searchModel.Title))
			{
				//TODO: change this to local variable
				var result = new List<Volume>();
				var response = _googleBookService.Search(searchModel.Author, searchModel.Title)?.Items;
				if (response != null)
					result = (List<Volume>)response;

				searchModel.Volumes = new List<Book>();

				//TODO: move this to service
				if (result.Count > 0)
				{
					foreach (var volume in result)
					{
						searchModel.Volumes.Add(new Book
						{
							GoogleBookID = volume.Id,
							UserID = User.Identity.GetUserId(),
							Title = volume.VolumeInfo.Title,
							Author = volume.VolumeInfo.Authors == null ? string.Empty : string.Join(", ", volume.VolumeInfo.Authors),
							YearReleased =
								string.IsNullOrWhiteSpace(volume.VolumeInfo.PublishedDate)
									? 0
									: Convert.ToInt32(volume.VolumeInfo.PublishedDate.Substring(0, 4)),
							Publisher = volume.VolumeInfo.Publisher ?? string.Empty,
							Genre = volume.VolumeInfo.Categories == null ? string.Empty : string.Join(", ", volume.VolumeInfo.Categories),
							ISBN10 = volume.VolumeInfo.IndustryIdentifiers?.SingleOrDefault(x => x.Type == "ISBN_10")?.Identifier,
							ISBN13 = volume.VolumeInfo.IndustryIdentifiers?.SingleOrDefault(x => x.Type == "ISBN_13")?.Identifier,
							Language = volume.VolumeInfo.Language,
							ImageUrl = volume.VolumeInfo.ImageLinks == null ? string.Empty : (volume.VolumeInfo?.ImageLinks?.Thumbnail)
						});
					}
				}
			}

			ViewBag.Title = "Book Search";
			return View(searchModel);
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult CreateFromSearchModel(string id)
		{
			ViewBag.Title = "Create";
			var book = _googleBookService.SearchByID(id);

			book.UserID = User.Identity.GetUserId();
			Session["BookResult"] = book;

			return RedirectToAction(MVC.Book.Create());
		}
	}
}