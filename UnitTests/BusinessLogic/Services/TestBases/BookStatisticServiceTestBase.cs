using BusinessLogic.Models;
using BusinessLogic.Services;
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

            _service.Get<BookService>().Expect(x => x.GetAll()).Return(new List<Book>
            {
                new Book
                {
                },
                new Book
                {
                },
                new Book
                {
                }
            });
        }
    }
}