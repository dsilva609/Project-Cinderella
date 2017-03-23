using BusinessLogic.Models;
using Moq;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTests.BusinessLogic.Services.TestBases;

namespace UnitTests.BusinessLogic.Services
{
	[TestFixture]
	public class GameServiceTests : GameServiceTestBase
	{
		private Game _testModel1;
		private Game _testModel2;

		private IQueryable<Game> _gameModels;

		[SetUp]
		protected override void SetUp()
		{
			base.SetUp();

			_testModel1 = new Game
			{
				ID = 1984,
				Developer = "Double Fine",
				Title = "Brutal Legend",
				UserID = "TestUser",
				IsQueued = true,
				QueueRank = 2
			};
			_testModel2 = new Game
			{
				ID = 1983,
				Developer = "Double Fine",
				Title = "Psychonauts",
				UserID = "TestUser",
				IsQueued = true,
				QueueRank = 3
			};

			_gameModels = new List<Game>
			{
				_testModel1,
				_testModel2,
				new Game
				{
					ID = 1986,
					Developer = "Niantic",
					Title = "Pokemon GO"
				},
				new Game
				{
					ID = 2004,
					Developer = "Crystal Dynamics",
					Title = "Rise of the Tomb Raider"
				}
			}.AsQueryable();
		}

		[Test]
		public void ItAddsGames()
		{
			//--Arrange
			_repo.Setup(mock => mock.GetAll()).Returns(new List<Game>().AsQueryable());

			//--Act
			_service.Object.Add(_testModel1);

			//--Assert
			_repo.Verify(mock => mock.Add(It.Is<Game>(x => x.Equals(_testModel1))), Times.Once);
		}

		[Test]
		public void ItThrowsAnExceptionWhenTryingToAddADuplicateGame()
		{
			//--Arrange
			_repo.Setup(mock => mock.GetAll()).Returns(new List<Game>
			{
				_testModel1
			}.AsQueryable());

			//--Act/Assert
			Assert.Throws<ApplicationException>(() => _service.Object.Add(_testModel1));
		}

		[Test]
		public void ItDeletesGames()
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
		public void ItUpdatesGames()
		{
			//--Act
			_service.Object.Edit(_testModel2);

			//--Assert
			_repo.Verify(mock => mock.Edit(It.Is<Game>(x => x.Equals(_testModel2))));
		}

		[Test]
		[TestCase(2, 2)]
		[TestCase(1, 1)]
		public void ItReturnsSpecifiedNumberOfGames(int numToTake, int expectedResult)
		{
			//--Arrange
			_repo.Setup(mock => mock.GetAll()).Returns(_gameModels);

			//--Act
			var result = _service.Object.GetAll(string.Empty, string.Empty, numToTake);

			//--Assert
			Assert.AreEqual(expectedResult, result.Count);
		}

		[Test]
		public void ItReturnsAllGamesWhenNoParameterIsPassedIn()
		{
			//--Arrange
			_repo.Setup(mock => mock.GetAll()).Returns(_gameModels);

			//--Act
			var result = _service.Object.GetAll();

			//--Assert
			Assert.AreEqual(4, result.Count);
		}

		[Test]
		public void ItOrdersByTitleThenDeveloperWhenYouGetAllGames()
		{
			//--Arrange
			_repo.Setup(mock => mock.GetAll()).Returns(_gameModels);

			//--Act
			var result = _service.Object.GetAll();

			//--Assert
			Assert.AreEqual("Brutal Legend", result[0].Title);
			Assert.AreEqual("Pokemon GO", result[1].Title);
		}

		[Test]
		[TestCase(3, 2, 1)]
		[TestCase(4, 2, 0)]
		[TestCase(2, 1, 2)]
		[TestCase(2, 2, 2)]
		[TestCase(2, 3, 0)]
		[TestCase(5, 1, 4)]
		[TestCase(5, 2, 0)]
		public void ItReturnsSpecifiedNumberOfGamesPerPage(int numToTake, int pageNum, int expectedResult)
		{
			//--Arrange
			_repo.Setup(mock => mock.GetAll()).Returns(_gameModels);

			//--Act
			var result = _service.Object.GetAll(string.Empty, string.Empty, numToTake, pageNum);

			//--Assert
			Assert.AreEqual(expectedResult, result.Count);
		}

		[Test]
		public void ItGetsCountOfGames()
		{
			//--Arrange
			_repo.Setup(mock => mock.GetCount()).Returns(_gameModels.Count);

			//--Act
			var result = _service.Object.GetCount();

			//--Assert
			Assert.AreEqual(4, result);
		}

		[Test]
		[TestCase("Double Fine", 2)]
		[TestCase("Brutal Legend", 1)]
		[TestCase("Tomb", 1)]
		[TestCase("Psychonauts", 1)]
		[TestCase("Kojima", 0)]
		public void ItReturnsGamesOfSpecifiedName(string query, int expectedResult)
		{
			//--Arrange
			_repo.Setup(mock => mock.GetAll()).Returns(_gameModels);

			//--Act
			var result = _service.Object.GetAll(string.Empty, query);

			//--Assert
			Assert.AreEqual(expectedResult, result.Count);
		}

		[Test]
		public void ItGetsCurrentQueueRank()
		{
			_repo.Setup(x => x.GetAll()).Returns(_gameModels);

			var result = _service.Object.GetHighestQueueRank("TestUser");

			result.ShouldBe(3);
		}
	}
}