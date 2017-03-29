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
	public class PopServiceTests : PopServiceTestBase
	{
		private FunkoModel _testModel1;
		private FunkoModel _testModel2;

		private IQueryable<FunkoModel> _pops;

		[SetUp]
		protected override void SetUp()
		{
			base.SetUp();

			_testModel1 = new FunkoModel
			{
				ID = 666,
				Title = "Wonder Woman",
				Series = "DC",
				PopLine = "Pop Vinyl"
			};

			_testModel2 = new FunkoModel
			{
				ID = 42,
				Title = "Joker",
				Series = "DC",
				PopLine = "Pop Vinyl"
			};

			_pops = new List<FunkoModel>
			{
				_testModel1,
				_testModel2,
				new FunkoModel
				{
					ID = 13,
					Title = "Death",
					Series = "Vertigo",
					PopLine = "Pop Vinyl",
					Number = 3
				},
				new FunkoModel
				{
					ID = 1983,
					Title = "Death",
					Series = "Vertigo",
					PopLine = "Vinyl",
					Number = 4
				}
			}.AsQueryable();
		}

		[Test]
		public void ItAddsPops()
		{
			_repo.Setup(mock => mock.GetAll()).Returns(new List<FunkoModel>().AsQueryable());

			_service.Object.Add(_testModel1);

			_repo.Verify(mock => mock.Add(It.Is<FunkoModel>(x => x.Equals(_testModel1))), Times.Once);
		}

		[Test]
		public void ItThrowsAnExceptionWhenTryingToAddADuplicate()
		{
			_repo.Setup(x => x.GetAll()).Returns(new List<FunkoModel> {_testModel1}.AsQueryable());

			Assert.Throws<ApplicationException>(() => _service.Object.Add(_testModel1));
		}

		[Test]
		public void ItDeletesPops()
		{
			_repo.Setup(x => x.Add(_testModel2));

			_service.Object.Delete(_testModel2.ID, string.Empty);
			var result = _service.Object.GetByID(_testModel2.ID, string.Empty);

			result.ShouldBeNull();
		}

		[Test]
		public void ItGetsPopByID()
		{
			_repo.Setup(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>())).Returns(_testModel2);

			var result = _service.Object.GetByID(_testModel2.ID, _testModel2.UserID);

			result.ShouldNotBeNull();
		}

		[Test]
		public void ItUpdatesPops()
		{
			_service.Object.Edit(_testModel2);

			_repo.Verify(mock => mock.Edit(It.Is<FunkoModel>(x => x.Equals(_testModel2))));
		}

		[Test]
		[TestCase(2, 2)]
		[TestCase(1, 1)]
		public void ItReturnsSpecifiedNumberOfPops(int numToTake, int expectedResult)
		{
			_repo.Setup(mock => mock.GetAll()).Returns(_pops);

			var result = _service.Object.GetAll(string.Empty, string.Empty, numToTake);

			Assert.AreEqual(expectedResult, result.Count);
		}

		[Test]
		public void ItReturnsAllPopsWhenNoParameterIsPassedIn()
		{
			_repo.Setup(mock => mock.GetAll()).Returns(_pops);

			var result = _service.Object.GetAll();

			Assert.AreEqual(4, result.Count);
		}

		[Test]
		public void ItOrdersByNameThenSeriesThenNumberWhenYouGetAllPops()
		{
			_repo.Setup(mock => mock.GetAll()).Returns(_pops);

			var result = _service.Object.GetAll();

			Assert.AreEqual("Death", result[0].Title);
			Assert.AreEqual(4, result[1].Number);
		}

		[Test]
		[TestCase(3, 2, 1)]
		[TestCase(4, 2, 0)]
		[TestCase(2, 1, 2)]
		[TestCase(2, 2, 2)]
		[TestCase(2, 3, 0)]
		[TestCase(5, 1, 4)]
		[TestCase(5, 2, 0)]
		public void ItReturnsSpecifiedNumberOfPopsPerPage(int numToTake, int pageNum, int expectedResult)
		{
			_repo.Setup(mock => mock.GetAll()).Returns(_pops);

			var result = _service.Object.GetAll(string.Empty, string.Empty, numToTake, pageNum);

			Assert.AreEqual(expectedResult, result.Count);
		}

		[Test]
		public void ItGetsCountOfPops()
		{
			_repo.Setup(mock => mock.GetCount()).Returns(_pops.Count);

			var result = _service.Object.GetCount();

			Assert.AreEqual(4, result);
		}

		[Test]
		[TestCase("Wonder Woman", 1)]
		[TestCase("Death", 2)]
		[TestCase("Joker", 1)]
		public void ItReturnsPopsOfSpecifiedName(string query, int expectedResult)
		{
			_repo.Setup(mock => mock.GetAll()).Returns(_pops);

			var result = _service.Object.GetAll(string.Empty, query);

			Assert.AreEqual(expectedResult, result.Count);
		}
	}
}