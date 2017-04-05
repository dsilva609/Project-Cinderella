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
    public class BookStatisticServiceTestBase
    {
        protected RhinoAutoMocker<BookStatisticService> _service;

        [SetUp]
        public virtual void SetUp()
        {
            _service = new RhinoAutoMocker<BookStatisticService>();

            _service.Get<IBookService>()
                .Expect(x => x.GetAll())
                .Return(new List<Book>
                {
                    new Book
                    {
                        Title = "The Notebook",
                        Type = BookTypeEnum.Novel,
                        Hardcover = true,
                        IsFirstEdition = true,
                        PageCount = 10,
                        Publisher = "DC",
                        CountryOfOrigin = "US",
                        CountryPurchased = "US",
                        LocationPurchased = "North Coast",
                        TimesCompleted = 5,
                        YearReleased = 2017
                    },
                    new Book
                    {
                        Type = BookTypeEnum.Comic,
                        Hardcover = true,
                        PageCount = 10,
                        Publisher = "DC",
                        CountryOfOrigin = "US",
                        CountryPurchased = "US",
                        LocationPurchased = "North Coast",
                        YearReleased = 2017
                    },
                    new Book
                    {
                        Type = BookTypeEnum.Manga,
                        PageCount = 10
                    }
                });
        }
    }
}