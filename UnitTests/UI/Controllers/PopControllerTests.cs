using BusinessLogic.Models;
using Moq;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;
using System.Collections.Generic;
using System.Web.Mvc;
using UnitTests.UI.Controllers.TestBases;

namespace UnitTests.UI.Controllers
{
	public class PopControllerTests : PopControllerTestBase
	{
		private FunkoModel _testModel = new FunkoModel();

		[Test]
		public void ThatTheIndexActionReturnsAView()
		{
			var result = _controller.ClassUnderTest.Index(string.Empty, string.Empty, 1) as ViewResult;

			string.IsNullOrWhiteSpace(result.ViewName).ShouldBeTrue();
		}

		[Test]
		public void ThatCreateActionReturnsAView()
		{
			var result = _controller.ClassUnderTest.Create() as ViewResult;

			Assert.AreEqual(string.Empty, result.ViewName);
		}

		[Test]
		public void ItRedirectsToIndexActionWhenModelIsValid()
		{
			var result = _controller.ClassUnderTest.Create(_testModel) as RedirectToRouteResult;

			Assert.IsTrue(_controller.ClassUnderTest.ModelState.IsValid);
			Assert.AreEqual("Index", result.RouteValues["Action"]);
		}

		[Test]
		public void ItGoesBackToTheViewIfModelStateIsInvalid()
		{
			_controller.ClassUnderTest.ModelState.AddModelError(string.Empty, string.Empty);

			var result = _controller.ClassUnderTest.Create(_testModel) as ViewResult;

			Assert.AreEqual(string.Empty, result.ViewName);
			Assert.IsFalse(_controller.ClassUnderTest.ModelState.IsValid);
		}

		[Test]
		public void ItGoesToIndexViewAfterDelete()
		{
			_service.Setup(x => x.GetByID(666, Arg<string>.Is.Anything))
				.Returns(new FunkoModel { ID = 666, UserID = "Test User" });

			var result = _controller.ClassUnderTest.Delete(666) as RedirectToRouteResult;

			Assert.AreEqual("Index", result.RouteValues["Action"]);
		}

		[Test]
		public void ThatEditActionReturnsAView()
		{
			_service.Setup(x => x.GetByID(666, Arg<string>.Is.Anything))
				.Returns(new FunkoModel() { ID = 666 });

			var result = _controller.ClassUnderTest.Edit(666) as ViewResult;

			Assert.AreEqual(string.Empty, result.ViewName);
		}

		[Test]
		public void ThatOnEditWhenModelStateIsValidItGoesBackToIndexView()
		{
			_service.Setup(x => x.GetAll(It.Is<string>(y => y == null), string.Empty, 0, 1)).Returns(new List<FunkoModel>());
			_service.Setup(x => x.GetByID(666, Arg<string>.Is.Anything)).Returns(new FunkoModel { ID = 666 });

			var result = _controller.ClassUnderTest.Edit(_testModel) as RedirectToRouteResult;

			Assert.AreEqual("Index", result.RouteValues["Action"]);
		}

		[Test]
		public void ThatWhenModelStateIsNotValidItRedirectsBackToEditView()
		{
			_controller.ClassUnderTest.ModelState.AddModelError("", "");

			var result = _controller.ClassUnderTest.Edit(_testModel) as ViewResult;

			Assert.IsFalse(_controller.ClassUnderTest.ModelState.IsValid);
			Assert.AreEqual(string.Empty, result.ViewName);
		}

		[Test]
		public void ThatOnEditADuplicatePopIsFoundItRedirectsBackToEditView()
		{
			_service.Setup(x => x.GetAll(It.Is<string>(y => y == null), string.Empty, It.IsAny<int>(), It.IsAny<int>()))
				.Returns(new List<FunkoModel>
				{
					new FunkoModel
					{
						ID = 1,
						Title = "Wonder Woman",
						Series = "DC",
						PopLine = "vinyl",
						UserID = "test",
					}
				});
			_testModel.ID = 2;
			_testModel.Title = "Wonder Woman";
			_testModel.Series = "DC";
			_testModel.PopLine = "vinyl";

			var result = _controller.ClassUnderTest.Edit(_testModel) as ViewResult;

			result.ViewName.ShouldBe(string.Empty);
		}

		[Test]
		public void ThatDetailsActionReturnsAView()
		{
			var result = _controller.ClassUnderTest.Details(72) as ViewResult;

			Assert.AreEqual(string.Empty, result.ViewName);
		}

		[Test]
		public void ItAddsAPopToShowcase()
		{
			_service.Setup(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>())).Returns(new FunkoModel());

			var result = _controller.ClassUnderTest.AddToShowcase(1) as RedirectToRouteResult;

			_service.Verify(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
			_service.Verify(x => x.Edit(It.IsAny<FunkoModel>()), Times.Once);

			result.RouteValues["Action"].ShouldBe("Index");
			result.RouteValues["Controller"].ShouldBe("Showcase");
		}

		[Test]
		public void ItRemovesAnPopFromTheShowcase()
		{
			_service.Setup(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>())).Returns(new FunkoModel());

			var result = _controller.ClassUnderTest.RemoveFromShowcase(1) as RedirectToRouteResult;

			_service.Verify(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
			_service.Verify(x => x.Edit(It.IsAny<FunkoModel>()), Times.Once);

			result.RouteValues["Action"].ShouldBe("Index");
			result.RouteValues["Controller"].ShouldBe("Showcase");
		}
	}
}