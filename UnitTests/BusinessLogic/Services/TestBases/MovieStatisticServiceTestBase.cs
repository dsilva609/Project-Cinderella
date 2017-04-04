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
    public class MovieStatisticServiceTestBase
    {
        protected RhinoAutoMocker<MovieStatisticService> _service;

        [SetUp]
        public virtual void SetUp()
        {
            _service = new RhinoAutoMocker<MovieStatisticService>();

            _service.Get<IMovieService>().Expect(x => x.GetAll()).Return(new List<Movie>
            {
                new Movie
                {
                    Title = "Avengers",
                    Director = "Joss Whedon",
                    Type = MovieMediaTypeEnum.DVD,
                    Rating = MovieRatingEnum.PG13,
                    CountryOfOrigin = "US",
                    CountryPurchased = "US",
                    LocationPurchased = "Ebay",
                    TimesCompleted = 5,
                    YearReleased = 2017
                },
                new Movie
                {
                    Title = "Batgirl",
                    Director = "Joss Whedon",
                    Type = MovieMediaTypeEnum.Bluray,
                    Rating = MovieRatingEnum.PG,
                    CountryOfOrigin = "US",
                    CountryPurchased = "US",
                    LocationPurchased = "Ebay",
                    TimesCompleted = 4,
                    YearReleased = 2017
                },
                new Movie
                {
                    Director = "Jon Faverau",
                    Type = MovieMediaTypeEnum.Bluray,
                    Rating = MovieRatingEnum.R,
                    CountryOfOrigin = "US",
                    CountryPurchased = "US",
                    LocationPurchased = "Ebay",
                    TimesCompleted = 3,
                    YearReleased = 2017
                }
            });
        }
    }
}