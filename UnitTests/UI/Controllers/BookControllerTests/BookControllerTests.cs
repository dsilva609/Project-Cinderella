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
	}
}