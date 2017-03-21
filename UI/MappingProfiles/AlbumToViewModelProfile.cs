using AutoMapper;
using BusinessLogic.Models;
using UI.Models;

namespace UI.MappingProfiles
{
    public class AlbumToViewModelProfile : ITypeConverter<Album, AlbumViewModel>
    {
        public AlbumViewModel Convert(Album source, AlbumViewModel destination, ResolutionContext context) => new AlbumViewModel
        {
            AlbumInfo = new AlbumInfoModel
            {
                ID = source.ID,
                UserID = source.UserID,
                Title = source.Title,
                Artist = source.Artist,
                Genre = source.Genre,
                Style = source.Style,
                RecordLabel = source.RecordLabel,
                DiscogsID = source.DiscogsID,
                Language = source.Language,
                Notes = source.Notes,
                ImageUrl = source.ImageUrl,
                YearReleased = source.YearReleased,
                Category = source.Category
            },
            MediaInfo = new AlbumMediaInfo
            {
                IsPhysical = source.IsPhysical,
                CountryOfOrigin = source.CountryOfOrigin,
                MediaType = source.MediaType,
                Speed = source.Speed,
                Size = source.Size
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

    public class ViewModelToAlbumProfile : ITypeConverter<AlbumViewModel, Album>
    {
        public Album Convert(AlbumViewModel source, Album destination, ResolutionContext context) => new Album
        {
            Artist = source.AlbumInfo.Artist,
            MediaType = source.MediaInfo.MediaType,
            Style = source.AlbumInfo.Style,
            Speed = source.MediaInfo.Speed,
            Size = source.MediaInfo.Size,
            RecordLabel = source.AlbumInfo.RecordLabel,
            DiscogsID = source.AlbumInfo.DiscogsID,
            Tracklist = source.Tracklist,
            ID = source.AlbumInfo.ID,
            UserID = source.AlbumInfo.UserID,
            Title = source.AlbumInfo.Title,
            Genre = source.AlbumInfo.Genre,
            Language = source.AlbumInfo.Language,
            Notes = source.AlbumInfo.Notes,
            ImageUrl = source.AlbumInfo.ImageUrl,
            YearReleased = source.AlbumInfo.YearReleased,
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
            Category = source.AlbumInfo.Category,
            TimesCompleted = source.StatusInfo.TimesCompleted,
            CountryOfOrigin = source.MediaInfo.CountryOfOrigin,
            CountryPurchased = source.PurchaseInfo.CountryPurchased,
            IsShowcased = source.StatusInfo.IsShowcased
        };
    }
}