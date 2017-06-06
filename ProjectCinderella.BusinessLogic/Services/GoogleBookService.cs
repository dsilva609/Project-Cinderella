using System;
using System.Collections.Generic;
using System.Linq;
using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
using ProjectCinderella.BusinessLogic.Services.Interfaces;
using ProjectCinderella.Model.Common;

namespace ProjectCinderella.BusinessLogic.Services
{
    public class GoogleBookService : IGoogleBookService
    {
        private readonly IClientService _googleClient;
        private readonly VolumesResource _service;

        public GoogleBookService(IClientService client)
        {
            _service = new VolumesResource(client);
        }

        public List<Book> Search(string author, string title)
        {
            var query = string.Empty;
            if (!string.IsNullOrWhiteSpace(author) && !string.IsNullOrWhiteSpace(title))
                query = $"inauthor:{author}+intitle:{title}";
            else if (!string.IsNullOrWhiteSpace(author) && string.IsNullOrWhiteSpace(title))
                query = $"inauthor:{author}";
            else if (string.IsNullOrWhiteSpace(author) && !string.IsNullOrWhiteSpace(title))
                query = $"intitle:{title}";

            var result = _service.List(query);

            var volumes = result.Execute().Items;
            var books = new List<Book>();

            if (volumes != null && volumes.Any()) books.AddRange(volumes.Select(x => ConvertVolumeToBook(x, true)));

            return books;
        }

        public Book SearchByID(string id)
        {
            var volume = _service.Get(id).Execute();

            var book = ConvertVolumeToBook(volume, false);

            return book;
        }

        private Book ConvertVolumeToBook(Volume volume, bool fromSearch)
        {
            var book = new Book
            {
                GoogleBookID = volume.Id,
                Title = volume.VolumeInfo.Title,
                Author = volume.VolumeInfo.Authors == null ? string.Empty : string.Join(", ", volume.VolumeInfo.Authors),
                YearReleased = string.IsNullOrWhiteSpace(volume.VolumeInfo.PublishedDate)
                    ? DateTime.Today.Year
                    : Convert.ToInt32(volume.VolumeInfo.PublishedDate.Substring(0, 4)),
                Publisher = volume.VolumeInfo.Publisher ?? string.Empty,
                Genre = volume.VolumeInfo.Categories == null ? string.Empty : string.Join(", ", volume.VolumeInfo.Categories),
                ISBN10 = volume.VolumeInfo.IndustryIdentifiers?.SingleOrDefault(x => x.Type == "ISBN_10")?.Identifier,
                ISBN13 = volume.VolumeInfo.IndustryIdentifiers?.SingleOrDefault(x => x.Type == "ISBN_13")?.Identifier,
                Language = volume.VolumeInfo.Language,
                ImageUrl = volume.VolumeInfo.ImageLinks != null && fromSearch
                    ? volume.VolumeInfo?.ImageLinks?.Thumbnail
                    : volume.VolumeInfo?.ImageLinks?.Medium,
                CountryOfOrigin = volume.SaleInfo.Country,
                PageCount = volume.VolumeInfo.PageCount.GetValueOrDefault()
            };

            return book;
        }
    }
}