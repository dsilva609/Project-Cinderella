using BusinessLogic.Models;
using System.Collections.Generic;

namespace BusinessLogic.Services.Interfaces
{
    public interface IRecordService
    {
        void Add(RecordModel record);

        List<RecordModel> GetAll(int numToTake = 0, int? pageNum = 1);

        RecordModel GetByID(int id);

        void Edit(int id, RecordModel record);

        void Delete(int id);

        int GetCount();
    }
}