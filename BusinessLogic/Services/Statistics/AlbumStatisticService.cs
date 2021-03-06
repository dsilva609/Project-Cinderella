﻿using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Services.Statistics
{
	public class AlbumStatisticService : IAlbumStatisticService
	{
		private readonly IAlbumService _albumService;
		private readonly List<Album> _albums;

		public AlbumStatisticService(IAlbumService albumService)
		{
			_albumService = albumService;
			_albums = GetAlbums();
		}

		public int NumVinyl(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _albums.Count(x => x.MediaType == AlbumMediaTypeEnum.Vinyl)
				: _albums.Count(x => x.UserID == userID && x.MediaType == AlbumMediaTypeEnum.Vinyl);

		public int NumCD(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _albums.Count(x => x.MediaType == AlbumMediaTypeEnum.CD)
				: _albums.Count(x => x.UserID == userID && x.MediaType == AlbumMediaTypeEnum.CD);

		public int Num3313RPM(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _albums.Count(x => x.Speed == SpeedEnum.RPM33 && x.MediaType == AlbumMediaTypeEnum.Vinyl)
				: _albums.Count(x => x.UserID == userID && x.Speed == SpeedEnum.RPM33 && x.MediaType == AlbumMediaTypeEnum.Vinyl);

		public int Num45RPM(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _albums.Count(x => x.Speed == SpeedEnum.RPM45 && x.MediaType == AlbumMediaTypeEnum.Vinyl)
				: _albums.Count(x => x.UserID == userID && x.Speed == SpeedEnum.RPM45 && x.MediaType == AlbumMediaTypeEnum.Vinyl);

		public int Num78RPM(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _albums.Count(x => x.Speed == SpeedEnum.RPM78 && x.MediaType == AlbumMediaTypeEnum.Vinyl)
				: _albums.Count(x => x.UserID == userID && x.Speed == SpeedEnum.RPM78 && x.MediaType == AlbumMediaTypeEnum.Vinyl);

		public int Num12Inch(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _albums.Count(x => x.Size == SizeEnum.Twelve && x.MediaType == AlbumMediaTypeEnum.Vinyl)
				: _albums.Count(x => x.UserID == userID && x.Size == SizeEnum.Twelve && x.MediaType == AlbumMediaTypeEnum.Vinyl);

		public int Num10Inch(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _albums.Count(x => x.Size == SizeEnum.Ten && x.MediaType == AlbumMediaTypeEnum.Vinyl)
				: _albums.Count(x => x.UserID == userID && x.Size == SizeEnum.Ten && x.MediaType == AlbumMediaTypeEnum.Vinyl);

		public int Num7Inch(string userID = "")
			=> string.IsNullOrWhiteSpace(userID)
				? _albums.Count(x => x.Size == SizeEnum.Seven && x.MediaType == AlbumMediaTypeEnum.Vinyl)
				: _albums.Count(x => x.UserID == userID && x.Size == SizeEnum.Seven && x.MediaType == AlbumMediaTypeEnum.Vinyl);

		public List<Tuple<string, int>> TopArtists(string userID = "", int numToTake = 0)
			=> string.IsNullOrWhiteSpace(userID)
				? _albums.GroupBy(x => x.Artist)
					.OrderByDescending(y => y.Count())
					.Select(z => new Tuple<string, int>(z.Key, z.Count()))
					.Take(numToTake > 0 ? numToTake : _albums.Count)
					.ToList()
				: _albums.Where(x => x.UserID == userID)
					.GroupBy(y => y.Artist)
					.OrderByDescending(z => z.Count())
					.Select(w => new Tuple<string, int>(w.Key, w.Count()))
					.Take(numToTake > 0 ? numToTake : _albums.Count)
					.ToList();

		public List<Tuple<string, int>> TopGenres(string userID = "", int numToTake = 0)
			=> string.IsNullOrWhiteSpace(userID)
				? _albums.Where(w => !string.IsNullOrWhiteSpace(w.Genre))
					.GroupBy(x => x.Genre)
					.OrderByDescending(y => y.Count())
					.Select(z => new Tuple<string, int>(z.Key, z.Count()))
					.Take(numToTake > 0 ? numToTake : _albums.Count)
					.ToList()
				: _albums.Where(x => x.UserID == userID && !string.IsNullOrWhiteSpace(x.Genre))
					.GroupBy(y => y.Genre)
					.OrderByDescending(z => z.Count())
					.Select(w => new Tuple<string, int>(w.Key, w.Count()))
					.Take(numToTake > 0 ? numToTake : _albums.Count)
					.ToList();

		public List<Tuple<string, int>> TopRecordLabels(string userID = "", int numToTake = 0)
			=> string.IsNullOrWhiteSpace(userID)
				? _albums.Where(w => !string.IsNullOrWhiteSpace(w.RecordLabel))
					.GroupBy(x => x.RecordLabel)
					.OrderByDescending(y => y.Count())
					.Select(z => new Tuple<string, int>(z.Key, z.Count()))
					.Take(numToTake > 0 ? numToTake : _albums.Count)
					.ToList()
				: _albums.Where(x => x.UserID == userID && !string.IsNullOrWhiteSpace(x.RecordLabel))
					.GroupBy(y => y.RecordLabel)
					.OrderByDescending(z => z.Count())
					.Select(w => new Tuple<string, int>(w.Key, w.Count()))
					.Take(numToTake > 0 ? numToTake : _albums.Count)
					.ToList();

		public List<Tuple<string, int>> TopCountriesOfOrigin(string userID = "", int numToTake = 0)
			=> string.IsNullOrWhiteSpace(userID)
				? _albums.Where(w => !string.IsNullOrWhiteSpace(w.CountryOfOrigin))
					.GroupBy(x => x.CountryOfOrigin)
					.OrderByDescending(y => y.Count())
					.Select(z => new Tuple<string, int>(z.Key, z.Count()))
					.Take(numToTake > 0 ? numToTake : _albums.Count)
					.ToList()
				: _albums.Where(x => x.UserID == userID && !string.IsNullOrWhiteSpace(x.CountryOfOrigin))
					.GroupBy(y => y.CountryOfOrigin)
					.OrderByDescending(z => z.Count())
					.Select(w => new Tuple<string, int>(w.Key, w.Count()))
					.Take(numToTake > 0 ? numToTake : _albums.Count)
					.ToList();

		public List<Tuple<string, int>> TopPurchaseCountries(string userID = "", int numToTake = 0)
			=> string.IsNullOrWhiteSpace(userID)
				? _albums.Where(w => !string.IsNullOrWhiteSpace(w.CountryPurchased))
					.GroupBy(x => x.CountryPurchased)
					.OrderByDescending(y => y.Count())
					.Select(z => new Tuple<string, int>(z.Key, z.Count()))
					.Take(numToTake > 0 ? numToTake : _albums.Count)
					.ToList()
				: _albums.Where(x => x.UserID == userID && !string.IsNullOrWhiteSpace(x.CountryPurchased))
					.GroupBy(y => y.CountryPurchased)
					.OrderByDescending(z => z.Count())
					.Select(w => new Tuple<string, int>(w.Key, w.Count()))
					.Take(numToTake > 0 ? numToTake : _albums.Count)
					.ToList();

		public List<Tuple<string, int>> MostCompleted(string userID = "", int numToTake = 0)
			=> string.IsNullOrWhiteSpace(userID)
				? _albums.OrderByDescending(x => x.TimesCompleted).Select(y => new Tuple<string, int>($"{y.Artist} - {y.Title}", y.TimesCompleted)).Take(numToTake > 0 ? numToTake : _albums.Count).ToList()
				: _albums.Where(x => x.UserID == userID)
					.OrderByDescending(y => y.TimesCompleted)
					.Select(z => new Tuple<string, int>($"{z.Artist} - {z.Title}", z.TimesCompleted))
					.Take(numToTake > 0 ? numToTake : _albums.Count)
					.ToList();

		public List<Tuple<string, int>> TopLocationsPurchased(string userID = "", int numToTake = 0)
			=> string.IsNullOrWhiteSpace(userID)
				? _albums.Where(w => !string.IsNullOrWhiteSpace(w.LocationPurchased))
					.GroupBy(x => x.LocationPurchased)
					.OrderByDescending(y => y.Count())
					.Select(z => new Tuple<string, int>(z.Key, z.Count()))
					.Take(numToTake > 0 ? numToTake : _albums.Count)
					.ToList()
				: _albums.Where(x => x.UserID == userID && !string.IsNullOrWhiteSpace(x.LocationPurchased))
					.GroupBy(y => y.LocationPurchased)
					.OrderByDescending(z => z.Count())
					.Select(w => new Tuple<string, int>(w.Key, w.Count()))
					.Take(numToTake > 0 ? numToTake : _albums.Count)
					.ToList();

		public List<Tuple<int, int>> TopReleaseYears(string userID = "", int numToTake = 0)
			=> string.IsNullOrWhiteSpace(userID)
				? _albums.GroupBy(x => x.YearReleased)
					.OrderByDescending(y => y.Count())
					.Select(z => new Tuple<int, int>(z.Key, z.Count()))
					.Take(numToTake > 0 ? numToTake : _albums.Count)
					.ToList()
				: _albums.Where(x => x.UserID == userID)
					.GroupBy(y => y.YearReleased)
					.OrderByDescending(z => z.Count())
					.Select(w => new Tuple<int, int>(w.Key, w.Count()))
					.Take(numToTake > 0 ? numToTake : _albums.Count)
					.ToList();

		private List<Album> GetAlbums() => _albumService.GetAll();
	}
}