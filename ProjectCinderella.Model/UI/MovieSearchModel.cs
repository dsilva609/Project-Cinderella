using System.Collections.Generic;
using ProjectCinderella.Model.TMDBModels;

namespace ProjectCinderella.Model.UI
{
    public class MovieSearchModel
    {
        public string Title { get; set; }
        public int SeasonNumber { get; set; }
        public List<TMDBMovie> MovieResults { get; set; }
        public List<TMDBMovie> TVShowResults { get; set; }
    }
}