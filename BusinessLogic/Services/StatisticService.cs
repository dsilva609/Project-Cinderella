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

		public int GetCollectionCount() => _items.Count;

		public int GetNumNew() => _items.Count(x => x.IsNew);

		public int GetNumUsed() => _items.Count(x => !x.IsNew);

		public int GetNumPhysical() => _items.Count(x => x.IsPhysical);

		public int GetNumDigital() => _items.Count(x => !x.IsPhysical);

		public int GetTimesCompleted() => _items.Sum(x => x.TimesCompleted);

		public int GetNumInProgress() => _items.Count(x => x.CompletionStatus == CompletionStatus.InProgress);

		public int GetNumNotStarted() => _items.Count(x => x.CompletionStatus == CompletionStatus.NotStarted);

		public int GetNumCompleted() => _items.Count(x => x.CompletionStatus == CompletionStatus.Completed);

		public int GetNumCheckedOut() => _items.Count(x => x.CheckedOut);

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