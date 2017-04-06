﻿using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Services.Statistics
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

        public List<string> TopSeries(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _pops.GroupBy(x => x.Series).OrderByDescending(y => y.Count()).Select(z => z.Key).ToList()
                : _pops.Where(x => x.UserID == userID).GroupBy(y => y.Series).OrderByDescending(z => z.Count()).Select(w => w.Key).ToList();

        public List<string> TopLines(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _pops.GroupBy(x => x.PopLine).OrderByDescending(y => y.Count()).Select(z => z.Key).ToList()
                : _pops.Where(x => x.UserID == userID).GroupBy(y => y.PopLine).OrderByDescending(z => z.Count()).Select(w => w.Key).ToList();

        public List<string> TopCountriesOfOrigin(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _pops.GroupBy(x => x.CountryOfOrigin).OrderByDescending(y => y.Count()).Select(z => z.Key).ToList()
                : _pops.Where(x => x.UserID == userID).GroupBy(y => y.CountryOfOrigin).OrderByDescending(z => z.Count()).Select(w => w.Key).ToList();

        public List<string> TopPurchaseCountries(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _pops.GroupBy(x => x.CountryPurchased).OrderByDescending(y => y.Count()).Select(z => z.Key).ToList()
                : _pops.Where(x => x.UserID == userID).GroupBy(y => y.CountryPurchased).OrderByDescending(z => z.Count()).Select(w => w.Key).ToList();

        public List<string> TopLocationsPurchased(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _pops.GroupBy(x => x.LocationPurchased).OrderByDescending(y => y.Count()).Select(z => z.Key).ToList()
                : _pops.Where(x => x.UserID == userID).GroupBy(y => y.LocationPurchased).OrderByDescending(z => z.Count()).Select(w => w.Key).ToList();

        public List<int> TopReleaseYears(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _pops.GroupBy(x => x.YearReleased).OrderByDescending(y => y.Count()).Select(z => z.Key).ToList()
                : _pops.Where(x => x.UserID == userID).GroupBy(y => y.YearReleased).OrderByDescending(z => z.Count()).Select(w => w.Key).ToList();

        private List<FunkoModel> GetPops() => _popService.GetAll();
    }
}