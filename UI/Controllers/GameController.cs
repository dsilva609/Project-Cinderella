﻿using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNet.Identity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UI.Models;
using CompletionStatus = BusinessLogic.Enums.CompletionStatus;

namespace UI.Controllers
{
    public partial class GameController : ProjectCinderellaControllerBase
    {
        private readonly IGameService _service;
        private readonly IGiantBombService _giantBombService;
        private readonly IBGGService _bggService;
        private readonly IWishService _wishService;
        private const int NUM_GAMES_TO_GET = 25;

        public GameController(IGameService service, IGiantBombService giantBombService, IBGGService bggService, IWishService wishService)

        {
            _service = service;
            _giantBombService = giantBombService;
            _bggService = bggService;
            _wishService = wishService;
        }

        [HttpGet]
        public virtual ActionResult Index(string gameQuery, string filter, int? page = 1)
        {
            if (string.IsNullOrWhiteSpace(gameQuery) && !string.IsNullOrWhiteSpace(Session["query"]?.ToString()))
            {
                gameQuery = Session["query"].ToString();
                Session["query"] = string.Empty;
            }

            ViewBag.Filter = (string.IsNullOrWhiteSpace(gameQuery) ? filter : gameQuery)?.Trim();

            var games = _service.GetAll(User.Identity.GetUserId(), ViewBag.Filter) as List<Game>;

            var viewModel = new GameViewModel
            {
                ViewTitle = "Index",
                Games = games?.ToPagedList(page ?? 1, NUM_GAMES_TO_GET),
                PageSize = NUM_GAMES_TO_GET
            };

            return View(viewModel);
        }

        [HttpGet]
        public virtual ActionResult Details(int id)
        {
            ViewBag.Title = "Details";
            var model = _service.GetByID(id, User.Identity.GetUserId());

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public virtual ActionResult Create()
        {
            ViewBag.Title = "Create";
            var model = Session["gameResult"] ?? new Game { UserID = User.Identity.GetUserId() };
            Session["gameResult"] = null;

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
                if (game.CompletionStatus == CompletionStatus.Completed && game.TimesCompleted == 0)
                    game.TimesCompleted = 1;
                game.DateAdded = DateTime.UtcNow;
                SetTimeStamps(game);
                this._service.Add(game);
            }
            catch (Exception e)
            {
                ShowStatusMessage(MessageTypeEnum.error, e.Message, "Duplicate Game");
                return View(game);
            }
            Session["query"] = null;
            Session["wish"] = null;
            if (!string.IsNullOrWhiteSpace(Session["wish"]?.ToString()))
            {
                _wishService.Delete(Convert.ToInt32(Session["wishID"].ToString()), User.Identity.GetUserId());
                Session["wishID"] = null;
                ShowStatusMessage(MessageTypeEnum.info, "Wish list has been updated", "Wish list");
            }
            ShowStatusMessage(MessageTypeEnum.success, "New Game Added Successfully.", "Add Successful");
            return RedirectToAction(MVC.Game.Index());
        }

        [Authorize]
        [HttpGet]
        public virtual ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit";
            var model = _service.GetByID(id, User.Identity.GetUserId());
            if (model.UserID != User.Identity.GetUserId())
            {
                ShowStatusMessage(MessageTypeEnum.error, "This game cannot be edited by another user", "Edit Failure");
                return RedirectToAction(MVC.Game.Index());
            }

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(Game game)
        {
            if (!ModelState.IsValid) return View(game);
            var existingGames = _service.GetAll(User.Identity.GetUserId());
            if (existingGames.Count > 0 &&
                existingGames.Any(x => x.ID != game.ID && x.Title == game.Title && x.Developer == game.Developer))
            {
                ShowStatusMessage(MessageTypeEnum.error,
                    $"A Game of Title: {game.Title}, Developer: {game.Developer} already exists.", "Duplicate Game");
                return View(game);
            }

            if (game.CompletionStatus == CompletionStatus.Completed && game.TimesCompleted == 0)
                game.TimesCompleted = 1;
            SetTimeStamps(game);

            //TODO: make sure user id is the same so as not to change other users data
            game.DateUpdated = DateTime.UtcNow;
            _service.Edit(game);

            ShowStatusMessage(MessageTypeEnum.success,
                $"Game of Title {game.Title}, Developer: {game.Developer} updated.", "Update Successful");
            return RedirectToAction(MVC.Game.Index());
        }

        [Authorize]
        [HttpGet]
        public virtual ActionResult Delete(int id)
        {
            var model = _service.GetByID(id, User.Identity.GetUserId());
            if (model.UserID != User.Identity.GetUserId())
            {
                ShowStatusMessage(MessageTypeEnum.error, "This game cannot be deleted by another user", "Delete Failure");
                return RedirectToAction(MVC.Game.Index());
            }

            _service.Delete(id, User.Identity.GetUserId());

            ShowStatusMessage(MessageTypeEnum.success, "", "Game Deleted Successfully");

            return RedirectToAction(MVC.Game.Index());
        }

        //TODO: add tests and validation
        [Authorize]
        [HttpGet]
        public virtual ActionResult Search(GameSearchModel searchModel)
        {
            if (!string.IsNullOrWhiteSpace(searchModel.Title)) searchModel.Title = searchModel.Title.Trim();
            if (!string.IsNullOrWhiteSpace(Session["query"]?.ToString())) searchModel.Title = Session["query"].ToString();
            if (!string.IsNullOrWhiteSpace(Session["wish"]?.ToString())) searchModel.Title = Session["wish"].ToString();

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

            game.UserID = User.Identity.GetUserId();
            Session["gameResult"] = game;

            return RedirectToAction(MVC.Game.Create());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public virtual ActionResult AddToShowcase(int id)
        {
            var game = _service.GetByID(id, User.Identity.GetUserId());
            game.IsShowcased = true;
            _service.Edit(game);

            ShowStatusMessage(MessageTypeEnum.info, "Game added to showcase", "Showcase");
            return RedirectToAction(MVC.Showcase.Index());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public virtual ActionResult RemoveFromShowcase(int id)
        {
            var game = _service.GetByID(id, User.Identity.GetUserId());
            game.IsShowcased = false;
            _service.Edit(game);

            ShowStatusMessage(MessageTypeEnum.info, "Game removed from showcase", "Showcase");
            return RedirectToAction(MVC.Showcase.Index());
        }

        [Authorize]
        [HttpGet]
        public virtual ActionResult IncreaseCompletionCount(int id)
        {
            var game = _service.GetByID(id, User.Identity.GetUserId());

            if (game.UserID != User.Identity.GetUserId())
            {
                ShowStatusMessage(MessageTypeEnum.warning, "This game cannot be edited by another user.", "Edit Failure");
                return RedirectToAction(MVC.Game.Index());
            }

            game.TimesCompleted += 1;
            if (game.CompletionStatus != CompletionStatus.Completed) game.CompletionStatus = CompletionStatus.Completed;
            _service.Edit(game);

            ShowStatusMessage(MessageTypeEnum.info, "Game was updated.", "Update");
            return RedirectToAction(MVC.Game.Index());
        }

        [Authorize]
        [HttpGet]
        public virtual ActionResult DecreaseCompletionCount(int id)
        {
            var game = _service.GetByID(id, User.Identity.GetUserId());

            if (game.UserID != User.Identity.GetUserId())
            {
                ShowStatusMessage(MessageTypeEnum.warning, "This game cannot be edited by another user.", "Edit Failure");
                return RedirectToAction(MVC.Game.Index());
            }

            if (game.TimesCompleted > 0) game.TimesCompleted -= 1;
            if (game.TimesCompleted == 0) game.CompletionStatus = CompletionStatus.NotStarted;

            _service.Edit(game);

            ShowStatusMessage(MessageTypeEnum.info, "Game was updated.", "Update");
            return RedirectToAction(MVC.Game.Index());
        }
    }
}