using System.Collections.Generic;
using ProjectCinderella.Model.Common;

namespace ProjectCinderella.BusinessLogic.Services.Interfaces
{
	public interface IWishService
	{
		void Add(Wish wish);

		List<Wish> GetAll(string userID = "", string query = "", int numToTake = 0, int? pageNum = 1);

		Wish GetByID(int id, string userID);

		void Edit(Wish wish);

		void Delete(int id, string userID);

		int GetCount();
	}
}