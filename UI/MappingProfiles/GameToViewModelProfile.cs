using AutoMapper;
using BusinessLogic.Enums;
using BusinessLogic.Models;
using UI.Models;

namespace UI.MappingProfiles
{
	public class GameToViewModelProfile : ITypeConverter<Game, GameViewModel>
	{
		public GameViewModel Convert(Game source, GameViewModel destination, ResolutionContext context) => new GameViewModel
		{
			GameInfo = new GameInfoModel
			{
				Developer = source.Developer,
				Publisher = source.Publisher,
				GiantBombID = source.GiantBombID,
				BGGID = source.BGGID,
				ID = source.ID,
				UserID = source.UserID,
				Title = source.Title,
				Genre = source.Genre,
				Notes = source.Notes,
				ImageUrl = source.ImageUrl,
				YearReleased = source.YearReleased,
				Category = source.Category
			},
			MediaInfo = new GameMediaInfoModel
			{
				Language = source.Language,
				Type = source.Type,
				Rating = source.Rating,
				Platform = source.Platform,
				IsDLC = source.IsDLC,
				PartOfSeries = source.PartOfSeries,
				Series = source.Series,
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
				ItemType = ItemType.Game,
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

	public class ViewModelToGameProfile : ITypeConverter<GameViewModel, Game>
	{
		public Game Convert(GameViewModel source, Game destination, ResolutionContext context) => new Game
		{
			Developer = source.GameInfo.Developer,
			Publisher = source.GameInfo.Publisher,
			Type = source.MediaInfo.Type,
			Rating = source.MediaInfo.Rating,
			Platform = source.MediaInfo.Platform,
			IsDLC = source.MediaInfo.IsDLC,
			PartOfSeries = source.MediaInfo.PartOfSeries,
			Series = source.MediaInfo.Series,
			GiantBombID = source.GameInfo.GiantBombID,
			BGGID = source.GameInfo.BGGID,
			ID = source.GameInfo.ID,
			UserID = source.GameInfo.UserID,
			Title = source.GameInfo.Title,
			Genre = source.GameInfo.Genre,
			Language = source.MediaInfo.Language,
			Notes = source.GameInfo.Notes,
			ImageUrl = source.GameInfo.ImageUrl,
			YearReleased = source.GameInfo.YearReleased,
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
			Category = source.GameInfo.Category,
			TimesCompleted = source.StatusInfo.TimesCompleted,
			CountryOfOrigin = source.MediaInfo.CountryOfOrigin,
			CountryPurchased = source.PurchaseInfo.CountryPurchased,
			IsShowcased = source.StatusInfo.IsShowcased
		};
	}
}