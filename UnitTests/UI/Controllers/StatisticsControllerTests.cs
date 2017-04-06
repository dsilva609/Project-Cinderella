using NUnit.Framework;
using Shouldly;
using System.Web.Mvc;
using UnitTests.UI.Controllers.TestBases;

namespace UnitTests.UI.Controllers
{
    [TestFixture]
    public class StatisticsControllerTests : StatisticsControllerTestBase
    {
        [Test]
        public void ThatIndexActionReturnsAView()
        {
            var result = _controller.ClassUnderTest.Index() as ViewResult;

            result.ViewName.ShouldBe(string.Empty);
        }

        [Test]
        public void ThatAlbumStatsActionReturnsAView()
        {
            var result = _controller.ClassUnderTest.AlbumStats() as ViewResult;

            result.ViewName.ShouldBe(string.Empty);
        }
    }
}