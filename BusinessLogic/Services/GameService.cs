﻿using BusinessLogic.Components.CrudComponents;
using BusinessLogic.Models;
using BusinessLogic.Repositories;
using BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Services
{
	public class GameService : IGameService
	{
		private readonly IRepository<Game> _repository;
		private readonly GetEntityListComponent _getEntityListComponent;
		private readonly AddEntityComponent _addEntityComponent;
		private readonly GetEntityByIDComponent _getEntityByIDComponent;
		private readonly EditEntityComponent _editEntityComponent;
		private readonly DeleteEntityComponent _deleteEntityComponent;

		public GameService(IUnitOfWork uow)
		{
			_repository = uow.GetRepository<Game>();
			_getEntityListComponent = new GetEntityListComponent();
			_addEntityComponent = new AddEntityComponent();
			_getEntityByIDComponent = new GetEntityByIDComponent();
			_editEntityComponent = new EditEntityComponent();
			_deleteEntityComponent = new DeleteEntityComponent();
		}

		public void Add(Game game)
		{
			var existingGame = _repository.GetAll().Where(x => x.UserID == game.UserID && x.Title == game.Title && x.MediaType == game.MediaType).ToList();
			if (existingGame.Count > 0)
				throw new ApplicationException($"An existing game of {game.Title}, {game.MediaType} already exists.");
			_addEntityComponent.Execute(_repository, game);
		}

		public List<Game> GetAll(string userID = "", string query = "", int numToTake = 0, int? pageNum = 1)
		{
			var gameList = _getEntityListComponent.Execute(_repository);

			if (!string.IsNullOrWhiteSpace(userID))
				gameList = gameList.Where(x => x.UserID == userID).ToList();

			if (numToTake > 0)
				gameList = gameList.Skip(numToTake * (pageNum.GetValueOrDefault() - 1)).Take(numToTake).ToList();

			return gameList;
		}

		public Game GetByID(int id, string userID) => _getEntityByIDComponent.Execute(_repository, id, userID);

		public void Edit(int id, Game game) => _editEntityComponent.Execute(_repository, game);

		public void Delete(int id, string userID) => _deleteEntityComponent.Execute(_repository, id, userID);

		public int GetCount() => _repository.GetCount();
	}
}