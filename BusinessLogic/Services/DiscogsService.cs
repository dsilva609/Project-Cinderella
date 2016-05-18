using BusinessLogic.Models.DiscogsModels;
using BusinessLogic.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BusinessLogic.Services
{
	public class DiscogsService : IDiscogsService
	{
		public List<DiscogsResult> Search()
		{
			var client = new HttpClient { BaseAddress = new Uri("https://api.discogs.com/") };

			client.DefaultRequestHeaders.Add("Authorization", "Discogs token=VihLsjGHOaqfiRLhNZMZydxTWUTcidbHkuZgCALD");
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			client.DefaultRequestHeaders.Add("User-Agent", "Project-Cinderella/1.0 +projectcinderella.azurewebsites.net");
			var response = client.GetAsync("database/search?q=dio&type=artist");
			var result = JObject.Parse(response.Result.Content.ReadAsStringAsync().Result);
			//	if (result.IsSuccessStatusCode)
			//{
			return JsonConvert.DeserializeObject<List<DiscogsResult>>(result["results"].ToString());
			//}
		}
	}
}