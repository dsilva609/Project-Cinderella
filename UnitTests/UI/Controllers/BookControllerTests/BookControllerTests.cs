using Moq;
using NUnit.Framework;
using System.Web.Mvc;
using UnitTests.UI.Controllers.BookControllerTests.TestBases;

namespace UnitTests.UI.Controllers.BookControllerTests
{
	public class BookControllerTests : BookControllerTestBase
	{
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
		public void ThatItGoesToIndexViewAfterDelete()
		{
			//--Arrange
			_controller.Setup(mock => mock.Delete(It.IsNotNull<int>())).Returns(new ViewResult { ViewName = MVC.Book.Views.Index });

			//--Act
			var result = _controller.Object.Delete(666) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Book.Views.Index, result.ViewName);
		}
	}
}