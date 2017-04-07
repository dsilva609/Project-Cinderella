using BusinessLogic.Components.CrudComponents;
using BusinessLogic.Models;
using BusinessLogic.Models.DiscogsModels;
using BusinessLogic.Models.Interfaces;
using BusinessLogic.Repositories;
using BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IUserContext _user;
        private readonly IRepository<Album> _repository;
        private readonly IRepository<Tracklist> _tracksRepository;
        private readonly GetEntityListComponent _getEntityListComponent;
        private readonly AddEntityComponent _addEntityComponent;
        private readonly GetEntityByIDComponent _getEntityByIDComponent;
        private readonly EditEntityComponent _editEntityComponent;
        private readonly EditEntityListComponent _editEntityListComponent;
        private readonly DeleteEntityComponent _deleteEntityComponent;

        public AlbumService(IUnitOfWork uow, IUserContext user)
        {
            _user = user;
            _repository = uow.GetRepository<Album>();
            _tracksRepository = uow.GetRepository<Tracklist>();
            _getEntityListComponent = new GetEntityListComponent();
            _addEntityComponent = new AddEntityComponent();
            _getEntityByIDComponent = new GetEntityByIDComponent();
            _editEntityComponent = new EditEntityComponent();
            _editEntityListComponent = new EditEntityListComponent();
            _deleteEntityComponent = new DeleteEntityComponent();
        }

        public void Add(Album album)
        {
            var existingAlbum =
                _repository.GetAll()
                    .Where(
                        x =>
                            x.UserID == album.UserID && x.Title == album.Title && x.Artist == album.Artist && x.MediaType == album.MediaType &&
                            x.DiscogsID == album.DiscogsID)
                    .ToList();
            if (existingAlbum.Any())
                throw new ApplicationException($"An existing album of {album.Artist}, {album.Title}, {album.MediaType} already exists.");
            _addEntityComponent.Execute(_repository, album);
        }

        public List<Album> GetAll(string userID = "", string query = "", int numToTake = 0, int? pageNum = 1
            /*bool sortAscending, string sortPreference*/)
        {
            var albumList = new List<Album>();

            albumList = _getEntityListComponent.Execute(_repository).OrderBy(x => x.Artist).ThenBy(y => y.Title).ToList();

            if (!string.IsNullOrWhiteSpace(userID))
                albumList = albumList.Where(x => x.UserID == userID).ToList();

            if (!string.IsNullOrWhiteSpace(query))
            {
                var currentList = new List<Album>();
                currentList.AddRange(albumList);
                albumList = currentList.Where(x =>
                    x.Artist.Equals(query, StringComparison.InvariantCultureIgnoreCase) ||
                    x.Title.Equals(query, StringComparison.InvariantCultureIgnoreCase)).ToList();
                var partialMatches =
                    currentList.Where(
                        x =>
                            x.Artist.IndexOf(query, StringComparison.InvariantCultureIgnoreCase) != -1 ||
                            x.Title.IndexOf(query, StringComparison.InvariantCultureIgnoreCase) != -1).ToList();
                albumList = albumList.Concat(partialMatches).Distinct().ToList();
            }

            if (numToTake > 0)
                albumList = albumList.Skip(numToTake * (pageNum.GetValueOrDefault() - 1)).Take(numToTake).ToList();
            //if (sortPreference == "Name")
            //{
            //    if (sortAscending)
            //        cardList = cardList.OrderBy(x => x.Name).ToList();
            //    else
            //        cardList = cardList.OrderByDescending(x => x.Name).ToList();
            //}
            //else if (sortPreference == "Rank")
            //{
            //    if (sortAscending)
            //        cardList = cardList.OrderBy(x => x.Rank).ToList();
            //    else
            //        cardList = cardList.OrderByDescending(x => x.Rank).ToList();
            //}

            return albumList;
        }

        public Album GetByID(int id, string userID) =>
            _getEntityByIDComponent.Execute(_repository, id, userID);

        public void Edit(Album album)
        {
            _editEntityComponent.Execute(_repository, album);
            //if (album.Tracklist.Count > 0)
            //	_editEntityListComponent.Execute(_tracksRepository, album.Tracklist);
        }

        public void Delete(int id, string userID) =>
            _deleteEntityComponent.Execute(_repository, id, userID);

        public int GetCount() => _repository.GetCount();

        public int GetHighestQueueRank(string userID)
        {
            var albums = GetAll(userID).Where(x => x.IsQueued).OrderByDescending(y => y.QueueRank).ToList();

            return !albums.Any() ? 0 : albums.FirstOrDefault().QueueRank;
        }
    }
}