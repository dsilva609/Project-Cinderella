using System.Collections.Generic;
using ProjectCinderella.Model.Common;

namespace ProjectCinderella.BusinessLogic.Services.Interfaces
{
	public interface IPopService
	{
		void Add(FunkoModel pop);

		List<FunkoModel> GetAll(string userID = "", string query = "", int numToTake = 0, int? pageNum = 1);

		FunkoModel GetByID(int id, string userID);

		void Edit(FunkoModel pop);

		void Delete(int id, string userID);

		int GetCount();
	}
}