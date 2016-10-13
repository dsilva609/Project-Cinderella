using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IAlbumService _albumService;
        private readonly IBookService _bookService;
        private readonly IGameService _gameService;
        private readonly IMovieService _movieService;
        private readonly List<BaseItem> _items;

        public StatisticService(IAlbumService albumService, IBookService bookService, IGameService gameService, IMovieService movieService)
        {
            _albumService = albumService;
            _bookService = bookService;
            _gameService = gameService;
            _movieService = movieService;
            _items = GetAllItems();
        }

        public int GetCollectionCount(string userID = "") =>
            string.IsNullOrWhiteSpace(userID) ? _items.Count : _items.Count(x => x.UserID == userID);

        public int GetNumNew(string userID = "")
            => string.IsNullOrWhiteSpace(userID) ? _items.Count(x => x.IsNew) : _items.Count(x => x.UserID == userID && x.IsNew);

        public int GetNumUsed(string userID = "")
            => string.IsNullOrWhiteSpace(userID) ? _items.Count(x => !x.IsNew) : _items.Count(x => x.UserID == userID && !x.IsNew);

        public int GetNumPhysical(string userID = "")
            => string.IsNullOrWhiteSpace(userID) ? _items.Count(x => x.IsPhysical) : _items.Count(x => x.UserID == userID && x.IsPhysical);

        public int GetNumDigital(string userID = "")
            => string.IsNullOrWhiteSpace(userID) ? _items.Count(x => !x.IsPhysical) : _items.Count(x => x.UserID == userID && !x.IsPhysical);

        public int GetTimesCompleted(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _items.Sum(x => x.TimesCompleted)
                : _items.Where(x => x.UserID == userID).Sum(y => y.TimesCompleted);

        public int GetNumInProgress(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _items.Count(x => x.CompletionStatus == CompletionStatus.InProgress)
                : _items.Count(x => x.UserID == userID && x.CompletionStatus == CompletionStatus.InProgress);

        public int GetNumNotStarted(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _items.Count(x => x.CompletionStatus == CompletionStatus.NotStarted)
                : _items.Count(x => x.UserID == userID && x.CompletionStatus == CompletionStatus.NotStarted);

        public int GetNumCompleted(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _items.Count(x => x.CompletionStatus == CompletionStatus.Completed)
                : _items.Count(x => x.UserID == userID && x.CompletionStatus == CompletionStatus.Completed);

        public int GetNumCheckedOut(string userID = "")
            => string.IsNullOrWhiteSpace(userID) ? _items.Count(x => x.CheckedOut) : _items.Count(x => x.UserID == userID && x.CheckedOut);

        public int GetNumAlbums(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _items.Count(x => x.GetType() == typeof(Album))
                : _items.Count(x => x.UserID == userID && x.GetType() == typeof(Album));

        public int GetNumBooks(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _items.Count(x => x.GetType() == typeof(Book))
                : _items.Count(x => x.UserID == userID && x.GetType() == typeof(Book));

        public int GetNumMoviesShows(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _items.Count(x => x.GetType() == typeof(Movie))
                : _items.Count(x => x.UserID == userID && x.GetType() == typeof(Movie));

        public int GetNumGames(string userID = "")
            => string.IsNullOrWhiteSpace(userID)
                ? _items.Count(x => x.GetType() == typeof(Game))
                : _items.Count(x => x.UserID == userID && x.GetType() == typeof(Game));

        private List<BaseItem> GetAllItems()
        {
            var items = new List<BaseItem>();

            items.AddRange(_albumService.GetAll());
            items.AddRange(_bookService.GetAll());
            items.AddRange(_gameService.GetAll());
            items.AddRange(_movieService.GetAll());

            return items;
        }
    }
}