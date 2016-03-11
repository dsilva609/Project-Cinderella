using NUnit.Framework;
using System.Web.Mvc;
using UnitTests.UI.Controllers.RecordControllerTests.TestBases;

namespace UnitTests.UI.Controllers.RecordControllerTests
{
    [TestFixture]
    public class RecordControllerTests : RecordControllerTestBase
    {
        [Test]
        public void ThatTheIndexActionReturnsAView()
        {
            //--Arrange
            _controller.Setup(mock => mock.Index()).Returns(new ViewResult { ViewName = MVC.Record.Views.Index });

            //--Act
            var result = _controller.Object.Index() as ViewResult;

            //--Assert
            Assert.AreEqual(MVC.Record.Views.Index, result.ViewName);
        }

        [Test]
        public void ThatEditGetActionReturnsAView()
        {
            //--Arrange
            _controller.Setup(mock => mock.Edit()).Returns(new ViewResult() { ViewName = MVC.Record.Views.Edit });

            //--Act
            var result = _controller.Object.Edit() as ViewResult;

            //--Assert
            Assert.AreEqual(MVC.Record.Views.Edit, result.ViewName);
        }

        [Test]
        public void ThatCorrectModelIsPassedIntoEditGetView()
        {
            //--Arrange

            //--Act
            //--Assert
            Assert.AreEqual(0, 1);
        }
    }
}