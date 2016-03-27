using BusinessLogic.Models;
using System.Collections.Generic;

namespace BusinessLogic.Services.Interfaces
{
	public interface IRecordService
	{
		void Add(RecordModel record);

		List<RecordModel> GetAll();

		RecordModel GetByID(int id);

		void Edit(int id, RecordModel record);

		void Delete(int id);
	}
}