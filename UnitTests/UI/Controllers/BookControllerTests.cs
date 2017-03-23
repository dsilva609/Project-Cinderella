using BusinessLogic.Models;
using BusinessLogic.Models.ComicVineModels;
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
	public class BookControllerTests : BookControllerTestBase
	{
		private Book _testModel = new Book();

		[Test]
		public void ThatIndexActionReturnsAView()
		{
			//--Arrange
			_service.Setup(x => x.GetAll(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Book>());

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
			//--Arrange
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
			_service.Setup(x => x.GetByID(42, Arg<string>.Is.Anything)).Returns(new Book { ID = 42 });

			//--Act
			var result = _controller.ClassUnderTest.Edit(42) as ViewResult;

			//--Assert
			Assert.AreEqual(string.Empty, result.ViewName);
		}

		[Test]
		public void ThatOnEditWhenModelStateIsValidItGoesBackToIndexView()
		{
			//--Arrange
			_service.Setup(x => x.GetAll(It.Is<string>(y => y == null), string.Empty, 0, 1)).Returns(new List<Book>());

			//--Act
			var result = _controller.ClassUnderTest.Edit(_testModel) as RedirectToRouteResult;

			//--Assert
			Assert.AreEqual("Index", result.RouteValues["Action"]);
		}

		[Test]
		public void ThatWhenModelStateIsNotValidItRedirectsBackToEditView()
		{
			//--Arrange
			_controller.ClassUnderTest.ModelState.AddModelError("", "");

			//--Act
			var result = _controller.ClassUnderTest.Edit(_testModel) as ViewResult;

			//--Assert
			Assert.IsFalse(_controller.ClassUnderTest.ModelState.IsValid);
			Assert.AreEqual(string.Empty, result.ViewName);
		}

		[Test]
		public void ThatOnEditADuplicateBookIsFoundItRedirectsBackToEditView()
		{
			//--Arrange
			_service.Setup(x => x.GetAll(It.Is<string>(y => y == null), string.Empty, 0, 1))
				.Returns(new List<Book> { new Book { ID = 666, Title = "Death Note", Author = "Manga" } });
			_testModel.ID = 667;
			_testModel.Title = "Death Note";
			_testModel.Author = "Manga";

			//--Act
			var result = _controller.ClassUnderTest.Edit(_testModel) as ViewResult;

			//--Assert
			result.ViewName.ShouldBe(string.Empty);
		}

		[Test]
		public void ThatItGoesToIndexViewAfterDelete()
		{
			_service.Setup(x => x.GetByID(666, Arg<string>.Is.Anything))
				.Returns(new Book { ID = 666, UserID = "Test User" });

			//--Act
			var result = _controller.ClassUnderTest.Delete(666) as RedirectToRouteResult;

			//--Assert
			result.RouteValues["Action"].ShouldBe("Index");
		}

		[Test]
		public void ThatSearchActionReturnsAView()
		{
			//--Arrange
			_controller.Get<IGoogleBookService>().Expect(x => x.Search(Arg<string>.Is.Anything, Arg<string>.Is.Anything)).Return(null);
			//--Act
			var result = _controller.ClassUnderTest.Search(new BookSearchModel { Author = "R.R. Martin", Title = "Game of Thrones" }) as ViewResult;

			//--Assert
			Assert.AreEqual(string.Empty, result.ViewName);
		}

		[Test]
		public void ThatCreateFromSearchModelActionReturnsAView()
		{
			//--Arrange
			_controller.Get<IGoogleBookService>().Expect(x => x.SearchByID(Arg<string>.Is.Anything)).Return(new Book());

			//--Act
			var result = _controller.ClassUnderTest.CreateFromSearchModel("test", false) as RedirectToRouteResult;

			//--Assert
			Assert.AreEqual("Create", result.RouteValues["Action"]);
		}

		[Test]
		public void ThatSearchForWishPopulatesModelCorrectly()
		{
			_session["query"] = null;
			_session["wish"] = "Harry Potter";
			_controller.Get<IGoogleBookService>()
				.Expect(x => x.Search(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
				.Return(new List<Book>());
			_controller.Get<IComicVineService>()
				.Expect(x => x.Search(Arg<string>.Is.Anything))
				.Return(new ComicVineResult());

			var result = _controller.ClassUnderTest.Search(new BookSearchModel()) as ViewResult;

			((BookSearchModel)result.Model).Title.ShouldBe("Harry Potter");
		}

		[Test]
		public void ItAddsAnBookToShowcase()
		{
			_service.Setup(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>())).Returns(new Book());

			var result = _controller.ClassUnderTest.AddToShowcase(1) as RedirectToRouteResult;

			_service.Verify(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
			_service.Verify(x => x.Edit(It.IsAny<Book>()), Times.Once);

			result.RouteValues["Action"].ShouldBe("Index");
			result.RouteValues["Controller"].ShouldBe("Showcase");
		}

		[Test]
		public void ItRemovesAnBookFromTheShowcase()
		{
			_service.Setup(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>())).Returns(new Book());

			var result = _controller.ClassUnderTest.RemoveFromShowcase(1) as RedirectToRouteResult;

			_service.Verify(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
			_service.Verify(x => x.Edit(It.IsAny<Book>()), Times.Once);

			result.RouteValues["Action"].ShouldBe("Index");
			result.RouteValues["Controller"].ShouldBe("Showcase");
		}

		[Test]
		public void ItIncreasesCompletionCount()
		{
			_service.Setup(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>())).Returns(new Book());

			var result = _controller.ClassUnderTest.IncreaseCompletionCount(1) as RedirectToRouteResult;

			_service.Verify(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
			_service.Verify(x => x.Edit(It.IsAny<Book>()), Times.Once);

			result.RouteValues["Action"].ShouldBe("Index");
			result.RouteValues["Controller"].ShouldBe("Book");
		}

		[Test]
		public void ItDecreasesCompletionCount()
		{
			_service.Setup(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>())).Returns(new Book());

			var result = _controller.ClassUnderTest.DecreaseCompletionCount(1) as RedirectToRouteResult;

			_service.Verify(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
			_service.Verify(x => x.Edit(It.IsAny<Book>()), Times.Once);

			result.RouteValues["Action"].ShouldBe("Index");
			result.RouteValues["Controller"].ShouldBe("Book");
		}

		[Test]
		public void ItAddsToQueue()
		{
			_service.Setup(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>())).Returns(new Book());

			var result = _controller.ClassUnderTest.AddToQueue(1) as RedirectToRouteResult;

			_service.Verify(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
			_service.Verify(x => x.Edit(It.IsAny<Book>()), Times.Once);
			_service.Verify(x => x.GetHighestQueueRank(It.IsAny<string>()), Times.Once);

			result.RouteValues["Action"].ShouldBe("Index");
			result.RouteValues["Controller"].ShouldBe("Queue");
		}

		[Test]
		public void ItRemovesFromQueue()
		{
			_service.Setup(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>())).Returns(new Book());

			var result = _controller.ClassUnderTest.RemoveFromQueue(1) as RedirectToRouteResult;

			_service.Verify(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
			_service.Verify(x => x.Edit(It.IsAny<Book>()), Times.Once);

			result.RouteValues["Action"].ShouldBe("Index");
			result.RouteValues["Controller"].ShouldBe("Queue");
		}
	}
}