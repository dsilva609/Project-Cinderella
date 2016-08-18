using BusinessLogic.Models.GiantBombModels;
using BusinessLogic.Properties;
using BusinessLogic.Services.Interfaces;
using Newtonsoft.Json;
using System;
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
			var response = _client.GetStringAsync($"search?query={query}&format=json&api_key={Settings.Default.GiantBombKey}");
			var result = response.Result;

			var giantBombResult = JsonConvert.DeserializeObject<GiantBombResult>(result);

			return giantBombResult;
		}

		public GiantBombGame SearchByID(int id)
		{
			var response = _client.GetStringAsync($"game/{id}/?format=json&api_key={Settings.Default.GiantBombKey}");
			var result = response.Result;

			var giantBombResult = JsonConvert.DeserializeObject<GiantBombGame>(result);

			return giantBombResult;
		}

		private void CreateHttpClient()
		{
			_client = new HttpClient { BaseAddress = new Uri("http://www.giantbomb.com/api/") };
			_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			_client.DefaultRequestHeaders.Add("User-Agent", "Project-Cinderella/1.0 +projectcinderella.azurewebsites.net");
		}
	}
}