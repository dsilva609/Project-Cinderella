using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml.Serialization;
using ProjectCinderella.BusinessLogic.Services.Interfaces;
using ProjectCinderella.Model.BGGModels;
using ProjectCinderella.Model.Common;
using ProjectCinderella.Model.Enums;

namespace ProjectCinderella.BusinessLogic.Services
{
	public class BGGService : IBGGService
	{
		private HttpClient _client;

		public BGGService()
		{
			CreateClient();
		}

		public BGGGame Search(string query)
		{
			var response = _client.GetAsync($"search?query={query}");
			var result = response.Result.Content.ReadAsStreamAsync().Result;
			var serializer = new XmlSerializer(typeof(BGGResult));
			var bggResults = serializer.Deserialize(result) as BGGResult;

			serializer = new XmlSerializer(typeof(BGGGame));
			var ids = string.Join(",", bggResults.item.Select(x => x.ID));
			response = _client.GetAsync($"thing?id={ids}");
			result = response.Result.Content.ReadAsStreamAsync().Result;
			var games = serializer.Deserialize(result) as BGGGame;

			return games;
		}

		public Game SearchByID(int id)
		{
			var response = _client.GetAsync($"thing?id={id}");
			var result = response.Result.Content.ReadAsStreamAsync().Result;
			var serializer = new XmlSerializer(typeof(BGGGame));
			var bggGame = serializer.Deserialize(result) as BGGGame;
			var game = ConvertBGGGameToGameModel(bggGame);

			return game;
		}

		private Game ConvertBGGGameToGameModel(BGGGame result)
		{
			var game = new Game();
			var bgg = result.Items.First();

			game.BGGID = bgg.ID;
			game.Title = bgg.name.value;
			game.ImageUrl = $"http://{bgg.Image.Substring(2)}";
			game.YearReleased = bgg.yearpublished?.value ?? DateTime.Today.Year;
			game.Type = bgg.type == "boardgame" ? GameTypeEnum.FullGame : GameTypeEnum.Expansion;
			game.Developer = bgg.Links.FirstOrDefault(x => x.Type == "boardgamedesigner")?.Value;
			game.Publisher = string.Join(", ", bgg.Links.Where(x => x.Type == "boardgamepublisher").Select(y => y.Value));
			game.Genre = string.Join(", ", bgg.Links.Where(x => x.Type == "boardgamecategory").Select(y => y.Value));

			return game;
		}

		private void CreateClient()
		{
			_client = new HttpClient { BaseAddress = new Uri("http://www.boardgamegeek.com/xmlapi2/") };
			_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
			_client.DefaultRequestHeaders.AcceptCharset.Add(new StringWithQualityHeaderValue("UTF-8"));
			_client.DefaultRequestHeaders.Add("User-Agent", "Project-Cinderella/1.0 +projectcinderella.azurewebsites.net");
		}
	}
}