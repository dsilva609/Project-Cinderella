using System;
using System.Collections.Generic;
using System.Linq;
using ProjectCinderella.BusinessLogic.Services.Interfaces;
using ProjectCinderella.Model.Common;

namespace ProjectCinderella.BusinessLogic.Services.Statistics
{
	public class PopStatisticService : IPopStatisticService
	{
		private readonly IPopService _popService;
		private readonly List<FunkoModel> _pops;

		public PopStatisticService(IPopService popService)
		{
			_popService = popService;
			_pops = GetPops();
		}

		public List<Tuple<string, int>> TopSeries(string userID = "", int numToTake = 0)
			=> string.IsNullOrWhiteSpace(userID)
				? _pops.GroupBy(x => x.Series).OrderByDescending(y => y.Count()).Select(z => new Tuple<string, int>(z.Key, z.Count()))?.Take(numToTake > 0 ? numToTake : _pops.Count).ToList()
				: _pops.Where(x => x.UserID == userID).GroupBy(y => y.Series).OrderByDescending(z => z.Count()).Select(w => new Tuple<string, int>(w.Key, w.Count()))?.Take(numToTake > 0 ? numToTake : _pops.Count).ToList();

		public List<Tuple<string, int>> TopLines(string userID = "", int numToTake = 0)
			=> string.IsNullOrWhiteSpace(userID)
				? _pops.GroupBy(x => x.PopLine).OrderByDescending(y => y.Count()).Select(z => new Tuple<string, int>(z.Key, z.Count()))?.Take(numToTake > 0 ? numToTake : _pops.Count).ToList()
				: _pops.Where(x => x.UserID == userID).GroupBy(y => y.PopLine).OrderByDescending(z => z.Count()).Select(w => new Tuple<string, int>(w.Key, w.Count()))?.Take(numToTake > 0 ? numToTake : _pops.Count).ToList();

		public List<Tuple<string, int>> TopCountriesOfOrigin(string userID = "", int numToTake = 0)
			=> string.IsNullOrWhiteSpace(userID)
				? _pops.Where(w => !string.IsNullOrWhiteSpace(w.CountryOfOrigin))
					.GroupBy(x => x.CountryOfOrigin)
					.OrderByDescending(y => y.Count())
					.Select(z => new Tuple<string, int>(z.Key, z.Count()))
					.Take(numToTake > 0 ? numToTake : _pops.Count)
					.ToList()
				: _pops.Where(x => x.UserID == userID && !string.IsNullOrWhiteSpace(x.CountryOfOrigin))
					.GroupBy(y => y.CountryOfOrigin)
					.OrderByDescending(z => z.Count())
					.Select(w => new Tuple<string, int>(w.Key, w.Count()))
					.Take(numToTake > 0 ? numToTake : _pops.Count)
					.ToList();

		public List<Tuple<string, int>> TopPurchaseCountries(string userID = "", int numToTake = 0)
			=> string.IsNullOrWhiteSpace(userID)
				? _pops.Where(w => !string.IsNullOrWhiteSpace(w.CountryPurchased))
					.GroupBy(x => x.CountryPurchased)
					.OrderByDescending(y => y.Count())
					.Select(z => new Tuple<string, int>(z.Key, z.Count()))
					.Take(numToTake > 0 ? numToTake : _pops.Count)
					.ToList()
				: _pops.Where(x => x.UserID == userID && !string.IsNullOrWhiteSpace(x.CountryPurchased))
					.GroupBy(y => y.CountryPurchased)
					.OrderByDescending(z => z.Count())
					.Select(w => new Tuple<string, int>(w.Key, w.Count()))
					.Take(numToTake > 0 ? numToTake : _pops.Count)
					.ToList();

		public List<Tuple<string, int>> TopLocationsPurchased(string userID = "", int numToTake = 0)
			=> string.IsNullOrWhiteSpace(userID)
				? _pops.Where(w => !string.IsNullOrWhiteSpace(w.LocationPurchased))
					.GroupBy(x => x.LocationPurchased)
					.OrderByDescending(y => y.Count())
					.Select(z => new Tuple<string, int>(z.Key, z.Count()))
					.Take(numToTake > 0 ? numToTake : _pops.Count)
					.ToList()
				: _pops.Where(x => x.UserID == userID && !string.IsNullOrWhiteSpace(x.LocationPurchased))
					.GroupBy(y => y.LocationPurchased)
					.OrderByDescending(z => z.Count())
					.Select(w => new Tuple<string, int>(w.Key, w.Count()))
					.Take(numToTake > 0 ? numToTake : _pops.Count)
					.ToList();

		public List<Tuple<int, int>> TopReleaseYears(string userID = "", int numToTake = 0)
			=> string.IsNullOrWhiteSpace(userID)
				? _pops.GroupBy(x => x.YearReleased)
					.OrderByDescending(y => y.Count())
					.Select(z => new Tuple<int, int>(z.Key, z.Count()))
					.Take(numToTake > 0 ? numToTake : _pops.Count)
					.ToList()
				: _pops.Where(x => x.UserID == userID)
					.GroupBy(y => y.YearReleased)
					.OrderByDescending(z => z.Count())
					.Select(w => new Tuple<int, int>(w.Key, w.Count()))
					.Take(numToTake > 0 ? numToTake : _pops.Count)
					.ToList();

		private List<FunkoModel> GetPops() => _popService.GetAll();
	}
}