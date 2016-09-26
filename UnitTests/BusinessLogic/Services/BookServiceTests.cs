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
	public class BookServiceTests : BookServiceTestBase
	{
		private Book _testModel1;
		private Book _testModel2;

		private IQueryable<Book> _bookModels;

		[SetUp]
		protected override void SetUp()
		{
			base.SetUp();

			_testModel1 = new Book
			{
				ID = 1984,
				Author = "Rowling",
				Title = "Sorcerer's Stone"
			};
			_testModel2 = new Book
			{
				ID = 1983,
				Author = "Rowling",
				Title = "Half Blood Prince"
			};

			_bookModels = new List<Book>
			{
				_testModel1,
				_testModel2,
				new Book
				{
					ID = 1986,
					Author = "Paolini",
					Title = "Eldest"
				},
				new Book()
				{
					ID = 2004,
					Author = "Nicholas Sparks",
					Title = "The Notebook"
				}
			}.AsQueryable();
		}

		[Test]
		public void ItAddsBooks()
		{
			//--Arrange
			_repo.Setup(mock => mock.GetAll()).Returns(new List<Book>().AsQueryable());

			//--Act
			_service.Object.Add(_testModel1);

			//--Assert
			_repo.Verify(mock => mock.Add(It.Is<Book>(x => x.Equals(_testModel1))), Times.Once);
		}

		[Test]
		public void ItThrowsAnExceptionWhenTryingToAddADuplicateBook()
		{
			//--Arrange
			_repo.Setup(mock => mock.GetAll()).Returns(new List<Book>
			{
				_testModel1
			}.AsQueryable());

			//--Act/Assert
			Assert.Throws<ApplicationException>(() => _service.Object.Add(_testModel1));
		}

		[Test]
		public void ItDeletesBooks()
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
		public void ItUpdatesBooks()
		{
			//--Act
			_service.Object.Edit(_testModel2);

			//--Assert
			_repo.Verify(mock => mock.Edit(It.Is<Book>(x => x.Equals(_testModel2))));
		}

		[Test]
		[TestCase(2, 2)]
		[TestCase(1, 1)]
		public void ItReturnsSpecifiedNumberOfBooks(int numToTake, int expectedResult)
		{
			//--Arrange
			_repo.Setup(mock => mock.GetAll()).Returns(_bookModels);

			//--Act
			var result = _service.Object.GetAll(string.Empty, string.Empty, numToTake);

			//--Assert
			Assert.AreEqual(expectedResult, result.Count);
		}

		[Test]
		public void ItReturnsAllBooksWhenNoParameterIsPassedIn()
		{
			//--Arrange
			_repo.Setup(mock => mock.GetAll()).Returns(_bookModels);

			//--Act
			var result = _service.Object.GetAll();

			//--Assert
			Assert.AreEqual(4, result.Count);
		}

		[Test]
		public void ItOrdersByAuthorThenTitleWhenYouGetAllBooks()
		{
			//--Arrange
			_repo.Setup(mock => mock.GetAll()).Returns(_bookModels);

			//--Act
			var result = _service.Object.GetAll();

			//--Assert
			Assert.AreEqual("Nicholas Sparks", result[0].Author);
			Assert.AreEqual("Paolini", result[1].Author);
		}

		[Test]
		[TestCase(3, 2, 1)]
		[TestCase(4, 2, 0)]
		[TestCase(2, 1, 2)]
		[TestCase(2, 2, 2)]
		[TestCase(2, 3, 0)]
		[TestCase(5, 1, 4)]
		[TestCase(5, 2, 0)]
		public void ItReturnsSpecifiedNumberOfBooksPerPage(int numToTake, int pageNum, int expectedResult)
		{
			//--Arrange
			_repo.Setup(mock => mock.GetAll()).Returns(_bookModels);

			//--Act
			var result = _service.Object.GetAll(string.Empty, string.Empty, numToTake, pageNum);

			//--Assert
			Assert.AreEqual(expectedResult, result.Count);
		}

		[Test]
		public void ItGetsCountOfBooks()
		{
			//--Arrange
			_repo.Setup(mock => mock.GetCount()).Returns(_bookModels.Count);

			//--Act
			var result = _service.Object.GetCount();

			//--Assert
			Assert.AreEqual(4, result);
		}

		[Test]
		[TestCase("Rowling", 2)]
		[TestCase("Half Blood Prince", 1)]
		[TestCase("Eldest", 1)]
		[TestCase("Sparks", 1)]
		[TestCase("Taylor Swift", 0)]
		public void ItReturnsBooksOfSpecifiedName(string query, int expectedResult)
		{
			//--Arrange
			_repo.Setup(mock => mock.GetAll()).Returns(_bookModels);

			//--Act
			var result = _service.Object.GetAll(string.Empty, query);

			//--Assert
			Assert.AreEqual(expectedResult, result.Count);
		}
	}
}