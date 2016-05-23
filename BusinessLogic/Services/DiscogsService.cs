﻿using BusinessLogic.Models.DiscogsModels;
using BusinessLogic.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BusinessLogic.Services
{
	public class DiscogsService : IDiscogsService
	{
		public List<DiscogsResult> Search(string artist, string album)
		{
			var client = new HttpClient { BaseAddress = new Uri("https://api.discogs.com/") };
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			client.DefaultRequestHeaders.Add("Authorization", "Discogs token=VihLsjGHOaqfiRLhNZMZydxTWUTcidbHkuZgCALD");
			client.DefaultRequestHeaders.Add("User-Agent", "Project-Cinderella/1.0 +projectcinderella.azurewebsites.net");
			var response = client.GetAsync($"database/search?artist={artist}&release_title={album}&type=release");

			var result = JObject.Parse(response.Result.Content.ReadAsStringAsync().Result);
			//	if (result.IsSuccessStatusCode)
			//{
			var resultList = JsonConvert.DeserializeObject<List<DiscogsResult>>(result["results"].ToString());

			foreach (var t in resultList)
			{
				t.FormatString = string.Join(", ", t.Format);
				t.GenreString = t.Style.Length == 0 ? string.Join(", ", t.Genre) : string.Join(", ", t.Style);
				t.LabelString = string.Join(", ", t.Label);
			}

			return resultList;
			//}
		}
	}
}