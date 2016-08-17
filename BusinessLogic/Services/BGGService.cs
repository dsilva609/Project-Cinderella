using BusinessLogic.Models.BGGModels;
using BusinessLogic.Services.Interfaces;
using System;
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

		public BGGResult Search(string query)
		{
			var response = _client.GetAsync($"search?query={query}");
			var result = response.Result.Content.ReadAsStreamAsync().Result;
			var serializer = new XmlSerializer(typeof(BGGResult));
			var bggResults = serializer.Deserialize(result) as BGGResult;

			return bggResults;
		}

		public BGGGame SearchByID(int id)
		{
			throw new NotImplementedException();
		}

		private void CreateClient()
		{
			_client = new HttpClient { BaseAddress = new Uri("http://www.boardgamegeek.com/xmlapi2/") };
			//ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
			_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
			_client.DefaultRequestHeaders.AcceptCharset.Add(new StringWithQualityHeaderValue("UTF-8"));
			_client.DefaultRequestHeaders.Add("User-Agent", "Project-Cinderella/1.0 +projectcinderella.azurewebsites.net");
		}
	}
}