using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
using System;
using System.Linq;

namespace BusinessLogic.Services
{
	public class GoogleBookService : IGoogleBookService
	{
		private readonly IClientService _googleClient;
		private readonly VolumesResource _service;

		public GoogleBookService(IClientService client)
		{
			_service = new VolumesResource(client);
		}

		public Volumes Search(string author, string title)
		{
			var query = string.Empty;
			if (!string.IsNullOrWhiteSpace(author) && !string.IsNullOrWhiteSpace(title))
				query = $"inauthor:{author}+intitle:{title}";
			else if (!string.IsNullOrWhiteSpace(author) && string.IsNullOrWhiteSpace(title))
				query = $"inauthor:{author}";
			else if (string.IsNullOrWhiteSpace(author) && !string.IsNullOrWhiteSpace(title))
				query = $"intitle:{title}";

			var result = _service.List(query);

			return result.Execute();
		}

		public Book SearchByID(string id)
		{
			var volume = _service.Get(id).Execute();

			var book = new Book
			{
				GoogleBookID = volume.Id,
				Title = volume.VolumeInfo.Title,
				Author = volume.VolumeInfo.Authors == null ? string.Empty : string.Join(", ", volume.VolumeInfo.Authors),
				YearReleased =
					string.IsNullOrWhiteSpace(volume.VolumeInfo.PublishedDate)
						? DateTime.Today.Year
						: Convert.ToInt32(volume.VolumeInfo.PublishedDate.Substring(0, 4)),
				Publisher = volume.VolumeInfo.Publisher ?? string.Empty,
				Genre = volume.VolumeInfo.Categories == null ? string.Empty : string.Join(", ", volume.VolumeInfo.Categories),
				ISBN10 = volume.VolumeInfo.IndustryIdentifiers.SingleOrDefault(x => x.Type == "ISBN_10")?.Identifier,
				ISBN13 = volume.VolumeInfo.IndustryIdentifiers.SingleOrDefault(x => x.Type == "ISBN_13")?.Identifier,
				Language = volume.VolumeInfo.Language,
				ImageUrl = string.Format("https://books.google.com/books?id={0}&printsec=frontcover&img=1&zoom=0&edge=curl&source=gbs_api", volume.Id),
				PageCount = volume.VolumeInfo.PageCount.GetValueOrDefault()
			};

			return book;
		}
	}
}