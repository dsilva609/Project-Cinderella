using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Services.Statistics
{
    public class BookStatisticService : IBookStatisticService
    {
        private readonly IBookService _bookService;
        private readonly List<Book> _books;

        public BookStatisticService(IBookService bookService)
        {
            _bookService = bookService;
            _books = GetBooks();
        }

        public int NumNovel(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _books.Count(x => x.Type == BookTypeEnum.Novel)
                : _books.Count(x => x.UserID == userID && x.Type == BookTypeEnum.Novel);

        public int NumComic(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _books.Count(x => x.Type == BookTypeEnum.Comic)
                : _books.Count(x => x.UserID == userID && x.Type == BookTypeEnum.Comic);

        public int NumManga(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _books.Count(x => x.Type == BookTypeEnum.Manga)
                : _books.Count(x => x.UserID == userID && x.Type == BookTypeEnum.Manga);

        public int NumHardcover(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _books.Count(x => x.Hardcover)
                : _books.Count(x => x.UserID == userID && x.Hardcover);

        public int NumFirstEdition(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _books.Count(x => x.IsFirstEdition)
                : _books.Count(x => x.UserID == userID && x.IsFirstEdition);

        public int TotalPageCount(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _books.Sum(x => x.PageCount)
                : _books.Where(x => x.UserID == userID).Sum(y => y.PageCount);

        public List<string> TopPublishers(string userID = "", int numToTake = 0)
            => string.IsNullOrWhiteSpace(userID)
                ? _books.Where(w => !string.IsNullOrWhiteSpace(w.Publisher))
                    .GroupBy(x => x.Publisher)
                    .OrderByDescending(y => y.Count())
                    .Select(z => z.Key)
                    .Take(numToTake > 0 ? numToTake : _books.Count)
                    .ToList()
                : _books.Where(x => x.UserID == userID && !string.IsNullOrWhiteSpace(x.Publisher))
                    .GroupBy(y => y.Publisher)
                    .OrderByDescending(z => z.Count())
                    .Select(w => w.Key)
                    .Take(numToTake > 0 ? numToTake : _books.Count)
                    .ToList();

        public List<string> TopCountriesOfOrigin(string userID = "", int numToTake = 0)
            => string.IsNullOrWhiteSpace(userID)
                ? _books.Where(w => !string.IsNullOrWhiteSpace(w.CountryOfOrigin))
                    .GroupBy(x => x.CountryOfOrigin)
                    .OrderByDescending(y => y.Count())
                    .Select(z => z.Key)
                    .Take(numToTake > 0 ? numToTake : _books.Count)
                    .ToList()
                : _books.Where(x => x.UserID == userID && !string.IsNullOrWhiteSpace(x.CountryOfOrigin))
                    .GroupBy(y => y.CountryOfOrigin)
                    .OrderByDescending(z => z.Count())
                    .Select(w => w.Key)
                    .Take(numToTake > 0 ? numToTake : _books.Count)
                    .ToList();

        public List<string> TopPurchaseCountries(string userID = "", int numToTake = 0)
            => string.IsNullOrWhiteSpace(userID)
                ? _books.Where(w => !string.IsNullOrWhiteSpace(w.CountryPurchased))
                    .GroupBy(x => x.CountryPurchased)
                    .OrderByDescending(y => y.Count())
                    .Select(z => z.Key)
                    .Take(numToTake > 0 ? numToTake : _books.Count)
                    .ToList()
                : _books.Where(x => x.UserID == userID && !string.IsNullOrWhiteSpace(x.CountryPurchased))
                    .GroupBy(y => y.CountryPurchased)
                    .OrderByDescending(z => z.Count())
                    .Select(w => w.Key)
                    .Take(numToTake > 0 ? numToTake : _books.Count)
                    .ToList();

        public List<string> MostCompleted(string userID = "", int numToTake = 0)
            => string.IsNullOrWhiteSpace(userID)
                ? _books.OrderByDescending(x => x.TimesCompleted).Select(y => y.Title).Take(numToTake > 0 ? numToTake : _books.Count).ToList()
                : _books.Where(x => x.UserID == userID)
                    .OrderByDescending(y => y.TimesCompleted)
                    .Select(z => z.Title)
                    .Take(numToTake > 0 ? numToTake : _books.Count)
                    .ToList();

        public List<string> TopLocationsPurchased(string userID = "", int numToTake = 0)
            => string.IsNullOrWhiteSpace(userID)
                ? _books.Where(w => !string.IsNullOrWhiteSpace(w.LocationPurchased))
                    .GroupBy(x => x.LocationPurchased)
                    .OrderByDescending(y => y.Count())
                    .Select(z => z.Key)
                    .Take(numToTake > 0 ? numToTake : _books.Count)
                    .ToList()
                : _books.Where(x => x.UserID == userID && !string.IsNullOrWhiteSpace(x.LocationPurchased))
                    .GroupBy(y => y.LocationPurchased)
                    .OrderByDescending(z => z.Count())
                    .Select(w => w.Key)
                    .Take(numToTake > 0 ? numToTake : _books.Count)
                    .ToList();

        public List<int> TopReleaseYears(string userID = "", int numToTake = 0)
            => string.IsNullOrWhiteSpace(userID)
                ? _books.GroupBy(x => x.YearReleased)
                    .OrderByDescending(y => y.Count())
                    .Select(z => z.Key)
                    .Take(numToTake > 0 ? numToTake : _books.Count)
                    .ToList()
                : _books.Where(x => x.UserID == userID)
                    .GroupBy(y => y.YearReleased)
                    .OrderByDescending(z => z.Count())
                    .Select(w => w.Key)
                    .Take(numToTake > 0 ? numToTake : _books.Count)
                    .ToList();

        private List<Book> GetBooks() => _bookService.GetAll();
    }
}