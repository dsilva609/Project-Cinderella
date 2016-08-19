using BusinessLogic.Models;
using BusinessLogic.Models.GiantBombModels;
using BusinessLogic.Properties;
using BusinessLogic.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BusinessLogic.Services
{
	public class GiantBombService : IGiantBombService
	{
		private HttpClient _client;

		public GiantBombService()
		{
			CreateHttpClient();
		}

		public GiantBombResult Search(string query)
		{
			var response = _client.GetStringAsync($"search?query={query}&format=json&api_key={Settings.Default.GiantBombKey}&limit=25");
			var result = response.Result;

			var giantBombResult = JsonConvert.DeserializeObject<GiantBombResult>(result);

			return giantBombResult;
		}

		public Game SearchByID(int id)
		{
			var response = _client.GetStringAsync($"game/{id}/?format=json&api_key={Settings.Default.GiantBombKey}");
			var result = response.Result;

			var giantBombResult = JsonConvert.DeserializeObject<GiantBombGame>(result);

			return giantBombResult;
		}

		private Game ConvertGiantBombGameToGame(GiantBombGame result)
		{
			var game = new Game();
			var giantBombGame = result.results;
			game.Title = giantBombGame.aliases;
			game.Developer = giantBombGame.developers.FirstOrDefault()?.name;
			game.Publisher = giantBombGame.publishers.FirstOrDefault()?.name;
			//game.Rating = giantBombGame.original_game_rating.
			game.ImageUrl = giantBombGame.image.super_url;
			game.YearReleased = Convert.ToDateTime(giantBombGame.original_release_date).Year;
			game.Genre = string.Join(", ", giantBombGame.genres.Select(x => x.name));
			//TODO: add special id field
			game.Notes = giantBombGame.id.ToString();

			return game;
		}

		private void CreateHttpClient()
		{
			_client = new HttpClient { BaseAddress = new Uri("http://www.giantbomb.com/api/") };
			_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			_client.DefaultRequestHeaders.Add("User-Agent", "Project-Cinderella/1.0 +projectcinderella.azurewebsites.net");
		}
	}
}