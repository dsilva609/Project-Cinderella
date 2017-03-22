using System;
using AutoMapper;
using BusinessLogic.Enums;
using BusinessLogic.Models;
using UI.Models;

namespace UI.MappingProfiles
{
	public class MovieToViewModelProfile : ITypeConverter<Movie, MovieViewModel>
	{
		public MovieViewModel Convert(Movie source, MovieViewModel destination, ResolutionContext context) => new MovieViewModel
		{
			MovieInfo = new MovieInfoModel
			{
				Director = source.Director,
				Distributor = source.Distributor,
				ID = source.ID,
				UserID = source.UserID,
				Title = source.Title,
				Genre = source.Genre,
				Notes = source.Notes,
				ImageUrl = source.ImageUrl,
				YearReleased = source.YearReleased,
				Category = source.Category
			},
			MediaInfo = new MovieMediaInfoModel
			{
				Language = source.Language,
				Type = source.Type,
				Rating = source.Rating,
				IsPhysical = source.IsPhysical,
				CountryOfOrigin = source.CountryOfOrigin
			},
			PurchaseInfo = new PurchaseInfoViewModel
			{
				DatePurchased = source.DatePurchased,
				LocationPurchased = source.LocationPurchased,
				IsNew = source.IsNew,
				CountryPurchased = source.CountryPurchased
			},
			StatusInfo = new ItemStatusViewModel
			{
				ItemID = source.ID,
				ItemType = ItemType.Movie,
				DateAdded = source.DateAdded,
				DateStarted = source.DateStarted,
				DateCompleted = source.DateCompleted,
				CompletionStatus = source.CompletionStatus,
				CheckedOut = source.CheckedOut,
				TimesCompleted = source.TimesCompleted,
				IsShowcased = source.IsShowcased
			}
		};
	}

	public class ViewModelToMovieProfile : ITypeConverter<MovieViewModel, Movie>
	{
		public Movie Convert(MovieViewModel source, Movie destination, ResolutionContext context) => new Movie
		{
			Director = source.MovieInfo.Director,
			Type = source.MediaInfo.Type,
			Distributor = source.MovieInfo.Distributor,
			Rating = source.MediaInfo.Rating,
			TMDBID = source.MovieInfo.TMDBID,
			ID = source.MovieInfo.ID,
			UserID = source.MovieInfo.UserID,
			Title = source.MovieInfo.Title,
			Genre = source.MovieInfo.Genre,
			Language = source.MediaInfo.Language,
			Notes = source.MovieInfo.Notes,
			ImageUrl = source.MovieInfo.ImageUrl,
			YearReleased = source.MovieInfo.YearReleased,
			IsPhysical = source.MediaInfo.IsPhysical,
			IsNew = source.PurchaseInfo.IsNew,
			LocationPurchased = source.PurchaseInfo.LocationPurchased,
			DatePurchased = source.PurchaseInfo.DatePurchased,
			DateAdded = source.StatusInfo.DateAdded,
			DateUpdated = source.StatusInfo.DateUpdated,
			CompletionStatus = source.StatusInfo.CompletionStatus,
			DateStarted = source.StatusInfo.DateStarted,
			DateCompleted = source.StatusInfo.DateCompleted,
			CheckedOut = source.StatusInfo.CheckedOut,
			Category = source.MovieInfo.Category,
			TimesCompleted = source.StatusInfo.TimesCompleted,
			CountryOfOrigin = source.MediaInfo.CountryOfOrigin,
			CountryPurchased = source.PurchaseInfo.CountryPurchased,
			IsShowcased = source.StatusInfo.IsShowcased
		};
	}
}