using BusinessLogic.DAL;
using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace UI.Controllers
{
	public partial class BookController : ProjectCinderellaControllerBase
	{
		private readonly IUnitOfWork _uow;
		//private readonly IBookService _service;

		public BookController()
		{
			_uow = new UnitOfWork<ProjectCinderellaContext>();
			//_service = new BookService(_uow);
		}

		[HttpGet]
		public virtual ActionResult Index(string query, int pageNum = 1)
		{
			return View();
		}

		[HttpGet]
		public virtual ActionResult Details(int id)
		{
			ViewBag.Title = "Details";

			return View();
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Create()
		{
			ViewBag.Title = "Create";
			var model = new Book();

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
				//this._service.Add(book);
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

			return View();
		}

		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult Edit(Book book)
		{
			if (!ModelState.IsValid) return View(book);
			var existingBook = new List<Book>();// _service.GetAll(User.Identity.GetUserId()).Where(x => x.ID != book.ID && x.Title == book.Title && x.Author == book.Author && x.MediaType == book.Media).ToList();
			if (existingBook.Count > 0)
			{
				ShowStatusMessage(MessageTypeEnum.error, $"A book of Title: {book.Title}, Author: {book.Author}, Media Type: {book.Media} already exists.", "Duplicate Record");
				return View(book);
			}
			//--TODO: why is id needed?
			//TODO: make sure user id is the same so as not to change other users data
			book.UserID = User.Identity.GetUserId();
			book.DateUpdated = DateTime.Now;
			//_service.Edit(book.ID, book);

			ShowStatusMessage(MessageTypeEnum.success, $"Book of Title {book.Title}, Author: {book.Author}, Media Type: {book.Media} updated.", "Update Successful");
			return RedirectToAction(MVC.Album.Index());
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Delete(int id)
		{
			//	_service.Delete(id, User.Identity.GetUserId());

			ShowStatusMessage(MessageTypeEnum.success, "", "Delete Successful");

			return RedirectToAction(MVC.Book.Index());
		}
	}
}