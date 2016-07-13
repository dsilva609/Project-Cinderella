using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using Moq;
using NUnit.Framework;
using Rhino.Mocks;
using System.Collections.Generic;
using System.Web.Mvc;
using UI.Models;
using UnitTests.UI.Controllers.TestBases;

namespace UnitTests.UI.Controllers
{
	[TestFixture]
	public class AlbumControllerTests : AlbumControllerTestBase
	{
		private Album _testModel = new Album();

		[Test]
		public void ThatTheIndexActionReturnsAView()
		{
			//--Act
			var result = _controller.ClassUnderTest.Index(string.Empty, 1) as ViewResult;

			var test = result.Model;
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
		public void ItGoesToIndexViewAfterDelete()
		{
			//--Act
			var result = _controller.ClassUnderTest.Delete(6213) as RedirectToRouteResult;

			//--Assert
			Assert.AreEqual("Index", result.RouteValues["Action"]);
		}

		[Test]
		public void ThatEditActionReturnsAView()
		{
			//--Arrange
			_controller.Get<IAlbumService>().Expect(x => x.GetByID(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
				.Return(new Album { ID = 666 });

			//--Act
			var result = _controller.ClassUnderTest.Edit(666) as ViewResult;

			//--Assert
			Assert.AreEqual(string.Empty, result.ViewName);
		}

		[Test]
		public void ThatOnEditWhenModelStateIsValidItGoesBackToIndexView()
		{
			//--Arrange
			_controller.Get<IAlbumService>()
				.Expect(x => x.GetAll(Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<int>.Is.Anything, Arg<int>.Is.Anything))
				.Return(new List<Album>());

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
		public void ThatOnEditADuplicateRecordIsFoundItRedirectsBackToEditView()
		{
			//--Arrange
			_controller.Get<IAlbumService>()
				.Expect(x => x.GetAll(Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<int>.Is.Anything, Arg<int>.Is.Anything))
				.Return(new List<Album> { new Album { ID = 1, Title = "Kill 'Em All", Artist = "Metallica" } });
			_testModel.ID = 1;
			_testModel.Title = "Kill 'Em All";
			_testModel.Artist = "Metallica";

			//--Act
			var result = _controller.ClassUnderTest.Edit(_testModel) as ViewResult;

			//--Assert
			Assert.AreEqual(string.Empty, result.ViewName);
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
		public void ThatSearchActionReturnsAView()
		{
			//--Act
			var result = _controller.ClassUnderTest.Search(new DiscogsSearchModel()) as ViewResult;

			//--Assert
			Assert.AreEqual(string.Empty, result.ViewName);
		}

		[Test]
		public void ThatCreateFromSearchModelActionReturnsAView()
		{
			//--Arrange
			_controller.Get<IDiscogsService>().Expect(x => x.GetRelease(Arg<int>.Is.Anything))
				.Return(new Album());

			//--Act
			var result = _controller.ClassUnderTest.CreateFromSearchResult(It.IsAny<int>()) as RedirectToRouteResult;

			//--Assert
			Assert.AreEqual("Create", result.RouteValues["Action"]);
		}
	}
}