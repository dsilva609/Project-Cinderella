using BusinessLogic.Models;
using System.Collections.Generic;

namespace BusinessLogic.Services.Interfaces
{
	public interface IGameService
	{
		void Add(Game game);

		List<Game> GetAll(string userID = "", string query = "", int numToTake = 0, int? pageNum = 1);

		Game GetByID(int id, string userID);

		void Edit(Game game);

		void Delete(int id, string userID);

		int GetCount();

		int GetHighestQueueRank(string userID);
	}
}