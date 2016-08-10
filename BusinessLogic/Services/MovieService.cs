using BusinessLogic.Components.CrudComponents;
using BusinessLogic.Models;
using BusinessLogic.Repositories;
using BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Services
{
	public class MovieService : IMovieService
	{
		private readonly IRepository<Movie> _repository;
		private readonly GetEntityListComponent _getEntityListComponent;
		private readonly AddEntityComponent _addEntityComponent;
		private readonly GetEntityByIDComponent _getEntityByIDComponent;
		private readonly EditEntityComponent _editEntityComponent;
		private readonly DeleteEntityComponent _deleteEntityComponent;

		public MovieService(IUnitOfWork uow)
		{
			_repository = uow.GetRepository<Movie>();
			_getEntityListComponent = new GetEntityListComponent();
			_addEntityComponent = new AddEntityComponent();
			_getEntityByIDComponent = new GetEntityByIDComponent();
			_editEntityComponent = new EditEntityComponent();
			_deleteEntityComponent = new DeleteEntityComponent();
		}

		public void Add(Movie movie)
		{
			var existingMovie = _repository.GetAll().Where(x => x.UserID == movie.UserID && x.Title == movie.Title && x.Type == movie.Type).ToList();
			if (existingMovie.Count > 0)
				throw new ApplicationException($"An existing movie of {movie.Title}, {movie.Type} already exists.");
			_addEntityComponent.Execute(_repository, movie);
		}

		public List<Movie> GetAll(string userID = "", string query = "", int numToTake = 0, int? pageNum = 1)
		{
			var movieList = _getEntityListComponent.Execute(_repository);

			if (!string.IsNullOrWhiteSpace(userID))
				movieList = movieList.Where(x => x.UserID == userID).ToList();

			if (numToTake > 0)
				movieList = movieList.Skip(numToTake * (pageNum.GetValueOrDefault() - 1)).Take(numToTake).ToList();

			return movieList;
		}

		public Movie GetByID(int id, string userID) => _getEntityByIDComponent.Execute(_repository, id, userID);

		public void Edit(int id, Movie movie) => _editEntityComponent.Execute(_repository, movie);

		public void Delete(int id, string userID) => _deleteEntityComponent.Execute(_repository, id, userID);

		public int GetCount() => _repository.GetCount();
	}
}