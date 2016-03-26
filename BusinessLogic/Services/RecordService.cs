using BusinessLogic.Components.CrudComponents;
using BusinessLogic.Models;
using BusinessLogic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Services
{
	public class RecordService
	{
		private readonly IRepository<RecordModel> _repository;
		private readonly GetEntityListComponent _getEntityListComponent;
		private readonly AddEntityComponent _addEntityComponent;
		private readonly GetEntityByIDComponent _getEntityByIDComponent;
		private readonly EditEntityComponent _editEntityComponent;
		private readonly DeleteEntityComponent _deleteEntityComponent;

		public RecordService(IUnitOfWork uow)
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
			var existingRecord = this._repository.GetAll().Where(x => x.AlbumName == record.AlbumName && x.Artist == record.Artist && x.MediaType == record.MediaType).ToList();
			if (existingRecord.Count > 0)
				throw new ApplicationException($"An existing record of {record.Artist}, {record.AlbumName}, {record.MediaType} already exists.");
			this._addEntityComponent.Execute(this._repository, record);
		}

		public List<RecordModel> GetAll( /*bool sortAscending, string sortPreference*/)
		{
			var recordList = this._getEntityListComponent.Execute(this._repository);

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

		public RecordModel GetByID(int id) =>
			this._getEntityByIDComponent.Execute(this._repository, id);

		public void Edit(int id, RecordModel record) =>
			this._editEntityComponent.Execute(this._repository, record);

		public void Delete(int id) =>
			this._deleteEntityComponent.Execute(this._repository, id);
	}
}