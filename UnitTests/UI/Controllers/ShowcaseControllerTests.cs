using System.Collections.Generic;
using BusinessLogic.Enums;
using NUnit.Framework;
using Shouldly;
using System.Web.Mvc;
using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using Rhino.Mocks;
using UnitTests.UI.Controllers.TestBases;

namespace UnitTests.UI.Controllers
{
    public class ShowcaseControllerTests : ShowcaseControllerTestBase
    {
        [Test]
        public void ThatIndexActionReturnsAView()
        {
            _controller.Get<IAlbumService>()
                .Expect(x => x.GetAll(Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<int>.Is.Anything, Arg<int?>.Is.Anything))
                .Return(new List<Album>());
            _controller.Get<IBookService>()
                .Expect(x => x.GetAll(Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<int>.Is.Anything, Arg<int?>.Is.Anything))
                .Return(new List<Book>());
            _controller.Get<IGameService>()
                .Expect(x => x.GetAll(Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<int>.Is.Anything, Arg<int?>.Is.Anything))
                .Return(new List<Game>());
            _controller.Get<IMovieService>()
                .Expect(x => x.GetAll(Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<int>.Is.Anything, Arg<int?>.Is.Anything))
                .Return(new List<Movie>());

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