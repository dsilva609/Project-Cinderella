using BusinessLogic.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTests.BusinessLogic.Services.TestBases;

namespace UnitTests.BusinessLogic.Services
{
    public class WishServiceTests : WishServiceTestBase
    {
        private Wish _testModel1;
        private Wish _testModel2;

        private IQueryable<Wish> _wishModels;

        [SetUp]
        protected override void SetUp()
        {
            base.SetUp();

            _testModel1 = new Wish
            {
                ID = 1984,
                Title = "The Last In Line"
            };
            _testModel2 = new Wish
            {
                ID = 1983,
                Title = "Holy Diver"
            };

            _wishModels = new List<Wish>
            {
                _testModel1,
                _testModel2,
                new Wish
                {
                    ID = 1986,
                    Title = "Master Of Puppets"
                },
                new Wish
                {
                    ID = 2004,
                    Title = "Under My Skin"
                }
            }.AsQueryable();
        }

        [Test]
        public void ItAddsWishes()
        {
            //--Arrange
            _repo.Setup(mock => mock.GetAll()).Returns(new List<Wish>().AsQueryable());

            //--Act
            _service.Object.Add(_testModel1);

            //--Assert
            _repo.Verify(mock => mock.Add(It.Is<Wish>(x => x.Equals(_testModel1))), Times.Once);
        }

        [Test]
        public void ItThrowsAnExceptionWhenTryingToAddADuplicateWish()
        {
            //--Arrange
            _repo.Setup(mock => mock.GetAll()).Returns(new List<Wish>
            {
                _testModel1
            }.AsQueryable());

            //--Act/Assert
            Assert.Throws<ApplicationException>(() => _service.Object.Add(_testModel1));
        }

        [Test]
        public void ItDeletesAWish()
        {
            //--Arrange
            _repo.Setup(mock => mock.Add(_testModel2));

            //--Act
            _service.Object.Delete(_testModel2.ID, string.Empty);
            var result = _service.Object.GetByID(_testModel2.ID, string.Empty);

            //--Assert
            Assert.IsNull(result);
        }

        [Test]
        public void ItUpdatesAWish()
        {
            //--Act
            _service.Object.Edit(_testModel2);

            //--Assert
            _repo.Verify(mock => mock.Edit(It.Is<Wish>(x => x.Equals(_testModel2))));
        }

        [Test]
        [TestCase(2, 2)]
        [TestCase(1, 1)]
        public void ItReturnsSpecifiedNumberOfWishes(int numToTake, int expectedResult)
        {
            //--Arrange
            _repo.Setup(mock => mock.GetAll()).Returns(_wishModels);

            //--Act
            var result = _service.Object.GetAll(string.Empty, string.Empty, numToTake);

            //--Assert
            Assert.AreEqual(expectedResult, result.Count);
        }

        [Test]
        public void ItReturnsAllWishesWhenNoParameterIsPassedIn()
        {
            //--Arrange
            _repo.Setup(mock => mock.GetAll()).Returns(_wishModels);

            //--Act
            var result = _service.Object.GetAll();

            //--Assert
            Assert.AreEqual(4, result.Count);
        }

        [Test]
        public void ItOrdersByTitleWhenYouGetAllRecords()
        {
            //--Arrange
            _repo.Setup(mock => mock.GetAll()).Returns(_wishModels);

            //--Act
            var result = _service.Object.GetAll();

            //--Assert
            Assert.AreEqual("Holy Diver", result[0].Title);
            Assert.AreEqual("Master Of Puppets", result[1].Title);
        }

        [Test]
        [TestCase(3, 2, 1)]
        [TestCase(4, 2, 0)]
        [TestCase(2, 1, 2)]
        [TestCase(2, 2, 2)]
        [TestCase(2, 3, 0)]
        [TestCase(5, 1, 4)]
        [TestCase(5, 2, 0)]
        public void ItReturnsSpecifiedNumberOfWishesPerPage(int numToTake, int pageNum, int expectedResult)
        {
            //--Arrange
            _repo.Setup(mock => mock.GetAll()).Returns(_wishModels);

            //--Act
            var result = _service.Object.GetAll(string.Empty, string.Empty, numToTake, pageNum);

            //--Assert
            Assert.AreEqual(expectedResult, result.Count);
        }

        [Test]
        public void ItGetsCountOfRecords()
        {
            //--Arrange
            _repo.Setup(mock => mock.GetCount()).Returns(_wishModels.Count);

            //--Act
            var result = _service.Object.GetCount();

            //--Assert
            Assert.AreEqual(4, result);
        }

        [Test]
        [TestCase("Master", 1)]
        [TestCase("Holy Diver", 1)]
        [TestCase("Taylor Swift", 0)]
        public void ItReturnsWishOfSpecifiedName(string query, int expectedResult)
        {
            //--Arrange
            _repo.Setup(mock => mock.GetAll()).Returns(_wishModels);

            //--Act
            var result = _service.Object.GetAll(string.Empty, query);

            //--Assert
            Assert.AreEqual(expectedResult, result.Count);
        }
    }
}