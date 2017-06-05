using System.Collections.Generic;
using ProjectCinderella.Model.Common;

namespace ProjectCinderella.BusinessLogic.Services.Interfaces
{
	public interface IMovieService
	{
		void Add(Movie movie);

		List<Movie> GetAll(string userID = "", string query = "", int numToTake = 0, int? pageNum = 1);

		Movie GetByID(int id, string userID);

		void Edit(Movie movie);

		void Delete(int id, string userID);

		int GetCount();

		int GetHighestQueueRank(string userID);
	}
}