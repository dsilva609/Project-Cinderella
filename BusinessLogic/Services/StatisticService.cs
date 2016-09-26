using BusinessLogic.Services.Interfaces;

namespace BusinessLogic.Services
{
	public class StatisticService : IStatisticService
	{
		private readonly IAlbumService _albumService;
		private readonly IBookService _bookService;
		private readonly IGameService _gameService;
		private readonly IMovieService _movieService;

		public StatisticService(IAlbumService albumService, IBookService bookService, IGameService gameService, IMovieService movieService)
		{
			_albumService = albumService;
			_bookService = bookService;
			_gameService = gameService;
			_movieService = movieService;
		}

		public int GetCollectionCount()
		{
			var count = 0;

			count += _albumService.GetCount();
			count += _bookService.GetCount();
			count += _gameService.GetCount();
			count += _movieService.GetCount();

			return count;
		}

		public int GetNumNew()
		{
			throw new System.NotImplementedException();
		}

		public int GetNumUsed()
		{
			throw new System.NotImplementedException();
		}

		public int GetNumPhysical()
		{
			throw new System.NotImplementedException();
		}

		public int GetNumDigital()
		{
			throw new System.NotImplementedException();
		}

		public int GetTimesCompleted()
		{
			throw new System.NotImplementedException();
		}

		public int GetNumInProgress()
		{
			throw new System.NotImplementedException();
		}

		public int GetNumNotStarted()
		{
			throw new System.NotImplementedException();
		}

		public int GetNumCheckedOut()
		{
			throw new System.NotImplementedException();
		}
	}
}