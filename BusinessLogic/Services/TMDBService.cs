using BusinessLogic.Models;
using BusinessLogic.Models.TMDBModels;
using BusinessLogic.Properties;
using BusinessLogic.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BusinessLogic.Services
{
	public class TMDBService : ITMDBService
	{
		private HttpClient _client;

		public TMDBService()
		{
			CreateClient();
		}

		public List<TMDBMovie> SearchMovies(string title)
		{
			var response = _client.GetAsync($"search/movie?api_key={Settings.Default.TMDBKey}&query={title}");

			var result = response.Result.Content.ReadAsStringAsync().Result;
			var movies = JsonConvert.DeserializeObject<TMDBMovieResult>(result);

			return movies.results;
		}

		public Movie SearchMovieByID(int id)
		{
			var response = _client.GetAsync($"movie/{id}?api_key={Settings.Default.TMDBKey}");

			var result = response.Result.Content.ReadAsStringAsync().Result;
			var tmdbMovie = JsonConvert.DeserializeObject<TMDBMovie>(result);
			var movie = ConvertTMDDResultToModelForMovie(tmdbMovie);

			return movie;
		}

		public List<TMDBMovie> SearchTV(string title)
		{
			var response = _client.GetAsync($"search/tv?api_key={Settings.Default.TMDBKey}&query={title}");

			var result = response.Result.Content.ReadAsStringAsync().Result;
			var shows = JsonConvert.DeserializeObject<TMDBMovieResult>(result);
			shows.results.ForEach(x => x.IsTvShow = true);

			return shows.results;
		}

		public Movie SearchTVShowByID(int id)
		{
			var response = _client.GetAsync($"tv/{id}?api_key={Settings.Default.TMDBKey}");

			var result = response.Result.Content.ReadAsStringAsync().Result;
			var tmdbMovie = JsonConvert.DeserializeObject<TMDBMovie>(result);
			var movie = ConvertTMDDResultToModelForTV(tmdbMovie);

			return movie;
		}

		private void CreateClient()
		{
			_client = new HttpClient { BaseAddress = new Uri("https://api.themoviedb.org/3/") };
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
			_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			_client.DefaultRequestHeaders.Add("User-Agent", "Project-Cinderella/1.0 +projectcinderella.azurewebsites.net");
		}

		private Movie ConvertTMDDResultToModelForMovie(TMDBMovie tmdb)
		{
			var movie = new Movie
			{
				Title = tmdb.title,
				Distributor = tmdb.production_companies.First().name,
				Genre = string.Join(", ", tmdb.genres.Select(x => x.name).ToList()),
				ImageUrl = string.Format("https://image.tmdb.org/t/p/w500{0}", tmdb.poster_path),
				Language = tmdb.original_language,
				TMDBID = tmdb.id,
				YearReleased = DateTime.Parse(tmdb.release_date).Year
			};

			return movie;
		}

		private Movie ConvertTMDDResultToModelForTV(TMDBMovie tmdb)
		{
			var movie = new Movie
			{
				Title = tmdb.name,
				Director = string.Join(", ", tmdb.created_by.Select(x => x.name).ToList()),
				Distributor = tmdb.production_companies.First().name,
				Genre = string.Join(", ", tmdb.genres.Select(x => x.name).ToList()),
				ImageUrl = string.Format("https://image.tmdb.org/t/p/w500{0}", tmdb.poster_path),
				Language = tmdb.original_language,
				TMDBID = tmdb.id,
				YearReleased = DateTime.Parse(tmdb.first_air_date).Year,
			};

			return movie;
		}
	}
}