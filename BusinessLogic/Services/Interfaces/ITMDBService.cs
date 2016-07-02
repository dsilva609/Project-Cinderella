using BusinessLogic.Models.TMDBModels;
using System.Collections.Generic;

namespace BusinessLogic.Services.Interfaces
{
	public interface ITMDBService
	{
		List<TMDBMovie> SearchMovies(string title);
	}
}