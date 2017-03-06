using BusinessLogic.Enums;
using NUnit.Framework;
using Shouldly;
using System.Web.Mvc;
using UnitTests.UI.Controllers.TestBases;

namespace UnitTests.UI.Controllers
{
    public class ShowcaseControllerTests : ShowcaseControllerTestBase
    {
        [Test]
        public void ThatIndexActionReturnsAView()
        {
            var result = _controller.ClassUnderTest.Index() as ViewResult;

            string.IsNullOrWhiteSpace(result.ViewName).ShouldBeTrue();
        }

        [Test]
        public void ThatAddActionReturnsAView()
        {
            var result = _controller.ClassUnderTest.Add() as ViewResult;

            string.IsNullOrWhiteSpace(result.ViewName).ShouldBeTrue();
        }

        [Test]
        [TestCase(ItemType.Album)]
        [TestCase(ItemType.Book)]
        [TestCase(ItemType.Game)]
        [TestCase(ItemType.Movie)]
        public void ThatSearchRedirectsToCorrectController(ItemType type)
        {
            var result = _controller.ClassUnderTest.SearchItems("test", type) as RedirectToRouteResult;

            result.RouteValues["Controller"].ShouldBe(type.ToString());
            result.RouteValues["Action"].ShouldBe("Index");
        }
    }
}