using BusinessLogic.Models;
using System.Collections.Generic;

namespace BusinessLogic.Services.Interfaces
{
    public interface IAlbumService
    {
        void Add(Album album);

        List<Album> GetAll(string userID = "", string query = "", int numToTake = 0, int? pageNum = 1);

        Album GetByID(int id, string userID);

        void Edit(int id, Album album);

        void Delete(int id, string userID);

        int GetCount();
    }
}