﻿using BusinessLogic.Models;
using Moq;
using NUnit.Framework;
using System.Web.Mvc;
using UI.Models;
using UnitTests.UI.Controllers.AlbumControllerTests.TestBases;

namespace UnitTests.UI.Controllers.AlbumControllerTests
{
	[TestFixture]
	public class AlbumControllerTests : AlbumControllerTestBase
	{
		private Album _testModel = new Album();
		private AlbumViewModel _expectedIndex = new AlbumViewModel();

		[Test]
		public void ThatTheIndexActionReturnsAView()
		{
			//--Arrange
			//	_controller.Expect(mock => mock.ClassUnderTest.Index(It.IsAny<string>(), It.IsAny<int>())).Returns(new ViewResult { ViewName = MVC.Album.Views.Index });

			//--Act
			var result = _controller.ClassUnderTest.Index(string.Empty, 1) as ViewResult;

			var test = result.Model;
			//--Assert
			Assert.AreEqual(string.Empty, result.ViewName);
		}

		[Test]
		public void ThatSpecifiedViewModelIsSentToView()
		{
			//--Arrange
			//		_controller.Setup(mock => mock.Index(It.IsAny<string>(), It.IsAny<int>())).Returns(new ViewResult { ViewName = MVC.Album.Views.Index, ViewData = new ViewDataDictionary(_expectedIndex) });

			//--Act
			var result = _controller.ClassUnderTest.Index(string.Empty, 0) as ViewResult;

			//--Assert
			Assert.AreEqual(_expectedIndex, result.ViewData.Model);
		}

		[Test]
		public void ThatCreateActionReturnsAView()
		{
			//--Arrange
			//		_controller.Setup(mock => mock.Create()).Returns(new ViewResult { ViewName = MVC.Album.Views.Create });

			//--Act
			var result = _controller.ClassUnderTest.Create() as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Album.Views.Create, result.ViewName);
		}

		[Test]
		public void ThatCorrectModelIsPassedIntoCreateView()
		{
			//--Arrange
			//	_controller.Setup(mock => mock.Create()).Returns(new ViewResult { ViewData = new ViewDataDictionary(_testModel) });

			//--Act
			var result = _controller.ClassUnderTest.Create() as ViewResult;

			//--Assert
			Assert.AreEqual(_testModel, result.ViewData.Model);
		}

		[Test]
		public void ItRedirectsToIndexActionWhenModelIsValid()
		{
			//--Arrange
			//_controller.Setup(mock => mock.Create(It.IsNotNull<Album>())).Returns(new ViewResult { ViewName = MVC.Album.Views.Index });

			//--Act
			var result = _controller.ClassUnderTest.Create(_testModel) as ViewResult;

			//--Assert
			Assert.IsTrue(_controller.ClassUnderTest.ModelState.IsValid);
			Assert.AreEqual(MVC.Album.Views.Index, result.ViewName);
		}

		[Test]
		public void ItGoesBackToTheViewIfModelStateIsInvalid()
		{
			//--Arrange
			//_controller.Setup(mock => mock.Create(It.IsNotNull<Album>())).Returns(new ViewResult { ViewName = MVC.Album.Views.Create });
			_controller.ClassUnderTest.ModelState.AddModelError(string.Empty, string.Empty);

			//--Act
			var result = _controller.ClassUnderTest.Create(_testModel) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Album.Views.Create, result.ViewName);
			Assert.IsFalse(_controller.ClassUnderTest.ModelState.IsValid);
		}

		[Test]
		public void ItGoesToIndexViewAfterDelete()
		{
			//--Arrange
			//_controller.Setup(mock => mock.Delete(It.IsNotNull<int>())).Returns(new ViewResult { ViewName = MVC.Album.Views.Index });

			//--Act
			var result = _controller.ClassUnderTest.Delete(6213) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Album.Views.Index, result.ViewName);
		}

		[Test]
		public void ThatEditActionReturnsAView()
		{
			//--Arrange
			//_controller.Setup(mock => mock.Edit(It.IsAny<int>())).Returns(new ViewResult { ViewName = MVC.Album.Views.Edit });

			//--Act
			var result = _controller.ClassUnderTest.Edit(666) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Album.Views.Edit, result.ViewName);
		}

		[Test]
		public void ThatOnEditWhenModelStateIsValidItGoesBackToIndexView()
		{
			//--Arrange
			//		_controller.Setup(mock => mock.Edit(It.IsNotNull<Album>())).Returns(new ViewResult { ViewName = MVC.Album.Views.Index });

			//--Act
			var result = _controller.ClassUnderTest.Edit(_testModel) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Album.Views.Index, result.ViewName);
		}

		[Test]
		public void ThatWhenModelStateIsNotValidItRedirectsBackToEditView()
		{
			//--Arrange
			//		_controller.Setup(mock => mock.Edit(It.IsNotNull<Album>())).Returns(new ViewResult { ViewName = MVC.Album.Views.Edit });
			_controller.ClassUnderTest.ModelState.AddModelError("", "");

			//--Act
			var result = _controller.ClassUnderTest.Edit(_testModel) as ViewResult;

			//--Assert
			Assert.IsFalse(_controller.ClassUnderTest.ModelState.IsValid);
			Assert.AreEqual(MVC.Album.Views.Edit, result.ViewName);
		}

		[Test]
		public void ThatOnEditADuplicateRecordIsFoundItRedirectsBackToEditView()
		{
			//--TODO: need to set up dependency
			//--Arrange
			//_controller.Setup(mock => mock.Edit(It.IsNotNull<Album>())).Returns(new ViewResult() { ViewName = MVC.Album.Views.Edit });

			//--Act
			var result = _controller.ClassUnderTest.Edit(_testModel) as ViewResult;

			//--Assert
			Assert.AreEqual(0, 1);
			Assert.AreEqual(MVC.Album.Views.Edit, result.ViewName);
		}

		[Test]
		public void ThatDetailsActionReturnsAView()
		{
			//--Arrange
			//	_controller.Setup(mock => mock.Details(It.IsAny<int>())).Returns(new ViewResult { ViewName = MVC.Album.Views.Details });

			//--Act
			var result = _controller.ClassUnderTest.Details(72) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Album.Views.Details, result.ViewName);
		}

		[Test]
		public void ThatModelIsSentToDetailsView()
		{
			//--Arrange
			//_controller.Setup(mock => mock.Details(It.IsAny<int>())).Returns(new ViewResult { ViewData = new ViewDataDictionary(_testModel) });

			//--Act
			var result = _controller.ClassUnderTest.Details(_testModel.ID) as ViewResult;

			//--Assert
			Assert.AreEqual(_testModel, result.ViewData.Model);
		}

		[Test]
		public void ThatSearchActionReturnsAView()
		{
			//--Arrange
			//_controller.Setup(mock => mock.Search()).Returns(new ViewResult { ViewName = MVC.Book.Views.Search });

			//--Act
			var result = _controller.ClassUnderTest.Search() as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Book.Views.Search, result.ViewName);
		}

		[Test]
		public void ThatCreateFromSearchModelActionReturnsAView()
		{
			//--Arrange
			//	_controller.Setup(mock => mock.CreateFromSearchResult(It.IsAny<int>())).Returns(new ViewResult { ViewName = MVC.Album.Views.Create });

			//--Act
			var result = _controller.ClassUnderTest.CreateFromSearchResult(It.IsAny<int>()) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Album.Views.Create, result.ViewName);
		}
	}
}