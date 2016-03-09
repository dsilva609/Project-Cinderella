using NUnit.Framework;
using System.Web.Mvc;
using UnitTests.UI.Controllers.HomeControllerTests.TestBases;

namespace UnitTests.UI.Controllers.HomeControllerTests
{
	[TestFixture]
	public class HomeControllerTests : HomeControllerTestBase
	{
		[Test]
		public void ThatIndexActionReturnsAView()
		{
			//--Arrange
			base._homeControllerMock.Setup(mock => mock.Index()).Returns(new ViewResult { ViewName = MVC.Home.Views.Index });

			//--Act
			var result = base._homeControllerMock.Object.Index() as ViewResult;

			// Assert
			Assert.AreEqual(MVC.Home.Views.Index, result.ViewName);
		}

		[Test]
		public void ThatAboutActionReturnsAView()
		{
			//--Arrange
			base._homeControllerMock.Setup(mock => mock.About()).Returns(new ViewResult { ViewName = MVC.Home.Views.About });

			//--Act
			var result = base._homeControllerMock.Object.About() as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Home.Views.About, result.ViewName);
		}

		[Test]
		public void ThatContactActionReturnsAView()
		{
			// Arrange
			base._homeControllerMock.Setup(mock => mock.Contact()).Returns(new ViewResult { ViewName = MVC.Home.Views.Contact });

			//--Act
			var result = base._homeControllerMock.Object.Contact() as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Home.Views.Contact, result.ViewName);
		}
	}
}