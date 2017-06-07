using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using ProjectCinderella.Model.Interfaces;
using ProjectCinderella.BusinessLogic.Services.Interfaces;
using ProjectCinderella.Model.Common;
using ProjectCinderella.Model.UI;
using ProjectCinderella.Model.Enums;
using System.Linq;

namespace ProjectCinderellaCore.Controllers
{
	public class GameController : ProjectCinderellaControllerBase
	{
		private readonly IUserContext _user;
		private readonly IGameService _service;
		private readonly IGiantBombService _giantBombService;
		private readonly IBGGService _bggService;
		private readonly IWishService _wishService;
		private const int NUM_GAMES_TO_GET = 25;

		public GameController(IUserContext user, IGameService service, IGiantBombService giantBombService, IBGGService bggService,
			IWishService wishService)

		{
			_user = user;
			_service = service;
			_giantBombService = giantBombService;
			_bggService = bggService;
			_wishService = wishService;
		}

		[HttpGet]
		public virtual ActionResult Index(string gameQuery, string filter, int? page = 1)
		{
			if (string.IsNullOrWhiteSpace(gameQuery) && !string.IsNullOrWhiteSpace(HttpContext.Session.GetString("game-query")))
			{
				gameQuery = HttpContext.Session.GetString("game-query");
				HttpContext.Session.SetString("game-query", string.Empty);
			}

			ViewBag.Filter = (string.IsNullOrWhiteSpace(gameQuery) ? filter : gameQuery)?.Trim();

			var games = _service.GetAll(string.Empty, ViewBag.Filter) as List<Game>;

			var viewModel = new GameViewModel
			{
				ViewTitle = "Games",
				Games = games?.ToPagedList(page ?? 1, NUM_GAMES_TO_GET),
				PageSize = NUM_GAMES_TO_GET
			};

			return View(viewModel);
		}

		[HttpGet]
		public virtual ActionResult Details(int id)
		{
			var model = _service.GetByID(id, _user.GetUserID());
			ViewBag.Title = $"Details - {model.Title}";
			return View(model);
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Create()
		{
			ViewBag.Title = "Create";
			var model = HttpContext.Session.Get("gameResult") ?? new Game { UserID = _user.GetUserID(), UserNum = _user.GetUserNum() };
			HttpContext.Session.Set("gameResult",  null);

			return View(model);
		}

		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult Create(Game game)
		{
			if (!ModelState.IsValid) return View(game);
			try
			{
				if (game.CompletionStatus == ProjectCinderella.Model.Enums.CompletionStatus.Completed && game.TimesCompleted == 0)
					game.TimesCompleted = 1;
				game.DateAdded = DateTime.UtcNow;
				SetTimeStamps(game);
				this._service.Add(game);
			}
			catch (Exception e)
			{
				ShowStatusMessage(ProjectCinderella.Model.Enums.MessageTypeEnum.error, e.Message, "Duplicate Game");
				return View(game);
			}
			HttpContext.Session.Set("game-query", null);

			if (!string.IsNullOrWhiteSpace(HttpContext.Session.GetString("wish")))
			{
				_wishService.Delete(Convert.ToInt32(HttpContext.Session.GetString("wishID")), _user.GetUserID());
				HttpContext.Session.Set("wish", null);
				HttpContext.Session.Set("wishID", null);
				ShowStatusMessage(ProjectCinderella.Model.Enums.MessageTypeEnum.info, "Wish list has been updated", "Wish list");
			}
			ShowStatusMessage(MessageTypeEnum.success, "New Game Added Successfully.", "Add Successful");
			return RedirectToAction("Index", "Game");
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Edit(int id)
		{
			var model = _service.GetByID(id, _user.GetUserID());
			ViewBag.Title = $"Edit - {model.Title}";
			if (model.UserID != _user.GetUserID()) return RedirectToAction("Details", "Game", (object) model.ID);

			return View(model);
		}

		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult Edit(Game game)
		{
			if (!ModelState.IsValid) return View(game);
			var existingGames = _service.GetAll(_user.GetUserID());
			if (existingGames.Count() > 0 &&
				existingGames.Any(x => x.ID != game.ID && x.Title == game.Title && x.Developer == game.Developer))
			{
				ShowStatusMessage(ProjectCinderella.Model.Enums.MessageTypeEnum.error,
					$"A Game of Title: {game.Title}, Developer: {game.Developer} already exists.", "Duplicate Game");
				return View(game);
			}

			if (game.CompletionStatus == ProjectCinderella.Model.Enums.CompletionStatus.Completed && game.TimesCompleted == 0)
				game.TimesCompleted = 1;
			if (game.TimesCompleted > 0) game.CompletionStatus = ProjectCinderella.Model.Enums.CompletionStatus.Completed;
			SetTimeStamps(game);

			//TODO: make sure user id is the same so as not to change other users data
			game.DateUpdated = DateTime.UtcNow;
			_service.Edit(game);

			ShowStatusMessage(ProjectCinderella.Model.Enums.MessageTypeEnum.success,
				$"Game of Title {game.Title}, Developer: {game.Developer} updated.", "Update Successful");
			return RedirectToAction("Index", "Game");
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Delete(int id)
		{
			var model = _service.GetByID(id, _user.GetUserID());
			if (model.UserID != _user.GetUserID())
			{
				ShowStatusMessage(MessageTypeEnum.error, "This game cannot be deleted by another user", "Delete Failure");
				return RedirectToAction("Index", "Game");
			}

			_service.Delete(id, _user.GetUserID());

			ShowStatusMessage(MessageTypeEnum.success, "", "Game Deleted Successfully");

			return RedirectToAction("Index", "Game");
		}

		//TODO: add tests and validation
		[Authorize]
		[HttpGet]
		public virtual ActionResult Search(GameSearchModel searchModel)
		{
			if (!string.IsNullOrWhiteSpace(searchModel.Title)) searchModel.Title = searchModel.Title.Trim();
			if (!string.IsNullOrWhiteSpace(HttpContext.Session.GetString("game-query"))) searchModel.Title = HttpContext.Session.GetString("game-query");
			if (!string.IsNullOrWhiteSpace(HttpContext.Session.GetString("wish"))) searchModel.Title = HttpContext.Session.GetString("wish");

			if (Request.UrlReferrer?.LocalPath == "/Game/Search" && string.IsNullOrWhiteSpace(searchModel.Title))
			{
				ShowStatusMessage(MessageTypeEnum.error, "Please enter search terms.", "Search Error");
				return View(searchModel);
			}

			if (!string.IsNullOrWhiteSpace(searchModel.Title))
			{
				searchModel.GiantBombResult = _giantBombService.Search(searchModel.Title);
				searchModel.BGGResult = _bggService.Search(searchModel.Title);
			}

			ViewBag.Title = "Game Search";
			return View(searchModel);
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult CreateFromSearchModel(int id, bool isBGG)
		{
			ViewBag.Title = "Create";
			var game = isBGG ? _bggService.SearchByID(id) : _giantBombService.SearchByID(id);

			game.UserID = _user.GetUserID();
			game.UserNum = _user.GetUserNum();
			HttpContext.Session.Set("gameResult", game);

			return RedirectToAction("Create", "Game");
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public virtual ActionResult AddToShowcase(int id)
		{
			var game = _service.GetByID(id, _user.GetUserID());
			game.IsShowcased = true;
			game.DateUpdated = DateTime.UtcNow;
			_service.Edit(game);

			ShowStatusMessage(MessageTypeEnum.info, "Game added to showcase", "Showcase");
			return RedirectToAction("Index", "Showcase",(object) _user.GetUserNum());
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public virtual ActionResult RemoveFromShowcase(int id)
		{
			var game = _service.GetByID(id, _user.GetUserID());
			game.IsShowcased = false;
			game.DateUpdated = DateTime.UtcNow;
			_service.Edit(game);

			ShowStatusMessage(MessageTypeEnum.info, "Game removed from showcase", "Showcase");
			return RedirectToAction("Index", "Showcase",(object) _user.GetUserNum());
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult IncreaseCompletionCount(int id)
		{
			var game = _service.GetByID(id, _user.GetUserID());

			if (game.UserID != _user.GetUserID())
			{
				ShowStatusMessage(MessageTypeEnum.warning, "This game cannot be edited by another user.", "Edit Failure");
				return RedirectToAction("Index", "Game");
			}

			game.TimesCompleted += 1;
			game.CompletionStatus = ProjectCinderella.Model.Enums.CompletionStatus.Completed;
			game.DateUpdated = DateTime.UtcNow;
			_service.Edit(game);

			ShowStatusMessage(MessageTypeEnum.info, "Game was updated.", "Update");
			return RedirectToAction("Index", "Game");
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult DecreaseCompletionCount(int id)
		{
			var game = _service.GetByID(id, _user.GetUserID());

			if (game.UserID != _user.GetUserID())
			{
				ShowStatusMessage(MessageTypeEnum.warning, "This game cannot be edited by another user.", "Edit Failure");
				return RedirectToAction("Index","Game");
			}

			if (game.TimesCompleted > 0) game.TimesCompleted -= 1;
			if (game.TimesCompleted == 0) game.CompletionStatus = ProjectCinderella.Model.Enums.CompletionStatus.NotStarted;
			game.DateUpdated = DateTime.UtcNow;
			_service.Edit(game);

			ShowStatusMessage(MessageTypeEnum.info, "Game was updated.", "Update");
			return RedirectToAction("Index", "Game");
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult AddToQueue(int id)
		{
			var game = _service.GetByID(id, _user.GetUserID());

			if (game.UserID != _user.GetUserID())
			{
				ShowStatusMessage(MessageTypeEnum.error, "This game cannot be edited by another user.", "Edit Failure");
				return RedirectToAction("Index", "Game");
			}

			if (game.IsQueued)
			{
				ShowStatusMessage(MessageTypeEnum.warning, "This game is already queued.", "Edit Failure");
				return RedirectToAction("Index", "Game");
			}

			game.IsQueued = true;
			var currentHighestRank = _service.GetHighestQueueRank(_user.GetUserID());
			game.QueueRank = currentHighestRank + 1;

			_service.Edit(game);

			ShowStatusMessage(MessageTypeEnum.info, "Game added to queue", "Queue");
			return RedirectToAction("Index", "Queue");
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult RemoveFromQueue(int id)
		{
			var game = _service.GetByID(id, _user.GetUserID());

			if (game.UserID != _user.GetUserID())
			{
				ShowStatusMessage(MessageTypeEnum.error, "This game cannot be edited by another user.", "Edit Failure");
				return RedirectToAction("Index", "Game");
			}

			game.IsQueued = false;
			game.QueueRank = 0;

			_service.Edit(game);

			ShowStatusMessage(MessageTypeEnum.info, "Game removed from queue,", "Queue");
			return RedirectToAction("Index", "Queue");
		}
	}
}