using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using BusinessLogic.Services.Statistics;
using NUnit.Framework;
using Rhino.Mocks;
using StructureMap.AutoMocking;
using System.Collections.Generic;

namespace UnitTests.BusinessLogic.Services.TestBases
{
    public class PopStatisticServiceTestBase
    {
        protected RhinoAutoMocker<PopStatisticService> _service;

        [SetUp]
        public virtual void SetUp()
        {
            _service = new RhinoAutoMocker<PopStatisticService>();

            _service.Get<IPopService>().Expect(x => x.GetAll()).Return(new List<FunkoModel>
            {
                new FunkoModel
                {
                    Series = "DC",
                    PopLine = "Pop",
                    CountryOfOrigin = "US",
                    CountryPurchased = "US",
                    LocationPurchased = "Amazon",
                    YearReleased = 2017
                },
                new FunkoModel
                {
                    Series = "DC",
                    PopLine = "Pop",
                    CountryOfOrigin = "US",
                    CountryPurchased = "US",
                    LocationPurchased = "Amazon",
                    YearReleased = 2017
                },
                new FunkoModel { Series = "Marvel" }
            });
        }
    }
}