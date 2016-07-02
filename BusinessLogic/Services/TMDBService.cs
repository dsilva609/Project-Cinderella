using BusinessLogic.Models.TMDBModels;
using BusinessLogic.Properties;
using BusinessLogic.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

		private void CreateClient()
		{
			_client = new HttpClient { BaseAddress = new Uri("https://api.themoviedb.org/3/") };
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
			_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			_client.DefaultRequestHeaders.Add("Authorization", $"Discogs token={Settings.Default.DiscogsKey}");
			_client.DefaultRequestHeaders.Add("User-Agent", "Project-Cinderella/1.0 +projectcinderella.azurewebsites.net");
		}
	}
}