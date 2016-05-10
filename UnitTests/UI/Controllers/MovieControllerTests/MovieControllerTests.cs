using Moq;
using NUnit.Framework;
using System.Web.Mvc;
using UnitTests.UI.Controllers.MovieControllerTests.TestBases;

namespace UnitTests.UI.Controllers.MovieControllerTests
{
	[TestFixture]
	public class MovieControllerTests : MovieControllerTestBase
	{
		[Test]
		public void ThatIndexActionReturnsAView()
		{
			//--Arrange
			_controller.Setup(mock => mock.Index(It.IsAny<string>(), It.IsAny<int>())).Returns(new ViewResult { ViewName = MVC.Movie.Views.Index });

			//--Act
			var result = _controller.Object.Index(string.Empty, 1) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Movie.Views.Index, result.ViewName);
		}

		[Test]
		public void ThatDetailsActionRetunsAView()
		{
			//--Arrange
			_controller.Setup(mock => mock.Details(It.IsNotNull<int>())).Returns(new ViewResult { ViewName = MVC.Movie.Views.Details });

			//--Act
			var result = _controller.Object.Details(72) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Movie.Views.Details, result.ViewName);
		}

		[Test]
		public void ThatCreateActionReturnsAView()
		{
			//--Arrange
			_controller.Setup(mock => mock.Create()).Returns(new ViewResult { ViewName = MVC.Movie.Views.Create });

			//--Act
			var result = _controller.Object.Create() as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Movie.Views.Create, result.ViewName);
		}

		[Test]
		public void ThatEditActionReturnsAView()
		{
			//--Arrange
			_controller.Setup(mock => mock.Edit(It.IsNotNull<int>())).Returns(new ViewResult { ViewName = MVC.Movie.Views.Edit });

			//--Act
			var result = _controller.Object.Edit(42) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Movie.Views.Edit, result.ViewName);
		}
	}
}