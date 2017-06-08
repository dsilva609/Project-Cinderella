﻿using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ProjectCinderella.BusinessLogic.Services.Interfaces;
using ProjectCinderella.Model.ComicVineModels;
using ProjectCinderella.Model.Common;
using ProjectCinderella.Model.Enums;

namespace ProjectCinderella.BusinessLogic.Services
{
	public class ComicVineService : IComicVineService
	{
		private readonly ServiceSettings _settings;
		private HttpClient _client;

		public ComicVineService(IOptions<ServiceSettings> settings)
		{
			_settings = settings.Value;
			CreateClient();
		}

		public ComicVineResult Search(string query)
		{
			var response =
				_client.GetStringAsync($"search/?api_key={_settings.ComicVineKey}&resources=issue&format=json&limit=25&query={query}");
			var result = response.Result;

			var comicVineResults = JsonConvert.DeserializeObject<ComicVineResult>(result);
			comicVineResults.results.ForEach(x => x.id = x.api_detail_url.Substring(x.api_detail_url.IndexOf("issue/") + 6).TrimEnd('/'));
			return comicVineResults;
		}

		public Book SearchByID(string id)
		{
			var response = _client.GetStringAsync($"issue/{id}/?api_key={_settings.ComicVineKey}&format=json");
			var result = response.Result;

			var comicVineResult = JsonConvert.DeserializeObject<ComicVineComic>(result);
			var book = ConvertFromComicVineResultToBook(comicVineResult);

			return book;
		}

		private Book ConvertFromComicVineResultToBook(ComicVineComic result)
		{
			var book = new Book();
			var comic = result.results;
			//TODO: add field for ComicVineID

			book.Title = $"{comic.name} #{comic.issue_number}";
			book.ImageUrl = comic.image.super_url;
			book.GoogleBookID = comic.api_detail_url.Substring(comic.api_detail_url.IndexOf("issue/") + 6).TrimEnd('/');
			book.Author = comic.person_credits?.FirstOrDefault(x => x.role == "writer")?.name;
			book.Publisher = comic.publisher?.name;
			book.Type = BookTypeEnum.Comic;

			return book;
		}

		private void CreateClient()
		{
			_client = new HttpClient { BaseAddress = new Uri("http://api.comicvine.com/") };
			_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			_client.DefaultRequestHeaders.Add("User-Agent", "Project-Cinderella/1.0 +projectcinderella.azurewebsites.net");
		}
	}
}