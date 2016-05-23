using BusinessLogic.Models;
using Moq;
using NUnit.Framework;
using System.Web.Mvc;
using UnitTests.UI.Controllers.BookControllerTests.TestBases;

namespace UnitTests.UI.Controllers.BookControllerTests
{
	public class BookControllerTests : BookControllerTestBase
	{
		private Book _testModel = new Book();

		[Test]
		public void ThatIndexActionReturnsAView()
		{
			//--Arrange
			_controller.Setup(mock => mock.Index(It.IsAny<string>(), It.IsAny<int>())).Returns(new ViewResult
			{
				ViewName = MVC.Book.Views.Index
			});

			//--Act
			var result = _controller.Object.Index(string.Empty, 1) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Book.Views.Index, result.ViewName);
		}

		[Test]
		public void ThatDetailsActionRetunsAView()
		{
			//--Arrange
			_controller.Setup(mock => mock.Details(It.IsNotNull<int>())).Returns(new ViewResult { ViewName = MVC.Book.Views.Details });

			//--Act
			var result = _controller.Object.Details(72) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Book.Views.Details, result.ViewName);
		}

		[Test]
		public void ThatCreateActionReturnsAView()
		{
			//--Arrange
			_controller.Setup(mock => mock.Create()).Returns(new ViewResult { ViewName = MVC.Book.Views.Create });

			//--Act
			var result = _controller.Object.Create() as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Book.Views.Create, result.ViewName);
		}

		[Test]
		public void ItRedirectsToIndexActionWhenModelIsValid()
		{
			//--Arrange
			_controller.Setup(mock => mock.Create(It.IsNotNull<Book>()))
				.Returns(new ViewResult { ViewName = MVC.Book.Views.Index });

			//--Act
			var result = _controller.Object.Create(_testModel) as ViewResult;

			//--Assert
			Assert.IsTrue(_controller.Object.ModelState.IsValid);
			Assert.AreEqual(MVC.Book.Views.Index, result.ViewName);
		}

		[Test]
		public void ItGoesBackToTheViewIfModelStateIsInvalid()
		{
			//--Arrange
			_controller.Setup(mock => mock.Create(It.IsNotNull<Book>())).Returns(new ViewResult { ViewName = MVC.Book.Views.Create });
			_controller.Object.ModelState.AddModelError(string.Empty, string.Empty);

			//--Act
			var result = _controller.Object.Create(_testModel) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Book.Views.Create, result.ViewName);
			Assert.IsFalse(_controller.Object.ModelState.IsValid);
		}

		[Test]
		public void ThatEditActionReturnsAView()
		{
			//--Arrange
			_controller.Setup(mock => mock.Edit(It.IsNotNull<int>())).Returns(new ViewResult { ViewName = MVC.Book.Views.Edit });

			//--Act
			var result = _controller.Object.Edit(42) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Book.Views.Edit, result.ViewName);
		}

		[Test]
		public void ThatOnEditWhenModelStateIsValidItGoesBackToIndexView()
		{
			//--Arrange
			_controller.Setup(mock => mock.Edit(It.IsNotNull<Book>())).Returns(new ViewResult { ViewName = MVC.Book.Views.Index });

			//--Act
			var result = _controller.Object.Edit(_testModel) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Book.Views.Index, result.ViewName);
		}

		[Test]
		public void ThatWhenModelStateIsNotValidItRedirectsBackToEditView()
		{
			//--Arrange
			_controller.Setup(mock => mock.Edit(It.IsNotNull<Book>())).Returns(new ViewResult { ViewName = MVC.Book.Views.Edit });
			_controller.Object.ModelState.AddModelError("", "");

			//--Act
			var result = _controller.Object.Edit(_testModel) as ViewResult;

			//--Assert
			Assert.IsFalse(_controller.Object.ModelState.IsValid);
			Assert.AreEqual(MVC.Book.Views.Edit, result.ViewName);
		}

		[Test]
		public void ThatOnEditADuplicateBookIsFoundItRedirectsBackToEditView()
		{
			//--TODO: need to set up dependency
			//--Arrange
			_controller.Setup(mock => mock.Edit(It.IsNotNull<Book>())).Returns(new ViewResult { ViewName = MVC.Book.Views.Edit });

			//--Act
			var result = _controller.Object.Edit(_testModel) as ViewResult;

			//--Assert
			Assert.AreEqual(0, 1);
			Assert.AreEqual(MVC.Book.Views.Edit, result.ViewName);
		}

		[Test]
		public void ThatItGoesToIndexViewAfterDelete()
		{
			//--Arrange
			_controller.Setup(mock => mock.Delete(It.IsNotNull<int>())).Returns(new ViewResult { ViewName = MVC.Book.Views.Index });

			//--Act
			var result = _controller.Object.Delete(666) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Book.Views.Index, result.ViewName);
		}

		[Test]
		public void ThatSearchActionReturnsAView()
		{
			//--Arrange
			_controller.Setup(mock => mock.Search(null)).Returns(new ViewResult { ViewName = MVC.Book.Views.Search });

			//--Act
			var result = _controller.Object.Search(null) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Book.Views.Search, result.ViewName);
		}

		[Test]
		public void ThatCreateFromSearchModelActionReturnsAView()
		{
			//--Arrange
			_controller.Setup(mock => mock.CreateFromSearchModel(It.IsNotNull<Book>())).Returns(new ViewResult { ViewName = MVC.Book.Views.Create });

			//--Act
			var result = _controller.Object.CreateFromSearchModel(_testModel) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Book.Views.Create, result.ViewName);
		}
	}
}