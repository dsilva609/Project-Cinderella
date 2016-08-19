﻿using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public partial class GameController : ProjectCinderellaControllerBase
    {
        private readonly IGameService _service;
        private readonly IGiantBombService _giantBombService;
        private const int NUM_GAMES_TO_GET = 25;

        public GameController(IGameService service, IGiantBombService giantBombService)
        {
            _service = service;
            _giantBombService = giantBombService;
        }

        [HttpGet]
        public virtual ActionResult Index(string query, int? pageNum = 1)
        {
            var viewModel = new GameViewModel
            {
                ViewTitle = "Index",
                Games = _service.GetAll(User.Identity.GetUserId(), query, NUM_GAMES_TO_GET, pageNum.GetValueOrDefault()),
                PageSize = NUM_GAMES_TO_GET,
                TotalGames = _service.GetCount()
            };
            var pages = Math.Ceiling((double)viewModel.TotalGames / viewModel.PageSize);
            viewModel.PageCount = (int)pages;
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
            var model = Session["GameResult"] ?? new Game { UserID = User.Identity.GetUserId() };
            Session["GameResult"] = null;

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
                game.DateAdded = DateTime.Now;
                this._service.Add(game);
            }
            catch (Exception e)
            {
                ShowStatusMessage(MessageTypeEnum.error, e.Message, "Duplicate Game");
                return View(game);
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

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(Game game)
        {
            if (!ModelState.IsValid) return View(game);
            var existingGames = _service.GetAll(User.Identity.GetUserId(), game.Title);
            if (existingGames.Count > 0 &&
                existingGames.Any(x => x.ID != game.ID && x.Title == game.Title && x.Developer == game.Developer && x.MediaType == game.MediaType))
            {
                ShowStatusMessage(MessageTypeEnum.error,
                    $"A Game of Title: {game.Title}, Developer: {game.Developer}, Media Type: {game.MediaType} already exists.", "Duplicate Game");
                return View(game);
            }
            //--TODO: why is id needed?
            //TODO: make sure user id is the same so as not to change other users data
            game.DateUpdated = DateTime.Now;
            _service.Edit(game.ID, game);

            ShowStatusMessage(MessageTypeEnum.success,
                $"Game of Title {game.Title}, Developer: {game.Developer}, Media Type: {game.MediaType} updated.", "Update Successful");
            return RedirectToAction(MVC.Game.Index());
        }

        [Authorize]
        [HttpGet]
        public virtual ActionResult Delete(int id)
        {
            _service.Delete(id, User.Identity.GetUserId());

            ShowStatusMessage(MessageTypeEnum.success, "", "Game Deleted Successfully");

            return RedirectToAction(MVC.Game.Index());
        }

        //TODO: add tests and validation
        [Authorize]
        [HttpGet]
        public virtual ActionResult Search(GiantBombSearchModel searchModel)
        {
            if (!string.IsNullOrWhiteSpace(searchModel.Title))
            {
                var response = _giantBombService.Search(searchModel.Title);
                searchModel.Games = response;
            }

            ViewBag.Title = "Game Search";
            return View(searchModel);
        }

        [Authorize]
        [HttpGet]
        public virtual ActionResult CreateFromSearchModel(int id)
        {
            ViewBag.Title = "Create";
            var game = _giantBombService.SearchByID(id);

            game.UserID = User.Identity.GetUserId();
            Session["GameResult"] = game;

            return RedirectToAction(MVC.Game.Create());
        }
    }
}