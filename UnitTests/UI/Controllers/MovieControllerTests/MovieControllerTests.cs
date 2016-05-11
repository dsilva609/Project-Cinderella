using BusinessLogic.Models;
using Moq;
using NUnit.Framework;
using System.Web.Mvc;
using UnitTests.UI.Controllers.MovieControllerTests.TestBases;

namespace UnitTests.UI.Controllers.MovieControllerTests
{
	[TestFixture]
	public class MovieControllerTests : MovieControllerTestBase
	{
		private Movie _testModel = new Movie();

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
		public void ItRedirectsToIndexActionWhenModelIsValid()
		{
			//--Arrange
			_controller.Setup(mock => mock.Create(It.IsNotNull<Movie>()))
				.Returns(new ViewResult { ViewName = MVC.Movie.Views.Index });

			//--Act
			var result = _controller.Object.Create(_testModel) as ViewResult;

			//--Assert
			Assert.IsTrue(_controller.Object.ModelState.IsValid);
			Assert.AreEqual(MVC.Movie.Views.Index, result.ViewName);
		}

		[Test]
		public void ItGoesBackToTheViewIfModelStateIsInvalid()
		{
			//--Arrange
			_controller.Setup(mock => mock.Create(It.IsNotNull<Movie>())).Returns(new ViewResult { ViewName = MVC.Book.Views.Create });
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
			_controller.Setup(mock => mock.Edit(It.IsNotNull<int>())).Returns(new ViewResult { ViewName = MVC.Movie.Views.Edit });

			//--Act
			var result = _controller.Object.Edit(42) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Movie.Views.Edit, result.ViewName);
		}

		[Test]
		public void ThatOnEditWhenModelStateIsValidItGoesBackToIndexView()
		{
			//--Arrange
			_controller.Setup(mock => mock.Edit(It.IsNotNull<Movie>())).Returns(new ViewResult { ViewName = MVC.Movie.Views.Index });

			//--Act
			var result = _controller.Object.Edit(_testModel) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Movie.Views.Index, result.ViewName);
		}

		[Test]
		public void ThatWhenModelStateIsNotValidItRedirectsBackToEditView()
		{
			//--Arrange
			_controller.Setup(mock => mock.Edit(It.IsNotNull<Movie>())).Returns(new ViewResult { ViewName = MVC.Movie.Views.Edit });
			_controller.Object.ModelState.AddModelError("", "");

			//--Act
			var result = _controller.Object.Edit(_testModel) as ViewResult;

			//--Assert
			Assert.IsFalse(_controller.Object.ModelState.IsValid);
			Assert.AreEqual(MVC.Movie.Views.Edit, result.ViewName);
		}

		[Test]
		public void ThatOnEditADuplicateMovieIsFoundItRedirectsBackToEditView()
		{
			//--TODO: need to set up dependency
			//--Arrange
			_controller.Setup(mock => mock.Edit(It.IsNotNull<Movie>())).Returns(new ViewResult { ViewName = MVC.Movie.Views.Edit });

			//--Act
			var result = _controller.Object.Edit(_testModel) as ViewResult;

			//--Assert
			Assert.AreEqual(0, 1);
			Assert.AreEqual(MVC.Movie.Views.Edit, result.ViewName);
		}

		[Test]
		public void ThatItGoesToIndexViewAfterDelete()
		{
			//--Arrange
			_controller.Setup(mock => mock.Delete(It.IsNotNull<int>())).Returns(new ViewResult { ViewName = MVC.Movie.Views.Index });

			//--Act
			var result = _controller.Object.Delete(666) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Movie.Views.Index, result.ViewName);
		}
	}
}