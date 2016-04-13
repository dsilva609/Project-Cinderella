using BusinessLogic.Models;
using System.Collections.Generic;

namespace BusinessLogic.Services.Interfaces
{
    public interface IRecordService
    {
        void Add(RecordModel record);

        List<RecordModel> GetAll(string userID = "", string query = "", int numToTake = 0, int? pageNum = 1);

        RecordModel GetByID(int id, string userID);

        void Edit(int id, RecordModel record);

        void Delete(int id, string userID);

        int GetCount();
    }
}