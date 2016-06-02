﻿using BusinessLogic.Components.CrudComponents;
using BusinessLogic.Models;
using BusinessLogic.Repositories;
using BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Services
{
	public class AlbumService : IAlbumService
	{
		private readonly IRepository<Album> _repository;
		private readonly GetEntityListComponent _getEntityListComponent;
		private readonly AddEntityComponent _addEntityComponent;
		private readonly GetEntityByIDComponent _getEntityByIDComponent;
		private readonly EditEntityComponent _editEntityComponent;
		private readonly DeleteEntityComponent _deleteEntityComponent;

		public AlbumService(IUnitOfWork uow)
		{
			_repository = uow.GetRepository<Album>();
			_getEntityListComponent = new GetEntityListComponent();
			_addEntityComponent = new AddEntityComponent();
			_getEntityByIDComponent = new GetEntityByIDComponent();
			_editEntityComponent = new EditEntityComponent();
			_deleteEntityComponent = new DeleteEntityComponent();
		}

		public void Add(Album album)
		{
			var existingAlbum = _repository.GetAll().Where(x => x.UserID == album.UserID && x.AlbumName == album.AlbumName && x.Artist == album.Artist && x.MediaType == album.MediaType).ToList();
			if (existingAlbum.Count > 0)
				throw new ApplicationException($"An existing album of {album.Artist}, {album.AlbumName}, {album.MediaType} already exists.");
			_addEntityComponent.Execute(_repository, album);
		}

		//TODO: probably should split this up into separate methods
		public List<Album> GetAll(string userID = "", string query = "", int numToTake = 0, int? pageNum = 1 /*bool sortAscending, string sortPreference*/)
		{
			var albumList = _getEntityListComponent.Execute(_repository).OrderBy(x => x.Artist).ThenBy(y => y.AlbumName).ToList();

			if (!string.IsNullOrWhiteSpace(userID))
				albumList = albumList.Where(x => x.UserID == userID).ToList();

			if (!string.IsNullOrWhiteSpace(query))
			{
				var currentList = new List<Album>();
				currentList.AddRange(albumList);
				albumList = currentList.Where(x =>
							 x.Artist.Equals(query, StringComparison.InvariantCultureIgnoreCase) ||
							 x.AlbumName.Equals(query, StringComparison.InvariantCultureIgnoreCase)).ToList();
				var partialMatches = currentList.Where(x => x.Artist.IndexOf(query, StringComparison.InvariantCultureIgnoreCase) != -1 || x.AlbumName.IndexOf(query, StringComparison.InvariantCultureIgnoreCase) != -1).ToList();
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

		public void Edit(int id, Album album) =>
			_editEntityComponent.Execute(_repository, album);

		public void Delete(int id, string userID) =>
			_deleteEntityComponent.Execute(_repository, id, userID);

		public int GetCount() => _repository.GetCount();
	}
}