using BusinessLogic.Models.DiscogsModels;
using BusinessLogic.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BusinessLogic.Services
{
	public class DiscogsService : IDiscogsService
	{
		private HttpClient _client;

		public DiscogsService()
		{
			CreateClient();
		}

		public List<DiscogsResult> Search(string artist, string album)
		{
			var response = _client.GetAsync($"database/search?artist={artist}&release_title={album}&type=release");

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

		private void CreateClient()
		{
			_client = new HttpClient { BaseAddress = new Uri("https://api.discogs.com/") };
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			_client.DefaultRequestHeaders.Add("Authorization", "Discogs token=VihLsjGHOaqfiRLhNZMZydxTWUTcidbHkuZgCALD");
			_client.DefaultRequestHeaders.Add("User-Agent", "Project-Cinderella/1.0 +projectcinderella.azurewebsites.net");
		}

		public DiscogsRelease GetRelease(int releaseID)
		{
			var response = _client.GetAsync($"releases/{releaseID}");
			var result = response.Result.Content.ReadAsStringAsync().Result;
			var release = JsonConvert.DeserializeObject<DiscogsRelease>(result);

			release.LabelString = release.labels != null ? string.Join(", ", release.labels.Select(x => x.name).ToList()) : string.Empty;
			release.GenreString = release.genres != null ? string.Join(", ", release.genres.ToList()) : string.Empty;
			release.StylesString = release.styles != null ? string.Join(", ", release.styles) : string.Empty;
			if (!string.IsNullOrWhiteSpace(release.StylesString))
				release.GenreString += $" - {release.StylesString}";

			return release;
		}
	}
}