using System.Collections.Generic;
using ProjectCinderella.Model.Common;
using ProjectCinderella.Model.TMDBModels;

namespace ProjectCinderella.BusinessLogic.Services.Interfaces
{
    public interface ITMDBService
    {
        List<TMDBMovie> SearchMovies(string title);

        Movie SearchMovieByID(int id);

        List<TMDBMovie> SearchTV(string title);

        Movie SearchTVShowByID(int id, int seasonNumber);
    }
}