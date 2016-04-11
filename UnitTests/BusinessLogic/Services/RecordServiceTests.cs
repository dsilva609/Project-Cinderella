using BusinessLogic.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnitTests.BusinessLogic.Services.TestBases;

namespace UnitTests.BusinessLogic.Services
{
    [TestFixture]
    public class RecordServiceTests : RecordServiceTestBase
    {
        private RecordModel _testModel1;
        private RecordModel _testModel2;

        private List<RecordModel> _recordModels;

        [SetUp]
        protected override void SetUp()
        {
            base.SetUp();

            _testModel1 = new RecordModel
            {
                ID = 1984,
                Artist = "Dio",
                AlbumName = "The Last In Line"
            };
            _testModel2 = new RecordModel
            {
                ID = 1983,
                Artist = "Dio",
                AlbumName = "Holy Diver"
            };

            _recordModels = new List<RecordModel>
            {
                _testModel1,
                _testModel2,
                new RecordModel
                {
                    ID = 1986,
                    Artist = "Metallica",
                    AlbumName = "Master Of Puppets"
                },
                new RecordModel
                {
                    ID = 2004,
                    Artist = "Avril Lavigne",
                    AlbumName = "Under My Skin"
                }
            };
        }

        [Test]
        public void ItAddsRecords()
        {
            //--Arrange
            _repo.Setup(mock => mock.GetAll()).Returns(new List<RecordModel>());

            //--Act
            _service.Object.Add(_testModel1);

            //--Assert
            _repo.Verify(mock => mock.Add(It.Is<RecordModel>(x => x.Equals(_testModel1))), Times.Once);
        }

        [Test]
        public void ItThrowsAnExceptionWhenTryingToAddADuplicateRecord()
        {
            //--Arrange
            _repo.Setup(mock => mock.GetAll()).Returns(new List<RecordModel>
            {
                _testModel1
            });

            //--Act/Assert
            Assert.Throws<ApplicationException>(() => _service.Object.Add(_testModel1));
        }

        [Test]
        public void ItDeletesRecords()
        {
            //--Arrange
            _repo.Setup(mock => mock.Add(_testModel2));

            //--Act
            _service.Object.Delete(_testModel2.ID);
            var result = _service.Object.GetByID(_testModel2.ID);

            //--Assert
            Assert.IsNull(result);
        }

        [Test]
        public void ItUpdatesRecords()
        {
            //--Act
            _service.Object.Edit(_testModel2.ID, _testModel2);

            //--Assert
            _repo.Verify(mock => mock.Edit(It.Is<RecordModel>(x => x.Equals(_testModel2))));
        }

        [Test]
        [TestCase(2, 2)]
        [TestCase(1, 1)]
        public void ItReturnsSpecifiedNumberOfRecords(int numToTake, int expectedResult)
        {
            //--Arrange
            _repo.Setup(mock => mock.GetAll()).Returns(_recordModels);

            //--Act
            var result = _service.Object.GetAll(string.Empty, numToTake);

            //--Assert
            Assert.AreEqual(expectedResult, result.Count);
        }

        [Test]
        public void ItReturnsAllRecordsWhenNoParameterIsPassedIn()
        {
            //--Arrange
            _repo.Setup(mock => mock.GetAll()).Returns(_recordModels);

            //--Act
            var result = _service.Object.GetAll();

            //--Assert
            Assert.AreEqual(4, result.Count);
        }

        [Test]
        public void ItOrdersByArtistThenAlbumWhenYouGetAllRecords()
        {
            //--Arrange
            _repo.Setup(mock => mock.GetAll()).Returns(_recordModels);

            //--Act
            var result = _service.Object.GetAll();

            //--Assert
            Assert.AreEqual("Avril Lavigne", result[0].Artist);
            Assert.AreEqual("Holy Diver", result[1].AlbumName);
        }

        [Test]
        [TestCase(3, 2, 1)]
        [TestCase(4, 2, 0)]
        [TestCase(2, 1, 2)]
        [TestCase(2, 2, 2)]
        [TestCase(2, 3, 0)]
        [TestCase(5, 1, 4)]
        [TestCase(5, 2, 0)]
        public void ItReturnsSpecifiedNumberOfRecordsPerPage(int numToTake, int pageNum, int expectedResult)
        {
            //--Arrange
            _repo.Setup(mock => mock.GetAll()).Returns(_recordModels);

            //--Act
            var result = _service.Object.GetAll(string.Empty, numToTake, pageNum);

            //--Assert
            Assert.AreEqual(expectedResult, result.Count);
        }

        [Test]
        public void ItGetsCountOfRecords()
        {
            //--Arrange
            _repo.Setup(mock => mock.GetCount()).Returns(_recordModels.Count);

            //--Act
            var result = _service.Object.GetCount();

            //--Assert
            Assert.AreEqual(4, result);
        }

        [Test]
        [TestCase("Dio", 2)]
        [TestCase("Metallica", 1)]
        [TestCase("Avril Lavigne", 1)]
        [TestCase("Holy Diver", 1)]
        [TestCase("Taylor Swift", 0)]
        public void ItReturnsRecordsOfSpecifiedName(string query, int expectedResult)
        {
            //--Arrange
            _repo.Setup(mock => mock.GetAll()).Returns(_recordModels);

            //--Act
            var result = _service.Object.GetAll(query);

            //--Assert
            Assert.AreEqual(expectedResult, result.Count);
        }
    }
}