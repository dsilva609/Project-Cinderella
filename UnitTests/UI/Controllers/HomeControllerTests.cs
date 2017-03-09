using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;
using System.Collections.Generic;
using System.Web.Mvc;
using UnitTests.UI.Controllers.TestBases;

namespace UnitTests.UI.Controllers
{
    [TestFixture]
    public class HomeControllerTests : HomeControllerTestBase
    {
        [Test]
        public void ThatIndexActionReturnsAView()
        {
            //--Arrange
            _controller.Get<IAlbumService>()
                .Expect(x => x.GetAll(Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<int>.Is.Anything, Arg<int>.Is.Anything))
                .Return(new List<Album> { new Album() });
            _controller.Get<IBookService>()
                .Expect(x => x.GetAll(Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<int>.Is.Anything, Arg<int>.Is.Anything))
                .Return(new List<Book>());
            _controller.Get<IMovieService>()
                .Expect(x => x.GetAll(Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<int>.Is.Anything, Arg<int>.Is.Anything))
                .Return(new List<Movie>());
            _controller.Get<IGameService>()
                .Expect(x => x.GetAll(Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<int>.Is.Anything, Arg<int>.Is.Anything))
                .Return(new List<Game>());

            //--Act
            var result = _controller.ClassUnderTest.Index() as ViewResult;

            // Assert
            Assert.AreEqual(string.Empty, result.ViewName);
        }

        [Test]
        public void ThatAboutActionReturnsAView()
        {
            //--Act
            var result = _controller.ClassUnderTest.About() as ViewResult;

            //--Assert
            Assert.AreEqual(string.Empty, result.ViewName);
        }

        [Test]
        public void ThatContactActionReturnsAView()
        {
            //--Act
            var result = _controller.ClassUnderTest.Contact() as ViewResult;

            //--Assert
            Assert.AreEqual(string.Empty, result.ViewName);
        }

        [Test]
        [TestCase("Metallica", ItemType.Album, "Index")]
        [TestCase("Killing Joke", ItemType.Book, "Search")]
        [TestCase("Notebook", ItemType.Movie, "Create")]
        [TestCase("Until Dawn", ItemType.Game, "Index")]
        public void ThatSearchActionReturnsCorrectPage(string query, ItemType type, string act)
        {
            var result = _controller.ClassUnderTest.Search(query, type, act) as RedirectToRouteResult;

            result.RouteValues["Action"].ShouldBe(act);
            result.RouteValues["Controller"].ShouldBe(type.ToString());
        }
    }
}