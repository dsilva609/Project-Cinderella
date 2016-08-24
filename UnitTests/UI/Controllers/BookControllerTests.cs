using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;
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
			_controller.Get<IBookService>().Expect(x => x.GetAll(Arg<string>.Is.Anything)).Return(new List<Book>());

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
			_controller.Get<IBookService>().Expect(x => x.GetByID(Arg<int>.Is.Anything, Arg<string>.Is.Anything)).Return(new Book { ID = 42 });

			//--Act
			var result = _controller.ClassUnderTest.Edit(42) as ViewResult;

			//--Assert
			Assert.AreEqual(string.Empty, result.ViewName);
		}

		[Test]
		public void ThatOnEditWhenModelStateIsValidItGoesBackToIndexView()
		{
			//--Arrange
			_controller.Get<IBookService>().Expect(x => x.GetAll(Arg<string>.Is.Anything)).Return(new List<Book>());

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
			_controller.Get<IBookService>().Expect(x => x.GetAll(Arg<string>.Is.Anything)).
				Return(new List<Book> { new Book { ID = 666, Title = "Death Note", Author = "Manga" } });
			_testModel.ID = 666;
			_testModel.Title = "Death Note";
			_testModel.Author = "Manga";

			//--Act
			var result = _controller.ClassUnderTest.Edit(_testModel) as ViewResult;

			//--Assert
			Assert.AreEqual(string.Empty, result.ViewName);
		}

		[Test]
		public void ThatItGoesToIndexViewAfterDelete()
		{
			//--Act
			var result = _controller.ClassUnderTest.Delete(666) as RedirectToRouteResult;

			//--Assert
			Assert.AreEqual("Index", result.RouteValues["Action"]);
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
	}
}