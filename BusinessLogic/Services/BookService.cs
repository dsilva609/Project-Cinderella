using BusinessLogic.Components.CrudComponents;
using BusinessLogic.Models;
using BusinessLogic.Repositories;
using BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Services
{
	public class BookService : IBookService
	{
		private readonly IRepository<Book> _repository;
		private readonly GetEntityListComponent _getEntityListComponent;
		private readonly AddEntityComponent _addEntityComponent;
		private readonly GetEntityByIDComponent _getEntityByIDComponent;
		private readonly EditEntityComponent _editEntityComponent;
		private readonly DeleteEntityComponent _deleteEntityComponent;

		public BookService(IUnitOfWork uow)
		{
			_repository = uow.GetRepository<Book>();
			_getEntityListComponent = new GetEntityListComponent();
			_addEntityComponent = new AddEntityComponent();
			_getEntityByIDComponent = new GetEntityByIDComponent();
			_editEntityComponent = new EditEntityComponent();
			_deleteEntityComponent = new DeleteEntityComponent();
		}

		public void Add(Book book)
		{
			var existingBook = _repository.GetAll().Where(x => x.UserID == book.UserID && x.Title == book.Title && x.Author == book.Author && x.Media == book.Media).ToList();
			if (existingBook.Count > 0)
				throw new ApplicationException($"An existing book of {book.Title}, {book.Author}, {book.Media} already exists.");
			_addEntityComponent.Execute(_repository, book);
		}

		public List<Book> GetAll(string userID = "")
		{
			var bookList = _getEntityListComponent.Execute(_repository);

			if (!string.IsNullOrWhiteSpace(userID))
				bookList = bookList.Where(x => x.UserID == userID).ToList();

			bookList = bookList.OrderBy(x => x.Title).ToList();

			return bookList;
		}

		public Book GetByID(int id, string userID) => _getEntityByIDComponent.Execute(_repository, id, userID);

		public void Edit(int id, Book book) => _editEntityComponent.Execute(_repository, book);

		public void Delete(int id, string userID) => _deleteEntityComponent.Execute(_repository, id, userID);

		public int GetCount() => _repository.GetCount();
	}
}