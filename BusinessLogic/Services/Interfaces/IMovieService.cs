using BusinessLogic.Models;
using System.Collections.Generic;

namespace BusinessLogic.Services.Interfaces
{
	public interface IMovieService
	{
		void Add(Movie movie);

		List<Movie> GetAll(string userID = "", string query = "", int numToTake = 0, int? pageNum = 1);

		Movie GetByID(int id, string userID);

		void Edit(int id, Movie movie);

		void Delete(int id, string userID);

		int GetCount();
	}
}