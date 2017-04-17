using BusinessLogic.Models.TMDBModels;
using System.Collections.Generic;

namespace UI.Models
{
    public class MovieSearchModel
    {
        public string Title { get; set; }
        public int SeasonNumber { get; set; }
        public List<TMDBMovie> MovieResults { get; set; }
        public List<TMDBMovie> TVShowResults { get; set; }
    }
}