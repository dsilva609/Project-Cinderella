using BusinessLogic.Components.CrudComponents;
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
		private readonly IRepository<RecordModel> _repository;
		private readonly GetEntityListComponent _getEntityListComponent;
		private readonly AddEntityComponent _addEntityComponent;
		private readonly GetEntityByIDComponent _getEntityByIDComponent;
		private readonly EditEntityComponent _editEntityComponent;
		private readonly DeleteEntityComponent _deleteEntityComponent;

		public AlbumService(IUnitOfWork uow)
		{
			_repository = uow.GetRepository<RecordModel>();
			_getEntityListComponent = new GetEntityListComponent();
			_addEntityComponent = new AddEntityComponent();
			_getEntityByIDComponent = new GetEntityByIDComponent();
			_editEntityComponent = new EditEntityComponent();
			_deleteEntityComponent = new DeleteEntityComponent();
		}

		public void Add(RecordModel record)
		{
			var existingRecord = _repository.GetAll().Where(x => x.UserID == record.UserID && x.AlbumName == record.AlbumName && x.Artist == record.Artist && x.MediaType == record.MediaType).ToList();
			if (existingRecord.Count > 0)
				throw new ApplicationException($"An existing record of {record.Artist}, {record.AlbumName}, {record.MediaType} already exists.");
			_addEntityComponent.Execute(_repository, record);
		}

		//TODO: probably should split this up into separate methods
		public List<RecordModel> GetAll(string userID = "", string query = "", int numToTake = 0, int? pageNum = 1 /*bool sortAscending, string sortPreference*/)
		{
			var recordList = _getEntityListComponent.Execute(_repository).OrderBy(x => x.Artist).ThenBy(y => y.AlbumName).ToList();

			if (!string.IsNullOrWhiteSpace(userID))
				recordList = recordList.Where(x => x.UserID == userID).ToList();

			if (!string.IsNullOrWhiteSpace(query))
				recordList = recordList.Where(x => x.Artist.Equals(query, StringComparison.InvariantCultureIgnoreCase) || x.AlbumName.Equals(query, StringComparison.CurrentCultureIgnoreCase)).ToList();

			if (numToTake > 0)
				recordList = recordList.Skip(numToTake * (pageNum.GetValueOrDefault() - 1)).Take(numToTake).ToList();
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

			return recordList;
		}

		public RecordModel GetByID(int id, string userID) =>
			_getEntityByIDComponent.Execute(_repository, id, userID);

		public void Edit(int id, RecordModel record) =>
			_editEntityComponent.Execute(_repository, record);

		public void Delete(int id, string userID) =>
			_deleteEntityComponent.Execute(_repository, id, userID);

		public int GetCount() => _repository.GetCount();
	}
}