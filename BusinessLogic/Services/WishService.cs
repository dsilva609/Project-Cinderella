using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
    public class WishService : IWishService
    {
        public void Add(Wish album)
        {
            throw new NotImplementedException();
        }

        public List<Wish> GetAll(string userID = "", string query = "", int numToTake = 0, int? pageNum = 1)
        {
            throw new NotImplementedException();
        }

        public Wish GetByID(int id, string userID)
        {
            throw new NotImplementedException();
        }

        public void Edit(Wish album)
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