using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
	public class MovieService : IMovieService
	{
		public void Add(Movie movie)
		{
			throw new NotImplementedException();
		}

		public List<Movie> GetAll(string userID = "", string query = "")
		{
			throw new NotImplementedException();
		}

		public Movie GetByID(int id, string userID)
		{
			throw new NotImplementedException();
		}

		public void Edit(int id, Movie movie)
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