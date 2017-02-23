using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
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

            if (volumes != null && volumes.Any()) books.AddRange(volumes.Select(ConvertVolumeToBook));

            return books;
        }

        public Book SearchByID(string id)
        {
            var volume = _service.Get(id).Execute();

            var book = ConvertVolumeToBook(volume);

            return book;
        }

        private Book ConvertVolumeToBook(Volume volume)
        {
            var book = new Book();

            book.GoogleBookID = volume.Id;
            book.Title = volume.VolumeInfo.Title;
            book.Author = volume.VolumeInfo.Authors == null ? string.Empty : string.Join(", ", volume.VolumeInfo.Authors);
            book.YearReleased =
                string.IsNullOrWhiteSpace(volume.VolumeInfo.PublishedDate)
                    ? DateTime.Today.Year
                    : Convert.ToInt32(volume.VolumeInfo.PublishedDate.Substring(0, 4));
            book.Publisher = volume.VolumeInfo.Publisher ?? string.Empty;
            book.Genre = volume.VolumeInfo.Categories == null ? string.Empty : string.Join(", ", volume.VolumeInfo.Categories);
            book.ISBN10 = volume.VolumeInfo.IndustryIdentifiers?.SingleOrDefault(x => x.Type == "ISBN_10")?.Identifier;
            book.ISBN13 = volume.VolumeInfo.IndustryIdentifiers?.SingleOrDefault(x => x.Type == "ISBN_13")?.Identifier;
            book.Language = volume.VolumeInfo.Language;
            book.ImageUrl = volume.VolumeInfo.ImageLinks == null ? string.Empty : volume.VolumeInfo?.ImageLinks?.Medium;
            book.CountryOfOrigin = volume.SaleInfo.Country;
            book.PageCount = volume.VolumeInfo.PageCount.GetValueOrDefault();

            return book;
        }
    }
}