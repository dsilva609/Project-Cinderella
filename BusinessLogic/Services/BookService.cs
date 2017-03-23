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
			var existingBook = _repository.GetAll().Where(x => x.UserID == book.UserID && x.Title == book.Title && x.Author == book.Author).ToList();
			if (existingBook.Count > 0)
				throw new ApplicationException($"An existing book of {book.Title}, {book.Author} already exists.");
			_addEntityComponent.Execute(_repository, book);
		}

		public List<Book> GetAll(string userID = "", string query = "", int numToTake = 0, int? pageNum = 1)
		{
			var bookList = _getEntityListComponent.Execute(_repository).OrderBy(x => x.Author).ThenBy(x => x.Title).ToList();

			if (!string.IsNullOrWhiteSpace(userID))
				bookList = bookList.Where(x => x.UserID == userID).ToList();

			if (!string.IsNullOrWhiteSpace(query))
			{
				var currentList = new List<Book>();
				currentList.AddRange(bookList);
				bookList = currentList.Where(x =>
					x.Title.Equals(query, StringComparison.InvariantCultureIgnoreCase) ||
					x.Author.Equals(query, StringComparison.InvariantCultureIgnoreCase)).ToList();
				var partialMatches = currentList.Where(x => x.Title.IndexOf(query, StringComparison.InvariantCultureIgnoreCase) != -1 || x.Author.IndexOf(query, StringComparison.InvariantCultureIgnoreCase) != -1).ToList();
				bookList = bookList.Concat(partialMatches).Distinct().ToList();
			}

			if (numToTake > 0)
				bookList = bookList.Skip(numToTake * (pageNum.GetValueOrDefault() - 1)).Take(numToTake).ToList();

			return bookList;
		}

		public Book GetByID(int id, string userID) => _getEntityByIDComponent.Execute(_repository, id, userID);

		public void Edit(Book book) => _editEntityComponent.Execute(_repository, book);

		public void Delete(int id, string userID) => _deleteEntityComponent.Execute(_repository, id, userID);

		public int GetCount() => _repository.GetCount();

		public int GetHighestQueueRank(string userId)
		{
			var books = GetAll(userId).Where(x => x.IsQueued).OrderByDescending(y => y.QueueRank).ToList();

			return books.Any() ? books.FirstOrDefault().QueueRank : 0;
		}
	}
}