using BusinessLogic.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnitTests.BusinessLogic.Services.TestBases;

namespace UnitTests.BusinessLogic.Services
{
	[TestFixture]
	public class AlbumServiceTests : AlbumServiceTestBase
	{
		private Album _testModel1;
		private Album _testModel2;

		private List<Album> _recordModels;

		[SetUp]
		protected override void SetUp()
		{
			base.SetUp();

			_testModel1 = new Album
			{
				ID = 1984,
				Artist = "Dio",
				Title = "The Last In Line"
			};
			_testModel2 = new Album
			{
				ID = 1983,
				Artist = "Dio",
				Title = "Holy Diver"
			};

			_recordModels = new List<Album>
			{
				_testModel1,
				_testModel2,
				new Album
				{
					ID = 1986,
					Artist = "Metallica",
					Title = "Master Of Puppets"
				},
				new Album
				{
					ID = 2004,
					Artist = "Avril Lavigne",
					Title = "Under My Skin"
				}
			};
		}

		[Test]
		public void ItAddsRecords()
		{
			//--Arrange
			_repo.Setup(mock => mock.GetAll()).Returns(new List<Album>());

			//--Act
			_service.Object.Add(_testModel1);

			//--Assert
			_repo.Verify(mock => mock.Add(It.Is<Album>(x => x.Equals(_testModel1))), Times.Once);
		}

		[Test]
		public void ItThrowsAnExceptionWhenTryingToAddADuplicateRecord()
		{
			//--Arrange
			_repo.Setup(mock => mock.GetAll()).Returns(new List<Album>
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
			_service.Object.Delete(_testModel2.ID, string.Empty);
			var result = _service.Object.GetByID(_testModel2.ID, string.Empty);

			//--Assert
			Assert.IsNull(result);
		}

		[Test]
		public void ItUpdatesRecords()
		{
			//--Act
			_service.Object.Edit(_testModel2);

			//--Assert
			_repo.Verify(mock => mock.Edit(It.Is<Album>(x => x.Equals(_testModel2))));
		}

		[Test]
		[TestCase(2, 2)]
		[TestCase(1, 1)]
		public void ItReturnsSpecifiedNumberOfRecords(int numToTake, int expectedResult)
		{
			//--Arrange
			_repo.Setup(mock => mock.GetAll()).Returns(_recordModels);

			//--Act
			var result = _service.Object.GetAll(string.Empty, string.Empty, numToTake);

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
			Assert.AreEqual("Holy Diver", result[1].Title);
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
			var result = _service.Object.GetAll(string.Empty, string.Empty, numToTake, pageNum);

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
			var result = _service.Object.GetAll(string.Empty, query);

			//--Assert
			Assert.AreEqual(expectedResult, result.Count);
		}
	}
}