using System;
using System.Collections.Generic;
using System.Linq;
using ProjectCinderella.BusinessLogic.Services.Interfaces;
using ProjectCinderella.Data.Components.CrudComponents;
using ProjectCinderella.Data.Repositories;
using ProjectCinderella.Model.Common;
using ProjectCinderella.Model.Interfaces;

namespace ProjectCinderella.BusinessLogic.Services
{
    public class GameService : IGameService
    {
        private readonly IUserContext _user;
        private readonly IRepository<Game> _repository;
        private readonly GetEntityListComponent _getEntityListComponent;
        private readonly AddEntityComponent _addEntityComponent;
        private readonly GetEntityByIDComponent _getEntityByIDComponent;
        private readonly EditEntityComponent _editEntityComponent;
        private readonly DeleteEntityComponent _deleteEntityComponent;

        public GameService(IUnitOfWork uow, IUserContext user)
        {
            _user = user;
            _repository = uow.GetRepository<Game>();
            _getEntityListComponent = new GetEntityListComponent();
            _addEntityComponent = new AddEntityComponent();
            _getEntityByIDComponent = new GetEntityByIDComponent();
            _editEntityComponent = new EditEntityComponent();
            _deleteEntityComponent = new DeleteEntityComponent();
        }

        public void Add(Game game)
        {
            var existingGame = _repository.GetAll().Where(x => x.UserID == game.UserID && x.Title == game.Title).ToList();
            if (existingGame.Count > 0)
                throw new ApplicationException($"An existing game of {game.Title} already exists.");
            _addEntityComponent.Execute(_repository, game);
        }

        public List<Game> GetAll(string userID = "", string query = "", int numToTake = 0, int? pageNum = 1)
        {
            var gameList = _getEntityListComponent.Execute(_repository).OrderBy(x => x.Title).ThenBy(x => x.Developer).ToList();

            if (!string.IsNullOrWhiteSpace(userID))
                gameList = gameList.Where(x => x.UserID == userID).ToList();

            if (!string.IsNullOrWhiteSpace(query))
            {
                var currentList = new List<Game>();
                currentList.AddRange(gameList);
                gameList = currentList.Where(x =>
                    x.Title.Equals(query, StringComparison.InvariantCultureIgnoreCase) ||
                    x.Developer.Equals(query, StringComparison.InvariantCultureIgnoreCase)).ToList();
                var partialMatches = currentList.Where(x =>
                    x.Title.IndexOf(query, StringComparison.InvariantCultureIgnoreCase) != -1 ||
                    x.Developer.IndexOf(query, StringComparison.InvariantCultureIgnoreCase) != -1).ToList();
                gameList = gameList.Concat(partialMatches).Distinct().ToList();
            }

            if (numToTake > 0)
                gameList = gameList.Skip(numToTake * (pageNum.GetValueOrDefault() - 1)).Take(numToTake).ToList();

            return gameList;
        }

        public Game GetByID(int id, string userID) => _getEntityByIDComponent.Execute(_repository, id, userID);

        public void Edit(Game game) => _editEntityComponent.Execute(_repository, game);

        public void Delete(int id, string userID) => _deleteEntityComponent.Execute(_repository, id, userID);

        public int GetCount() => _repository.GetCount();

        public int GetHighestQueueRank(string userID)
        {
            var games = GetAll(userID).Where(x => x.IsQueued).OrderByDescending(y => y.QueueRank).ToList();

            return games.Any() ? games.FirstOrDefault().QueueRank : 0;
        }
    }
}