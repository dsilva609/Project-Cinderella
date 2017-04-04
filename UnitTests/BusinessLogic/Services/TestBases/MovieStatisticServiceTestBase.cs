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
                    Director = "Joss Whedon"
                },
                new Movie
                {
                    Director = "Joss Whedon"
                },
                new Movie
                {
                    Director = "Jon Faverau"
                }
            });
        }
    }
}