using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Models.ComicVineModels;
using BusinessLogic.Properties;
using BusinessLogic.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BusinessLogic.Services
{
	public class ComicVineService : IComicVineService
	{
		private HttpClient _client;

		public ComicVineService()
		{
			CreateClient();
		}

		public ComicVineResult Search(string query)
		{
			var response =
				_client.GetStringAsync($"search/?api_key={Settings.Default.ComicVineKey}&resources=issue&format=json&limit=25&query={query}");
			var result = response.Result;

			var comicVineResults = JsonConvert.DeserializeObject<ComicVineResult>(result);
			comicVineResults.results.ForEach(x => x.id = x.api_detail_url.Substring(x.api_detail_url.IndexOf("issue/") + 6).TrimEnd('/'));
			return comicVineResults;
		}

		public Book SearchByID(string id)
		{
			var response = _client.GetStringAsync($"issue/{id}/?api_key={Settings.Default.ComicVineKey}&format=json");
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
			book.Title = comic.name;
			book.ImageUrl = comic.image.super_url;
			book.GoogleBookID = comic.api_detail_url.Substring(comic.api_detail_url.IndexOf("issue/") + 6).TrimEnd('/');
			book.Author = comic.person_credits.FirstOrDefault(x => x.role == "writer")?.name;
			//book.Publisher = comic.publisher.name;
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