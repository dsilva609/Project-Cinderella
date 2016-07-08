using BusinessLogic.Models;
using Moq;
using NUnit.Framework;
using System.Web.Mvc;
using UnitTests.UI.Controllers.TestBases;

namespace UnitTests.UI.Controllers
{
	[TestFixture]
	public class GameControllerTests : GameControllerTestBase
	{
		private Game _testModel = new Game();

		[Test]
		public void ThatIndexActionReturnsAView()
		{
			//--Arrange
			_controller.Setup(mock => mock.Index(It.IsAny<string>(), It.IsAny<int>())).Returns(new ViewResult
			{
				ViewName = MVC.Game.Views.Index
			});

			//--Act
			var result = _controller.Object.Index(string.Empty, 1) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Game.Views.Index, result.ViewName);
		}

		[Test]
		public void ThatDetailsActionRetunsAView()
		{
			//--Arrange
			_controller.Setup(mock => mock.Details(It.IsNotNull<int>())).Returns(new ViewResult { ViewName = MVC.Game.Views.Details });

			//--Act
			var result = _controller.Object.Details(72) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Game.Views.Details, result.ViewName);
		}

		[Test]
		public void ThatCreateActionReturnsAView()
		{
			//--Arrange
			_controller.Setup(mock => mock.Create()).Returns(new ViewResult { ViewName = MVC.Game.Views.Create });

			//--Act
			var result = _controller.Object.Create() as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Game.Views.Create, result.ViewName);
		}

		[Test]
		public void ItRedirectsToIndexActionWhenModelIsValid()
		{
			//--Arrange
			_controller.Setup(mock => mock.Create(It.IsNotNull<Game>()))
				.Returns(new ViewResult { ViewName = MVC.Game.Views.Index });

			//--Act
			var result = _controller.Object.Create(_testModel) as ViewResult;

			//--Assert
			Assert.IsTrue(_controller.Object.ModelState.IsValid);
			Assert.AreEqual(MVC.Game.Views.Index, result.ViewName);
		}

		[Test]
		public void ItGoesBackToTheViewIfModelStateIsInvalid()
		{
			//--Arrange
			_controller.Setup(mock => mock.Create(It.IsNotNull<Game>())).Returns(new ViewResult { ViewName = MVC.Game.Views.Create });
			_controller.Object.ModelState.AddModelError(string.Empty, string.Empty);

			//--Act
			var result = _controller.Object.Create(_testModel) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Game.Views.Create, result.ViewName);
			Assert.IsFalse(_controller.Object.ModelState.IsValid);
		}

		[Test]
		public void ThatEditActionReturnsAView()
		{
			//--Arrange
			_controller.Setup(mock => mock.Edit(It.IsNotNull<int>())).Returns(new ViewResult { ViewName = MVC.Game.Views.Edit });

			//--Act
			var result = _controller.Object.Edit(42) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Game.Views.Edit, result.ViewName);
		}

		[Test]
		public void ThatOnEditWhenModelStateIsValidItGoesBackToIndexView()
		{
			//--Arrange
			_controller.Setup(mock => mock.Edit(It.IsNotNull<Game>())).Returns(new ViewResult { ViewName = MVC.Game.Views.Index });

			//--Act
			var result = _controller.Object.Edit(_testModel) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Game.Views.Index, result.ViewName);
		}

		[Test]
		public void ThatWhenModelStateIsNotValidItRedirectsBackToEditView()
		{
			//--Arrange
			_controller.Setup(mock => mock.Edit(It.IsNotNull<Game>())).Returns(new ViewResult { ViewName = MVC.Game.Views.Edit });
			_controller.Object.ModelState.AddModelError("", "");

			//--Act
			var result = _controller.Object.Edit(_testModel) as ViewResult;

			//--Assert
			Assert.IsFalse(_controller.Object.ModelState.IsValid);
			Assert.AreEqual(MVC.Game.Views.Edit, result.ViewName);
		}

		[Test]
		public void ThatOnEditADuplicateGameIsFoundItRedirectsBackToEditView()
		{
			//--TODO: need to set up dependency
			//--Arrange
			_controller.Setup(mock => mock.Edit(It.IsNotNull<Game>())).Returns(new ViewResult { ViewName = MVC.Game.Views.Edit });

			//--Act
			var result = _controller.Object.Edit(_testModel) as ViewResult;

			//--Assert
			Assert.AreEqual(0, 1);
			Assert.AreEqual(MVC.Game.Views.Edit, result.ViewName);
		}

		[Test]
		public void ThatItGoesToIndexViewAfterDelete()
		{
			//--Arrange
			_controller.Setup(mock => mock.Delete(It.IsNotNull<int>())).Returns(new ViewResult { ViewName = MVC.Game.Views.Index });

			//--Act
			var result = _controller.Object.Delete(666) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Game.Views.Index, result.ViewName);
		}
	}
}