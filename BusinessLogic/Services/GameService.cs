using BusinessLogic.Components.CrudComponents;
using BusinessLogic.Models;
using BusinessLogic.Repositories;
using BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;

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
			throw new NotImplementedException();
		}

		public List<Game> GetAll(string userID = "", string query = "")
		{
			throw new NotImplementedException();
		}

		public Game GetByID(int id, string userID)
		{
			throw new NotImplementedException();
		}

		public void Edit(int id, Game game)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id, string userID)
		{
			throw new NotImplementedException();
		}

		public int GetCount()
		{
			throw new NotImplementedException();
		}
	}
}