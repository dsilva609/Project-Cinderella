using System;
using System.Collections.Generic;
using System.Linq;
using ProjectCinderella.BusinessLogic.Services.Interfaces;
using ProjectCinderella.Model.Common;
using ProjectCinderella.Model.Enums;

namespace ProjectCinderella.BusinessLogic.Services.Statistics
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

		public List<Tuple<string, int>> TopDirectors(string userID = "", int numToTake = 0)
			=> string.IsNullOrWhiteSpace(userID)
				? _movies.GroupBy(x => x.Director)
					.OrderByDescending(y => y.Count())
					.Select(z => new Tuple<string, int>(z.Key, z.Count()))
					.Take(numToTake > 0 ? numToTake : _movies.Count)
					.ToList()
				: _movies.Where(x => x.UserID == userID)
					.GroupBy(y => y.Director)
					.OrderByDescending(z => z.Count())
					.Select(w => new Tuple<string, int>(w.Key, w.Count()))
					.Take(numToTake > 0 ? numToTake : _movies.Count)
					.ToList();

		public List<Tuple<string, int>> TopCountriesOfOrigin(string userID = "", int numToTake = 0)
			=> string.IsNullOrWhiteSpace(userID)
				? _movies.Where(w => !string.IsNullOrWhiteSpace(w.CountryOfOrigin))
					.GroupBy(x => x.CountryOfOrigin)
					.OrderByDescending(y => y.Count())
					.Select(z => new Tuple<string, int>(z.Key, z.Count()))
					.Take(numToTake > 0 ? numToTake : _movies.Count)
					.ToList()
				: _movies.Where(x => x.UserID == userID && !string.IsNullOrWhiteSpace(x.CountryOfOrigin))
					.GroupBy(y => y.CountryOfOrigin)
					.OrderByDescending(z => z.Count())
					.Select(w => new Tuple<string, int>(w.Key, w.Count()))
					.Take(numToTake > 0 ? numToTake : _movies.Count)
					.ToList();

		public List<Tuple<string, int>> TopPurchaseCountries(string userID = "", int numToTake = 0)
			=> string.IsNullOrWhiteSpace(userID)
				? _movies.Where(w => !string.IsNullOrWhiteSpace(w.CountryPurchased))
					.GroupBy(x => x.CountryPurchased)
					.OrderByDescending(y => y.Count())
					.Select(z => new Tuple<string, int>(z.Key, z.Count()))
					.Take(numToTake > 0 ? numToTake : _movies.Count)
					.ToList()
				: _movies.Where(x => x.UserID == userID && !string.IsNullOrWhiteSpace(x.CountryPurchased))
					.GroupBy(y => y.CountryPurchased)
					.OrderByDescending(z => z.Count())
					.Select(w => new Tuple<string, int>(w.Key, w.Count()))
					.Take(numToTake > 0 ? numToTake : _movies.Count)
					.ToList();

		public List<Tuple<string, int>> MostCompleted(string userID = "", int numToTake = 0)
			=> string.IsNullOrWhiteSpace(userID)
				? _movies.OrderByDescending(x => x.TimesCompleted).Select(y => new Tuple<string, int>(y.Title, y.TimesCompleted)).Take(numToTake > 0 ? numToTake : _movies.Count).ToList()
				: _movies.Where(x => x.UserID == userID)
					.OrderByDescending(y => y.TimesCompleted)
					.Select(z => new Tuple<string, int>(z.Title, z.TimesCompleted))
					.Take(numToTake > 0 ? numToTake : _movies.Count)
					.ToList();

		public List<Tuple<string, int>> TopLocationsPurchased(string userID = "", int numToTake = 0)
			=> string.IsNullOrWhiteSpace(userID)
				? _movies.Where(w => !string.IsNullOrWhiteSpace(w.LocationPurchased))
					.GroupBy(x => x.LocationPurchased)
					.OrderByDescending(y => y.Count())
					.Select(z => new Tuple<string, int>(z.Key, z.Count()))
					.Take(numToTake > 0 ? numToTake : _movies.Count)
					.ToList()
				: _movies.Where(x => x.UserID == userID && !string.IsNullOrWhiteSpace(x.LocationPurchased))
					.GroupBy(y => y.LocationPurchased)
					.OrderByDescending(z => z.Count())
					.Select(w => new Tuple<string, int>(w.Key, w.Count()))
					.Take(numToTake > 0 ? numToTake : _movies.Count)
					.ToList();

		public List<Tuple<int, int>> TopReleaseYears(string userID = "", int numToTake = 0)
			=> string.IsNullOrWhiteSpace(userID)
				? _movies.GroupBy(x => x.YearReleased)
					.OrderByDescending(y => y.Count())
					.Select(z => new Tuple<int, int>(z.Key, z.Count()))
					.Take(numToTake > 0 ? numToTake : _movies.Count)
					.ToList()
				: _movies.Where(x => x.UserID == userID)
					.GroupBy(y => y.YearReleased)
					.OrderByDescending(z => z.Count())
					.Select(w => new Tuple<int, int>(w.Key, w.Count()))
					.Take(numToTake > 0 ? numToTake : _movies.Count)
					.ToList();

		private List<Movie> GetMovies() => _movieService.GetAll();
	}
}