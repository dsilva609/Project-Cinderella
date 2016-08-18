using BusinessLogic.Models.ComicVineModels;
using BusinessLogic.Properties;
using BusinessLogic.Services.Interfaces;
using Newtonsoft.Json;
using System;
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

            return comicVineResults;
        }

        public ComicVineResult SearchByID(int id)
        {
            var response = _client.GetStringAsync($"issues/?api_key={Settings.Default.ComicVineKey}&format=json&filter=id:{id}");
            var result = response.Result;

            var comicVineResult = JsonConvert.DeserializeObject<ComicVineResult>(result);

            return comicVineResult;
        }

        private void CreateClient()
        {
            _client = new HttpClient { BaseAddress = new Uri("http://api.comicvine.com/") };
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("User-Agent", "Project-Cinderella/1.0 +projectcinderella.azurewebsites.net");
        }
    }
}