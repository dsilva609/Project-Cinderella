﻿using BusinessLogic.Models;
using BusinessLogic.Models.BGGModels;
using BusinessLogic.Services.Interfaces;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml.Serialization;

namespace BusinessLogic.Services
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

			game.Notes = bgg.ID.ToString();
			game.Title = bgg.name.value;
			game.ImageUrl = bgg.Image;
			game.YearReleased = bgg.yearpublished.value;

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