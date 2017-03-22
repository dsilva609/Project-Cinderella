using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BusinessLogic.Enums;
using BusinessLogic.Models;
using UI.Models;

namespace UI.MappingProfiles
{
	public class BookToViewModelProfile : ITypeConverter<Book, BookViewModel>
	{
		public BookViewModel Convert(Book source, BookViewModel destination, ResolutionContext context) => new BookViewModel
		{
			BookInfo = new BookInfoModel
			{
				Author = source.Author,
				Publisher = source.Publisher,
				GoogleBookID = source.GoogleBookID,
				ID = source.ID,
				UserID = source.UserID,
				Title = source.Title,
				Genre = source.Genre,
				Notes = source.Notes,
				ImageUrl = source.ImageUrl,
				YearReleased = source.YearReleased,
				Category = source.Category
			},
			MediaInfo = new BookMediaInfoModel
			{
				Language = source.Language,
				Type = source.Type,
				Hardcover = source.Hardcover,
				IsFirstEdition = source.IsFirstEdition,
				PageCount = source.PageCount,
				ISBN10 = source.ISBN10,
				ISBN13 = source.ISBN13,
				IsReissue = source.IsReissue,
				IsPhysical = source.IsPhysical,
				CountryOfOrigin = source.CountryOfOrigin,
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
				ItemType = ItemType.Book,
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

	public class ViewModelToBookProfile : ITypeConverter<BookViewModel, Book>
	{
		public Book Convert(BookViewModel source, Book destination, ResolutionContext context) => new Book
		{
			Author = source.BookInfo.Author,
			Type = source.MediaInfo.Type,
			Hardcover = source.MediaInfo.Hardcover,
			IsFirstEdition = source.MediaInfo.IsFirstEdition,
			Publisher = source.BookInfo.Publisher,
			PageCount = source.MediaInfo.PageCount,
			ISBN10 = source.MediaInfo.ISBN10,
			ISBN13 = source.MediaInfo.ISBN13,
			IsReissue = source.MediaInfo.IsReissue,
			GoogleBookID = source.BookInfo.GoogleBookID,
			ID = source.BookInfo.ID,
			UserID = source.BookInfo.UserID,
			Title = source.BookInfo.Title,
			Genre = source.BookInfo.Genre,
			Language = source.MediaInfo.Language,
			Notes = source.BookInfo.Notes,
			ImageUrl = source.BookInfo.ImageUrl,
			YearReleased = source.BookInfo.YearReleased,
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
			Category = source.BookInfo.Category,
			TimesCompleted = source.StatusInfo.TimesCompleted,
			CountryOfOrigin = source.MediaInfo.CountryOfOrigin,
			CountryPurchased = source.PurchaseInfo.CountryPurchased,
			IsShowcased = source.StatusInfo.IsShowcased
		};
	}
}