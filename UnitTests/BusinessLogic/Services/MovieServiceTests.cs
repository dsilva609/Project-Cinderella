using BusinessLogic.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTests.BusinessLogic.Services.TestBases;

namespace UnitTests.BusinessLogic.Services
{
	[TestFixture]
	public class MovieServiceTests : MovieServiceTestBase
	{
		private Movie _testModel1;
		private Movie _testModel2;

		private IQueryable<Movie> _MovieModels;

		[SetUp]
		protected override void SetUp()
		{
			base.SetUp();

			_testModel1 = new Movie
			{
				ID = 1984,
				Director = "Sam Raimi",
				Title = "Spider Man"
			};
			_testModel2 = new Movie
			{
				ID = 1983,
				Director = "Sam Raimi",
				Title = "Evil Dead"
			};

			_MovieModels = new List<Movie>
			{
				_testModel1,
				_testModel2,
				new Movie
				{
					ID = 1986,
					Director = "Zack Snyder",
					Title = "Batman vs Superman"
				},
				new Movie()
				{
					ID = 2004,
					Director = "Steven Spielberg",
					Title = "Raiders"
				}
			}.AsQueryable();
		}

		[Test]
		public void ItAddsMovies()
		{
			//--Arrange
			_repo.Setup(mock => mock.GetAll()).Returns(new List<Movie>().AsQueryable());

			//--Act
			_service.Object.Add(_testModel1);

			//--Assert
			_repo.Verify(mock => mock.Add(It.Is<Movie>(x => x.Equals(_testModel1))), Times.Once);
		}

		[Test]
		public void ItThrowsAnExceptionWhenTryingToAddADuplicateMovie()
		{
			//--Arrange
			_repo.Setup(mock => mock.GetAll()).Returns(new List<Movie>
			{
				_testModel1
			}.AsQueryable());

			//--Act/Assert
			Assert.Throws<ApplicationException>(() => _service.Object.Add(_testModel1));
		}

		[Test]
		public void ItDeletesMovies()
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
		public void ItUpdatesMovies()
		{
			//--Act
			_service.Object.Edit(_testModel2);

			//--Assert
			_repo.Verify(mock => mock.Edit(It.Is<Movie>(x => x.Equals(_testModel2))));
		}

		[Test]
		[TestCase(2, 2)]
		[TestCase(1, 1)]
		public void ItReturnsSpecifiedNumberOfMovies(int numToTake, int expectedResult)
		{
			//--Arrange
			_repo.Setup(mock => mock.GetAll()).Returns(_MovieModels);

			//--Act
			var result = _service.Object.GetAll(string.Empty, string.Empty, numToTake);

			//--Assert
			Assert.AreEqual(expectedResult, result.Count);
		}

		[Test]
		public void ItReturnsAllMoviesWhenNoParameterIsPassedIn()
		{
			//--Arrange
			_repo.Setup(mock => mock.GetAll()).Returns(_MovieModels);

			//--Act
			var result = _service.Object.GetAll();

			//--Assert
			Assert.AreEqual(4, result.Count);
		}

		[Test]
		public void ItOrdersByTitleWhenYouGetAllMovies()
		{
			//--Arrange
			_repo.Setup(mock => mock.GetAll()).Returns(_MovieModels);

			//--Act
			var result = _service.Object.GetAll();

			//--Assert
			Assert.AreEqual("Batman vs Superman", result[0].Title);
			Assert.AreEqual("Evil Dead", result[1].Title);
		}

		[Test]
		[TestCase(3, 2, 1)]
		[TestCase(4, 2, 0)]
		[TestCase(2, 1, 2)]
		[TestCase(2, 2, 2)]
		[TestCase(2, 3, 0)]
		[TestCase(5, 1, 4)]
		[TestCase(5, 2, 0)]
		public void ItReturnsSpecifiedNumberOfMoviesPerPage(int numToTake, int pageNum, int expectedResult)
		{
			//--Arrange
			_repo.Setup(mock => mock.GetAll()).Returns(_MovieModels);

			//--Act
			var result = _service.Object.GetAll(string.Empty, string.Empty, numToTake, pageNum);

			//--Assert
			Assert.AreEqual(expectedResult, result.Count);
		}

		[Test]
		public void ItGetsCountOfMovies()
		{
			//--Arrange
			_repo.Setup(mock => mock.GetCount()).Returns(_MovieModels.Count);

			//--Act
			var result = _service.Object.GetCount();

			//--Assert
			Assert.AreEqual(4, result);
		}

		[Test]
		[TestCase("Sam Raimi", 2)]
		[TestCase("Superman", 1)]
		[TestCase("Raiders", 1)]
		[TestCase("Spielberg", 1)]
		[TestCase("Taylor Swift", 0)]
		public void ItReturnsMoviesOfSpecifiedName(string query, int expectedResult)
		{
			//--Arrange
			_repo.Setup(mock => mock.GetAll()).Returns(_MovieModels);

			//--Act
			var result = _service.Object.GetAll(string.Empty, query);

			//--Assert
			Assert.AreEqual(expectedResult, result.Count);
		}
	}
}