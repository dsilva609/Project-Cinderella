using BusinessLogic.Models;
using BusinessLogic.Models.DiscogsModels;
using BusinessLogic.Properties;
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
            if (string.IsNullOrWhiteSpace(artist) && string.IsNullOrWhiteSpace(album)) return new List<DiscogsResult>();
            var response = _client.GetAsync($"database/search?type=release&q={artist}+{album}");

            var result = JObject.Parse(response.Result.Content.ReadAsStringAsync().Result);

            var resultList = JsonConvert.DeserializeObject<List<DiscogsResult>>(result["results"].ToString());

            foreach (var t in resultList)
            {
                t.FormatString = string.Join(", ", t.Format);
                t.GenreString = t.Style.Length == 0 ? string.Join(", ", t.Genre) : string.Join(", ", t.Style);
                t.LabelString = string.Join(", ", t.Label);
            }

            return resultList;
        }

        public Album GetRelease(int releaseID)
        {
            var response = _client.GetAsync($"releases/{releaseID}");
            var result = response.Result.Content.ReadAsStringAsync().Result;
            var release = JsonConvert.DeserializeObject<DiscogsRelease>(result);

            release.LabelString = release.labels != null ? string.Join(", ", release.labels.Select(x => x.name).ToList()) : string.Empty;
            release.GenreString = release.genres != null ? string.Join(", ", release.genres.ToList()) : string.Empty;
            release.StylesString = release.styles != null ? string.Join(", ", release.styles) : string.Empty;
            if (!string.IsNullOrWhiteSpace(release.StylesString))
                release.GenreString += $" - {release.StylesString}";

            var album = ConvertFromRelease(release);

            return album;
        }

        private void CreateClient()
        {
            _client = new HttpClient { BaseAddress = new Uri("https://api.discogs.com/") };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("Authorization", $"Discogs token={Settings.Default.DiscogsKey}");
            _client.DefaultRequestHeaders.Add("User-Agent", "Project-Cinderella/1.0 +projectcinderella.azurewebsites.net");
        }

        private Album ConvertFromRelease(DiscogsRelease release)
        {
            var album = new Album
            {
                Artist = release.artists?.First().name,
                Title = release.title,
                YearReleased = release.year,
                RecordLabel = release.LabelString,
                Genre = release.GenreString,
                DiscogsID = release.id,
                ImageUrl = release.images?.First().uri,
                Tracklist = release.tracklist
            };

            return album;
        }
    }
}