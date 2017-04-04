using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Services.Statistics
{
    public class MovieStatisticService : IMovieStatisticService
    {
        private readonly IMovieService _movieService;
        private readonly List<Movie> _movies;

        public MovieStatisticService(IMovieService movieService)
        {
            _movieService = movieService;
            _movies = GetMovies();
        }

        public List<string> TopDirectors(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _movies.GroupBy(x => x.Director).OrderByDescending(y => y.Count()).Select(z => z.Key).ToList()
                : _movies.Where(x => x.UserID == userID).GroupBy(y => y.Director).OrderByDescending(z => z.Count()).Select(w => w.Key).ToList();

        public int NumDVD(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _movies.Count(x => x.Type == MovieMediaTypeEnum.DVD)
                : _movies.Count(x => x.UserID == userID && x.Type == MovieMediaTypeEnum.DVD);

        public int NumBluRay(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _movies.Count(x => x.Type == MovieMediaTypeEnum.Bluray)
                : _movies.Count(x => x.UserID == userID && x.Type == MovieMediaTypeEnum.Bluray);

        public int NumRatedG(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _movies.Count(x => x.Rating == MovieRatingEnum.G)
                : _movies.Count(x => x.UserID == userID && x.Rating == MovieRatingEnum.G);

        public int NumRatedPG(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _movies.Count(x => x.Rating == MovieRatingEnum.PG)
                : _movies.Count(x => x.UserID == userID && x.Rating == MovieRatingEnum.PG);

        public int NumRatedPG13(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _movies.Count(x => x.Rating == MovieRatingEnum.PG13)
                : _movies.Count(x => x.UserID == userID && x.Rating == MovieRatingEnum.PG13);

        public int NumRatedR(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _movies.Count(x => x.Rating == MovieRatingEnum.R)
                : _movies.Count(x => x.UserID == userID && x.Rating == MovieRatingEnum.R);

        public int NumRatedNR(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _movies.Count(x => x.Rating == MovieRatingEnum.NR)
                : _movies.Count(x => x.UserID == userID && x.Rating == MovieRatingEnum.NR);

        public List<string> TopCountriesOfOrigin(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _movies.GroupBy(x => x.CountryOfOrigin).OrderByDescending(y => y.Count()).Select(z => z.Key).ToList()
                : _movies.Where(x => x.UserID == userID).GroupBy(y => y.CountryOfOrigin).OrderByDescending(z => z.Count()).Select(w => w.Key).ToList();

        public List<string> TopPurchaseCountries(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _movies.GroupBy(x => x.CountryPurchased).OrderByDescending(y => y.Count()).Select(z => z.Key).ToList()
                : _movies.Where(x => x.UserID == userID).GroupBy(y => y.CountryPurchased).OrderByDescending(z => z.Count())
                    .Select(w => w.Key).ToList();

        public List<string> MostCompleted(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _movies.OrderByDescending(x => x.TimesCompleted).Select(y => y.Title).ToList()
                : _movies.Where(x => x.UserID == userID).OrderByDescending(y => y.TimesCompleted).Select(z => z.Title).ToList();

        public List<string> TopLocationsPurchased(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _movies.GroupBy(x => x.LocationPurchased).OrderByDescending(y => y.Count()).Select(z => z.Key).ToList()
                : _movies.Where(x => x.UserID == userID).GroupBy(y => y.LocationPurchased).OrderByDescending(z => z.Count())
                    .Select(w => w.Key).ToList();

        public List<int> TopReleaseYears(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _movies.GroupBy(x => x.YearReleased).OrderByDescending(y => y.Count()).Select(z => z.Key).ToList()
                : _movies.Where(x => x.UserID == userID).GroupBy(y => y.YearReleased).OrderByDescending(z => z.Count()).Select(w => w.Key).ToList();

        private List<Movie> GetMovies() => _movieService.GetAll();
    }
}