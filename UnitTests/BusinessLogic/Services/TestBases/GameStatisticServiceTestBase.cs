using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using BusinessLogic.Services.Statistics;
using NUnit.Framework;
using Rhino.Mocks;
using StructureMap.AutoMocking;
using System.Collections.Generic;

namespace UnitTests.BusinessLogic.Services.TestBases
{
    public class GameStatisticServiceTestBase
    {
        protected RhinoAutoMocker<GameStatisticService> _service;

        [SetUp]
        public virtual void SetUp()
        {
            _service = new RhinoAutoMocker<GameStatisticService>();

            _service.Get<IGameService>()
                .Expect(x => x.GetAll())
                .Return(new List<Game>
                {
                    new Game
                    {Title = "The Last of Us",
                        Type = GameTypeEnum.FullGame,
                        Rating = GameRatingEnum.E10,
                        Platform = GamePlatformEnum.PlayStation4,
                        Developer = "Naughty Dog",
                        Publisher = "Sony",
                        CountryOfOrigin = "US",
                        CountryPurchased = "US",
                        LocationPurchased = "Amazon",
                        TimesCompleted = 5,
                        YearReleased = 2017
                    },
                    new Game
                    {
                        Type = GameTypeEnum.DLC,
                        Rating = GameRatingEnum.T,
                        Platform = GamePlatformEnum.PC,
                        Developer = "Naughty Dog",
                        Publisher = "Sony",
                        CountryOfOrigin = "US",
                        CountryPurchased = "US",
                        LocationPurchased = "Amazon",
                        TimesCompleted = 3,
                        YearReleased = 2017
                    },
                    new Game
                    {
                        Type = GameTypeEnum.Expansion,
                        Rating = GameRatingEnum.M,
                        Platform = GamePlatformEnum.Boardgame
                    }
                });
        }
    }
}