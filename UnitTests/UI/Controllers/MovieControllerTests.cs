using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Models.TMDBModels;
using BusinessLogic.Services.Interfaces;
using Moq;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;
using System.Collections.Generic;
using System.Web.Mvc;
using UI.Models;
using UnitTests.UI.Controllers.TestBases;

namespace UnitTests.UI.Controllers
{
	[TestFixture]
	public class MovieControllerTests : MovieControllerTestBase
	{
		private Movie _testModel = new Movie();

		[Test]
		public void ThatIndexActionReturnsAView()
		{
			_session["query"] = string.Empty;
			//--Act
			var result = _controller.ClassUnderTest.Index(string.Empty, string.Empty, 1) as ViewResult;

			//--Assert
			Assert.AreEqual(string.Empty, result.ViewName);
		}

		[Test]
		public void ThatDetailsActionRetunsAView()
		{
			//--Act
			var result = _controller.ClassUnderTest.Details(72) as ViewResult;

			//--Assert
			Assert.AreEqual(string.Empty, result.ViewName);
		}

		[Test]
		public void ThatCreateActionReturnsAView()
		{
			//--Act
			var result = _controller.ClassUnderTest.Create() as ViewResult;

			//--Assert
			Assert.AreEqual(string.Empty, result.ViewName);
		}

		[Test]
		public void ItRedirectsToIndexActionWhenModelIsValid()
		{
			//--Act
			var result = _controller.ClassUnderTest.Create(_testModel) as RedirectToRouteResult;

			//--Assert
			Assert.IsTrue(_controller.ClassUnderTest.ModelState.IsValid);
			Assert.AreEqual("Index", result.RouteValues["Action"]);
		}

		[Test]
		public void ItGoesBackToTheViewIfModelStateIsInvalid()
		{
			_controller.ClassUnderTest.ModelState.AddModelError(string.Empty, string.Empty);

			//--Act
			var result = _controller.ClassUnderTest.Create(_testModel) as ViewResult;

			//--Assert
			Assert.AreEqual(string.Empty, result.ViewName);
			Assert.IsFalse(_controller.ClassUnderTest.ModelState.IsValid);
		}

		[Test]
		public void ThatEditActionReturnsAView()
		{
			//--Arrange
			_service.Setup(x => x.GetByID(42, Arg<string>.Is.Anything))
				.Returns(new Movie { ID = 42 });

			//--Act
			var result = _controller.ClassUnderTest.Edit(42) as ViewResult;

			//--Assert
			Assert.AreEqual(string.Empty, result.ViewName);
		}

		[Test]
		public void ThatOnEditWhenModelStateIsValidItGoesBackToIndexView()
		{
			//--Arrange
			_service.Setup(x => x.GetAll(It.Is<string>(y => y == null), string.Empty, 0, 1)).Returns(new List<Movie>());

			//--Act
			var result = _controller.ClassUnderTest.Edit(_testModel) as RedirectToRouteResult;

			//--Assert
			result.RouteValues["Action"].ShouldBe("Index");
		}

		[Test]
		public void ThatWhenModelStateIsNotValidItRedirectsBackToEditView()
		{
			_controller.ClassUnderTest.ModelState.AddModelError("", "");

			//--Act
			var result = _controller.ClassUnderTest.Edit(_testModel) as ViewResult;

			//--Assert
			Assert.IsFalse(_controller.ClassUnderTest.ModelState.IsValid);
			Assert.AreEqual(string.Empty, result.ViewName);
		}

		[Test]
		public void ThatOnEditADuplicateMovieIsFoundItRedirectsBackToEditView()
		{
			//--Arrange
			_service.Setup(x => x.GetAll(It.Is<string>(y => y == null), string.Empty, 0, 1))
				.Returns(new List<Movie> { new Movie { ID = 1, Title = "Deadpool", Type = MovieMediaTypeEnum.Bluray, UserID = "TestUser" } });
			_testModel.ID = 2;
			_testModel.Title = "Deadpool";
			_testModel.Type = MovieMediaTypeEnum.Bluray;

			//--Act
			var result = _controller.ClassUnderTest.Edit(_testModel) as ViewResult;

			//--Assert
			Assert.AreEqual(string.Empty, result.ViewName);
		}

		[Test]
		public void ThatItGoesToIndexViewAfterDelete()
		{
			_service.Setup(x => x.GetByID(666, Arg<string>.Is.Anything))
				.Returns(new Movie { ID = 666, UserID = "Test User" });
			//--Act
			var result = _controller.ClassUnderTest.Delete(666) as RedirectToRouteResult;

			//--Assert
			Assert.AreEqual("Index", result.RouteValues["Action"]);
		}

		[Test]
		public void ThatSearchActionReturnsAView()
		{
			//--Act
			var result = _controller.ClassUnderTest.Search(new MovieSearchModel { Title = string.Empty }) as ViewResult;

			//--Assert
			Assert.AreEqual(string.Empty, result.ViewName);
		}

		[Test]
		public void ThatSearchForWishPopulatesModelCorrectly()
		{
			_session["query"] = null;
			_session["wish"] = "Notebook";
			_controller.Get<ITMDBService>()
				.Expect(x => x.SearchMovies(Arg<string>.Is.Anything))
				.Return(new List<TMDBMovie>());
			_controller.Get<ITMDBService>()
				.Expect(x => x.SearchTV(Arg<string>.Is.Anything))
				.Return(new List<TMDBMovie>());

			var result = _controller.ClassUnderTest.Search(new MovieSearchModel()) as ViewResult;

			((MovieSearchModel)result.Model).Title.ShouldBe("Notebook");
		}

		[Test]
		public void ItAddsAnMovieToShowcase()
		{
			_service.Setup(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>())).Returns(new Movie());

			var result = _controller.ClassUnderTest.AddToShowcase(1) as RedirectToRouteResult;

			_service.Verify(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
			_service.Verify(x => x.Edit(It.IsAny<Movie>()), Times.Once);

			result.RouteValues["Action"].ShouldBe("Index");
			result.RouteValues["Controller"].ShouldBe("Showcase");
		}

		[Test]
		public void ItRemovesAnMovieFromTheShowcase()
		{
			_service.Setup(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>())).Returns(new Movie());

			var result = _controller.ClassUnderTest.RemoveFromShowcase(1) as RedirectToRouteResult;

			_service.Verify(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
			_service.Verify(x => x.Edit(It.IsAny<Movie>()), Times.Once);

			result.RouteValues["Action"].ShouldBe("Index");
			result.RouteValues["Controller"].ShouldBe("Showcase");
		}

		[Test]
		public void ItIncreasesCompletionCount()
		{
			_service.Setup(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>())).Returns(new Movie());

			var result = _controller.ClassUnderTest.IncreaseCompletionCount(1) as RedirectToRouteResult;

			_service.Verify(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
			_service.Verify(x => x.Edit(It.IsAny<Movie>()), Times.Once);

			result.RouteValues["Action"].ShouldBe("Index");
			result.RouteValues["Controller"].ShouldBe("Movie");
		}

		[Test]
		public void ItDecreasesCompletionCount()
		{
			_service.Setup(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>())).Returns(new Movie());

			var result = _controller.ClassUnderTest.DecreaseCompletionCount(1) as RedirectToRouteResult;

			_service.Verify(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
			_service.Verify(x => x.Edit(It.IsAny<Movie>()), Times.Once);

			result.RouteValues["Action"].ShouldBe("Index");
			result.RouteValues["Controller"].ShouldBe("Movie");
		}

		[Test]
		public void ItAddsToQueue()
		{
			_service.Setup(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>())).Returns(new Movie());

			var result = _controller.ClassUnderTest.AddToQueue(1) as RedirectToRouteResult;

			_service.Verify(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
			_service.Verify(x => x.Edit(It.IsAny<Movie>()), Times.Once);
			_service.Verify(x => x.GetHighestQueueRank(It.IsAny<string>()), Times.Once);

			result.RouteValues["Action"].ShouldBe("Index");
			result.RouteValues["Controller"].ShouldBe("Queue");
		}

		[Test]
		public void ItRemovesFromQueue()
		{
			_service.Setup(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>())).Returns(new Movie());

			var result = _controller.ClassUnderTest.RemoveFromQueue(1) as RedirectToRouteResult;

			_service.Verify(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
			_service.Verify(x => x.Edit(It.IsAny<Movie>()), Times.Once);

			result.RouteValues["Action"].ShouldBe("Index");
			result.RouteValues["Controller"].ShouldBe("Queue");
		}
	}
}