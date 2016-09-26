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
    public partial class BookController : ProjectCinderellaControllerBase
    {
        private readonly IBookService _service;
        private readonly IGoogleBookService _googleBookService;
        private readonly IComicVineService _comicVineService;
        private const int NUM_BOOKS_TO_GET = 25;

        public BookController(IBookService service, IGoogleBookService googleBookService, IComicVineService comicVineService)
        {
            _service = service;
            _googleBookService = googleBookService;
            _comicVineService = comicVineService;
        }

        [HttpGet]
        public virtual ActionResult Index(string bookQuery, string filter, int? page)
        {
            if (string.IsNullOrWhiteSpace(bookQuery) && !string.IsNullOrWhiteSpace(Session["query"]?.ToString()))
            {
                bookQuery = Session["query"].ToString();
                Session["query"] = string.Empty;
            }
            ViewBag.Filter = string.IsNullOrWhiteSpace(bookQuery) ? filter : bookQuery;
            var books = _service.GetAll(User.Identity.GetUserId(), ViewBag.Filter) as List<Book>;
            var viewModel = new BookViewModel
            {
                ViewTitle = "Index",
                Books = books?.ToPagedList(page ?? 1, NUM_BOOKS_TO_GET),
                PageSize = NUM_BOOKS_TO_GET,
            };

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
            if (existingBooks.Count > 0 &&
                existingBooks.Any(x => x.ID != book.ID && x.Title == book.Title && x.Author == book.Author))
            {
                ShowStatusMessage(MessageTypeEnum.error, $"A book of Title: {book.Title}, Author: {book.Author} already exists.", "Duplicate Book");
                return View(book);
            }

            //TODO: make sure user id is the same so as not to change other users data
            book.DateUpdated = DateTime.Now;
            _service.Edit(book);

            ShowStatusMessage(MessageTypeEnum.success, $"Book of Title {book.Title}, Author: {book.Author}", "Update Successful");
            return RedirectToAction(MVC.Book.Index());
        }

        [Authorize]
        [HttpGet]
        public virtual ActionResult Delete(int id)
        {
            var model = _service.GetByID(id, User.Identity.GetUserId());
            if (model.UserID != User.Identity.GetUserId())
            {
                ShowStatusMessage(MessageTypeEnum.error, "This book cannot be deleted by another user", "Delete Failure");
                return RedirectToAction(MVC.Book.Index());
            }

            _service.Delete(id, User.Identity.GetUserId());

            ShowStatusMessage(MessageTypeEnum.success, "", "Book Deleted Successfully");

            return RedirectToAction(MVC.Book.Index());
        }

        //TODO: add tests and validation
        [Authorize]
        [HttpGet]
        public virtual ActionResult Search(BookSearchModel searchModel)
        {
            if (Request.UrlReferrer?.LocalPath == "/Book/Search" && string.IsNullOrWhiteSpace(searchModel.Author) &&
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

            book.UserID = User.Identity.GetUserId();
            Session["BookResult"] = book;

            return RedirectToAction(MVC.Book.Create());
        }
    }
}