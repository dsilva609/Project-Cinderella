﻿using BusinessLogic.Models;
using BusinessLogic.Models.TMDBModels;
using System.Collections.Generic;

namespace BusinessLogic.Services.Interfaces
{
	public interface ITMDBService
	{
		List<TMDBMovie> SearchMovies(string title);

		Movie SearchMovieByID(int id);
	}
}