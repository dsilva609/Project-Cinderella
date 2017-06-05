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
    public class WishService : IWishService
    {
        private readonly IUserContext _user;
        private readonly IRepository<Wish> _repository;
        private readonly GetEntityListComponent _getEntityListComponent;
        private readonly AddEntityComponent _addEntityComponent;
        private readonly GetEntityByIDComponent _getEntityByIDComponent;
        private readonly EditEntityComponent _editEntityComponent;
        private readonly EditEntityListComponent _editEntityListComponent;
        private readonly DeleteEntityComponent _deleteEntityComponent;

        public WishService(IUnitOfWork uow, IUserContext user)
        {
            _user = user;
            _repository = uow.GetRepository<Wish>();
            _getEntityListComponent = new GetEntityListComponent();
            _addEntityComponent = new AddEntityComponent();
            _getEntityByIDComponent = new GetEntityByIDComponent();
            _editEntityComponent = new EditEntityComponent();
            _editEntityListComponent = new EditEntityListComponent();
            _deleteEntityComponent = new DeleteEntityComponent();
        }

        public void Add(Wish wish)
        {
            var existingWish = _repository.GetAll().Where(x => x.UserID == wish.UserID && x.Title == wish.Title && x.ItemType == wish.ItemType);

            if (existingWish.Any()) throw new ApplicationException($"An existing wish already exists for this user.");

            _addEntityComponent.Execute(_repository, wish);
        }

        public List<Wish> GetAll(string userID = "", string query = "", int numToTake = 0, int? pageNum = 1)
        {
            var num = _user.GetUserNum();
            var wishList = _getEntityListComponent.Execute(_repository).OrderBy(x => x.Title).AsQueryable();

            if (!string.IsNullOrWhiteSpace(userID)) wishList = wishList.Where(x => x.UserID == userID);

            if (!string.IsNullOrWhiteSpace(query))
            {
                var currentList = new List<Wish>();
                currentList.AddRange(wishList);

                wishList = currentList.Where(x => x.Title.IndexOf(query, StringComparison.InvariantCultureIgnoreCase) != -1).AsQueryable();
            }
            if (numToTake > 0) wishList = wishList.Skip(numToTake * (pageNum.GetValueOrDefault() - 1)).Take(numToTake);

            return wishList.ToList();
        }

        public Wish GetByID(int id, string userID) => _getEntityByIDComponent.Execute(_repository, id, userID);

        public void Edit(Wish wish) => _editEntityComponent.Execute(_repository, wish);

        public void Delete(int id, string userID) => _deleteEntityComponent.Execute(_repository, id, userID);

        public int GetCount() => _repository.GetCount();
    }
}