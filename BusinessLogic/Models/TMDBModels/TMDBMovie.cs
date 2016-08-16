using System.Collections.Generic;

namespace BusinessLogic.Models.TMDBModels
{
    public class TMDBMovieResult
    {
        public string status_code { get; set; }
        public string status_message { get; set; }
        public int page { get; set; }
        public List<TMDBMovie> results { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
    }

    public class TMDBMovie
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public object belongs_to_collection { get; set; }
        public int budget { get; set; }
        public List<Genre> genres { get; set; }
        public string homepage { get; set; }
        public int id { get; set; }
        public string imdb_id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public float popularity { get; set; }
        public string poster_path { get; set; }
        public List<Production_Companies> production_companies { get; set; }
        public List<Production_Countries> production_countries { get; set; }
        public string release_date { get; set; }
        public int revenue { get; set; }
        public int runtime { get; set; }
        public List<Spoken_Languages> spoken_languages { get; set; }
        public string status { get; set; }
        public string tagline { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }

        //TODO: refactor out to separate base model for tv shows
        public string name { get; set; }

        public string first_air_date { get; set; }

        public List<Season> seasons { get; set; }

        public List<Network> networks { get; set; }

        public List<CreatedBy> created_by { get; set; }
    }

    public class Genre
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Production_Companies
    {
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Production_Countries
    {
        public string iso_3166_1 { get; set; }
        public string name { get; set; }
    }

    public class Spoken_Languages
    {
        public string iso_639_1 { get; set; }
        public string name { get; set; }
    }

    public class Network
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Season
    {
        public string air_date { get; set; }
        public int episode_count { get; set; }
        public int id { get; set; }
        public string poster_path { get; set; }
        public int season_number { get; set; }
    }

    public class CreatedBy
    {
        public int id { get; set; }
        public string name { get; set; }
        public string profile_path { get; set; }
    }
}