using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PagedList;
using ProjectCinderella.BusinessLogic.Services.Interfaces;
using ProjectCinderella.Model.Interfaces;
using ProjectCinderella.Model.UI;
using System.Linq;
using ProjectCinderella.Model.Enums;
using ProjectCinderella.Model.Common;

namespace ProjectCinderella.Web.Controllers
{
	public class BookController : ProjectCinderellaControllerBase
	{
		private readonly IUserContext _user;
		private readonly IBookService _service;
		private readonly IWishService _wishService;
		private readonly IGoogleBookService _googleBookService;
		private readonly IComicVineService _comicVineService;

		private const int NUM_BOOKS_TO_GET = 25;

		public BookController(IUserContext user, IBookService service, IWishService wishService, IGoogleBookService googleBookService,
			IComicVineService comicVineService)
		{
			_user = user;
			_service = service;
			_wishService = wishService;
			_googleBookService = googleBookService;
			_comicVineService = comicVineService;
		}

		[HttpGet]
		public virtual ActionResult Index(string bookQuery, string filter, int? page)
		{
			if (string.IsNullOrWhiteSpace(bookQuery) && !string.IsNullOrWhiteSpace(HttpContext.Session.GetString("book-query")))
			{
				bookQuery = HttpContext.Session.GetString("book-query");
				HttpContext.Session.SetString("book-query", string.Empty);
			}
			ViewBag.Filter = (string.IsNullOrWhiteSpace(bookQuery) ? filter : bookQuery)?.Trim();
			var books = _service.GetAll(string.Empty, ViewBag.Filter) as List<Book>;
			var viewModel = new BookViewModel
			{
				ViewTitle = "Books",
				Books = books?.ToPagedList(page ?? 1, NUM_BOOKS_TO_GET),
				PageSize = NUM_BOOKS_TO_GET,
			};

			return View(viewModel);
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
		public virtual ActionResult Create()
		{
			ViewBag.Title = "Create";
			var bookResultStr = HttpContext.Session.GetString("BookResult");
			var model =string.IsNullOrWhiteSpace(bookResultStr) ? new Book { UserID = _user.GetUserID(), UserNum = _user.GetUserNum() }: JsonConvert.DeserializeObject<Book>(bookResultStr);
			HttpContext.Session.Set("BookResult", null);

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
				if (book.CompletionStatus == ProjectCinderella.Model.Enums.CompletionStatus.Completed && book.TimesCompleted == 0)
					book.TimesCompleted = 1;
				book.DateAdded = DateTime.UtcNow;
				SetTimeStamps(book);
				_service.Add(book);
			}
			catch (Exception e)
			{
				ShowStatusMessage(MessageTypeEnum.error, e.Message, "Duplicate Book");
				return View(book);
			}
			HttpContext.Session.Set("book-query", null);

			if (!string.IsNullOrWhiteSpace(HttpContext.Session.GetString("wish")))
			{
				_wishService.Delete(Convert.ToInt32(HttpContext.Session.GetString("wishID")), _user.GetUserID());
				HttpContext.Session.Set("wish", null);
				HttpContext.Session.Set("wishID", null);
				ShowStatusMessage(MessageTypeEnum.info, "Wish list has been updated", "Wish list");
			}

			ShowStatusMessage(MessageTypeEnum.success, "New Book Added Successfully.", "Add Successful");
			return RedirectToAction("Index", "Book");
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Edit(int id)
		{
			var model = _service.GetByID(id, _user.GetUserID());
			ViewBag.Title = $"Edit - {model.Title}";
			if (model.UserID != _user.GetUserID()) return RedirectToAction("Details", "Book",(object) model.ID);

			return View(model);
		}

		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult Edit(Book book)
		{
			if (!ModelState.IsValid) return View(book);
			var existingBooks = _service.GetAll(_user.GetUserID());
			if (existingBooks.Count > 0 &&
				existingBooks.Any(x => x.ID != book.ID && x.Title == book.Title && x.Author == book.Author))
			{
				ShowStatusMessage(MessageTypeEnum.error, $"A book of Title: {book.Title}, Author: {book.Author} already exists.", "Duplicate Book");
				return View(book);
			}

			if (book.CompletionStatus == ProjectCinderella.Model.Enums.CompletionStatus.Completed && book.TimesCompleted == 0) book.TimesCompleted = 1;
			if (book.TimesCompleted > 0) book.CompletionStatus = ProjectCinderella.Model.Enums.CompletionStatus.Completed;
			SetTimeStamps(book);

			//TODO: make sure user id is the same so as not to change other users data
			book.DateUpdated = DateTime.UtcNow;
			_service.Edit(book);

			ShowStatusMessage(MessageTypeEnum.success, $"Book of Title {book.Title}, Author: {book.Author}", "Update Successful");
			return RedirectToAction("Index", "Book");
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Delete(int id)
		{
			var model = _service.GetByID(id, _user.GetUserID());
			if (model.UserID != _user.GetUserID())
			{
				ShowStatusMessage(MessageTypeEnum.error, "This book cannot be deleted by another user", "Delete Failure");
				return RedirectToAction("Index", "Book");
			}

			_service.Delete(id, _user.GetUserID());

			ShowStatusMessage(MessageTypeEnum.success, "", "Book Deleted Successfully");

			return RedirectToAction("Index", "Book");
		}

		//TODO: add tests and validation
		[Authorize]
		[HttpGet]
		public virtual ActionResult Search(BookSearchModel searchModel)
		{
			if (!string.IsNullOrWhiteSpace(searchModel.Author)) searchModel.Author = searchModel.Author.Trim();
			if (!string.IsNullOrWhiteSpace(searchModel.Title)) searchModel.Title = searchModel.Title.Trim();
			if (!string.IsNullOrWhiteSpace(HttpContext.Session.GetString("book-query"))) searchModel.Title = HttpContext.Session.GetString("book-query");
			if (!string.IsNullOrWhiteSpace(HttpContext.Session.GetString("wish"))) searchModel.Title = HttpContext.Session.GetString("wish");
			//TODO: check for correct value
			if (Request.Headers["Referer"].ToString().Contains("/Book/Search") && string.IsNullOrWhiteSpace(searchModel.Author) &&
				string.IsNullOrWhiteSpace(searchModel.Title))
			{
				ShowStatusMessage(MessageTypeEnum.error, "Please enter search terms.", "Search Error");
				return View(searchModel);
			}

			if (!string.IsNullOrWhiteSpace(searchModel.Author) || !string.IsNullOrWhiteSpace(searchModel.Title))
				searchModel.Volumes = _googleBookService.Search(searchModel.Author, searchModel.Title);

			//TODO: add author to search
			if (!string.IsNullOrWhiteSpace(searchModel.Title))
				searchModel.ComicsVineResult = _comicVineService.Search(searchModel.Title);

			ViewBag.Title = "Book Search";
			return View(searchModel);
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult CreateFromSearchModel(string id, bool isComic)
		{
			ViewBag.Title = "Create";
			var book = isComic ? _comicVineService.SearchByID(id) : _googleBookService.SearchByID(id);

			book.UserID = _user.GetUserID();
			book.UserNum = _user.GetUserNum();
			HttpContext.Session.SetString("BookResult",JsonConvert.SerializeObject(book));

			return RedirectToAction("Create", "Book");
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public virtual ActionResult AddToShowcase(int id)
		{
			var book = _service.GetByID(id, _user.GetUserID());
			book.IsShowcased = true;
			book.DateUpdated = DateTime.UtcNow;
			_service.Edit(book);

			ShowStatusMessage(MessageTypeEnum.info, "Book added to showcase", "Showcase");
			return RedirectToAction("Index", "Showcase", _user.GetUserNum() as object);
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public virtual ActionResult RemoveFromShowcase(int id)
		{
			var book = _service.GetByID(id, _user.GetUserID());
			book.IsShowcased = false;
			book.DateUpdated = DateTime.UtcNow;
			_service.Edit(book);

			ShowStatusMessage(MessageTypeEnum.info, "Book removed from showcase", "Showcase");
			return RedirectToAction("Index", "Showcase", _user.GetUserNum() as object);
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult IncreaseCompletionCount(int id)
		{
			var book = _service.GetByID(id, _user.GetUserID());

			if (book.UserID != _user.GetUserID())
			{
				ShowStatusMessage(MessageTypeEnum.warning, "This book cannot be edited by another user.", "Edit Failure");
				return RedirectToAction("Index", "Book");
			}

			book.TimesCompleted += 1;
			book.CompletionStatus = ProjectCinderella.Model.Enums.CompletionStatus.Completed;
			book.DateUpdated = DateTime.UtcNow;
			_service.Edit(book);

			ShowStatusMessage(MessageTypeEnum.info, "Book was updated.", "Update");
			return RedirectToAction("Index", "Book");
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult DecreaseCompletionCount(int id)
		{
			var book = _service.GetByID(id, _user.GetUserID());

			if (book.UserID != _user.GetUserID())
			{
				ShowStatusMessage(MessageTypeEnum.warning, "This book cannot be edited by another user.", "Edit Failure");
				return RedirectToAction("Index", "Book");
			}

			if (book.TimesCompleted > 0) book.TimesCompleted -= 1;
			if (book.TimesCompleted == 0) book.CompletionStatus = ProjectCinderella.Model.Enums.CompletionStatus.NotStarted;
			book.DateUpdated = DateTime.UtcNow;
			_service.Edit(book);

			ShowStatusMessage(MessageTypeEnum.info, "Book was updated.", "Update");
			return RedirectToAction("Index", "Book");
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult AddToQueue(int id)
		{
			var book = _service.GetByID(id, _user.GetUserID());

			if (book.UserID != _user.GetUserID())
			{
				ShowStatusMessage(MessageTypeEnum.error, "This book cannot be edited by another user.", "Edit Failure");
				return RedirectToAction("Index", "Book");
			}

			if (book.IsQueued)
			{
				ShowStatusMessage(MessageTypeEnum.warning, "This book is already queued.", "Edit Failure");
				return RedirectToAction("Index", "Book");
			}

			book.IsQueued = true;
			var currentHighestRank = _service.GetHighestQueueRank(_user.GetUserID());
			book.QueueRank = currentHighestRank + 1;

			_service.Edit(book);

			ShowStatusMessage(MessageTypeEnum.info, "Album added to queue", "Queue");
			return RedirectToAction("Index", "Queue");
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult RemoveFromQueue(int id)
		{
			var book = _service.GetByID(id, _user.GetUserID());

			if (book.UserID != _user.GetUserID())
			{
				ShowStatusMessage(MessageTypeEnum.error, "This book cannot be edited by another user.", "Edit Failure");
				return RedirectToAction("Index", "Book");
			}

			book.IsQueued = false;
			book.QueueRank = 0;

			_service.Edit(book);

			ShowStatusMessage(MessageTypeEnum.info, "Book removed from queue,", "Queue");
			return RedirectToAction("Index", "Queue");
		}
	}
}