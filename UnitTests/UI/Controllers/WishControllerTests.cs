using BusinessLogic.Enums;
using BusinessLogic.Models;
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
	public class WishControllerTests : WishControllerTestBase
	{
		private WishFormModel _testModel = new WishFormModel { Wish = new Wish() };

		[Test]
		public void ThatTheIndexActionReturnsAView()
		{
			_session["query"] = string.Empty;

			//--Act
			var result = _controller.ClassUnderTest.Index(string.Empty, string.Empty, 1) as ViewResult;

			//--Assert
			Assert.AreEqual(string.Empty, result.ViewName);
		}

		[Test]
		public void ThatCreateActionReturnsAView()
		{
			_service.Setup(x => x.GetAll(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Wish>());

			//--Act
			var result = _controller.ClassUnderTest.Create() as ViewResult;

			//--Assert
			Assert.AreEqual(string.Empty, result.ViewName);
		}

		[Test]
		public void ItRedirectsToIndexActionWhenModelIsValid()
		{
			_service.Setup(x => x.GetAll(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Wish>());

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
			_service.Setup(x => x.GetAll(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Wish>());

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
			_service.Setup(x => x.GetByID(666, Arg<string>.Is.Anything))
				.Returns(new Wish { ID = 666 });
			_service.Setup(x => x.GetAll(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Wish>());

			//--Act
			var result = _controller.ClassUnderTest.Edit(666) as ViewResult;

			//--Assert
			Assert.AreEqual(string.Empty, result.ViewName);
		}

		[Test]
		public void ItGoesToIndexViewAfterDelete()
		{
			_service.Setup(x => x.GetByID(666, Arg<string>.Is.Anything))
				.Returns(new Wish { ID = 666, UserID = "Test User" });

			//--Act
			var result = _controller.ClassUnderTest.Delete(666) as RedirectToRouteResult;

			//--Assert
			Assert.AreEqual("Index", result.RouteValues["Action"]);
		}

		[Test]
		public void ThatOnEditWhenModelStateIsValidItGoesBackToIndexView()
		{
			//--Arrange
			_service.Setup(x => x.GetAll(It.Is<string>(y => y == null), string.Empty, 0, 1))
				.Returns(new List<Wish>());

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
			_service.Setup(x => x.GetAll(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Wish>());

			//--Act
			var result = _controller.ClassUnderTest.Edit(_testModel) as ViewResult;

			//--Assert
			Assert.IsFalse(_controller.ClassUnderTest.ModelState.IsValid);
			Assert.AreEqual(string.Empty, result.ViewName);
		}

		[Test]
		public void ThatOnEditADuplicateRecordIsFoundItRedirectsBackToEditView()
		{
			//--Arrange
			_service.Setup(x => x.GetAll(It.Is<string>(y => y == null), string.Empty, 0, 1))
				.Returns(new List<Wish> { new Wish { ID = 1, Title = "Kill 'Em All" } });
			_testModel.Wish = new Wish
			{
				ID = 2,
				Title = "Kill 'Em All"
			};

			//--Act
			var result = _controller.ClassUnderTest.Edit(_testModel) as ViewResult;

			//--Assert
			result.ViewName.ShouldBe(string.Empty);
		}

		[Test]
		public void ThatDetailsActionReturnsAView()
		{
			//--Act
			var result = _controller.ClassUnderTest.Details(72) as ViewResult;

			//--Assert
			Assert.AreEqual(string.Empty, result.ViewName);
		}

		[Test]
		public void ItRedirectsToIndexUponFinishingAWish()
		{
			_service.Setup(x => x.GetByID(666, Arg<string>.Is.Anything))
				.Returns(new Wish { ID = 666, UserID = "test" });

			//--Act
			var result = _controller.ClassUnderTest.FinishWish(666) as RedirectToRouteResult;

			//--Assert
			Assert.IsTrue(_controller.ClassUnderTest.ModelState.IsValid);
			Assert.AreEqual("Index", result.RouteValues["Action"]);
		}

		[Test]
		public void ItDoesntCallEditForAUserValidationFailure()
		{
			SetupAuthorization("none", false, false);
			_service.Setup(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>())).Returns(new Wish { ID = 666, UserID = "phonybologna" });

			//--Act
			var result = _controller.ClassUnderTest.FinishWish(666) as RedirectToRouteResult;

			//--Assert
			Assert.IsTrue(_controller.ClassUnderTest.ModelState.IsValid);
			Assert.AreEqual("Index", result.RouteValues["Action"]);
			_service.Verify(x => x.Edit(It.IsAny<Wish>()), Times.Never);
		}

		[Test]
		public void ItRedirectsToCorrectControllerOnSearch()
		{
			_service.Setup(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>()))
				.Returns(new Wish { ID = 666, UserID = "phonybologna", ItemType = ItemType.Book });

			var result = _controller.ClassUnderTest.Search(666) as RedirectToRouteResult;

			result.RouteValues["Controller"].ShouldBe("Book");
		}
	}
}