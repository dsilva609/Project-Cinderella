using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using Moq;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;
using System.Collections.Generic;
using System.Web.Mvc;
using UI.Models;
using UnitTests.UI.Controllers.TestBases;

namespace UnitTests.UI.Controllers
{
    [TestFixture]
    public class MovieControllerTests : MovieControllerTestBase
    {
        private Movie _testModel = new Movie();

        [Test]
        public void ThatIndexActionReturnsAView()
        {
            _session["query"] = string.Empty;
            //--Act
            var result = _controller.ClassUnderTest.Index(string.Empty, string.Empty, 1) as ViewResult;

            //--Assert
            Assert.AreEqual(string.Empty, result.ViewName);
        }

        [Test]
        public void ThatDetailsActionRetunsAView()
        {
            //--Act
            var result = _controller.ClassUnderTest.Details(72) as ViewResult;

            //--Assert
            Assert.AreEqual(string.Empty, result.ViewName);
        }

        [Test]
        public void ThatCreateActionReturnsAView()
        {
            //--Act
            var result = _controller.ClassUnderTest.Create() as ViewResult;

            //--Assert
            Assert.AreEqual(string.Empty, result.ViewName);
        }

        [Test]
        public void ItRedirectsToIndexActionWhenModelIsValid()
        {
            //--Act
            var result = _controller.ClassUnderTest.Create(_testModel) as RedirectToRouteResult;

            //--Assert
            Assert.IsTrue(_controller.ClassUnderTest.ModelState.IsValid);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
        }

        [Test]
        public void ItGoesBackToTheViewIfModelStateIsInvalid()
        {
            _controller.ClassUnderTest.ModelState.AddModelError(string.Empty, string.Empty);

            //--Act
            var result = _controller.ClassUnderTest.Create(_testModel) as ViewResult;

            //--Assert
            Assert.AreEqual(string.Empty, result.ViewName);
            Assert.IsFalse(_controller.ClassUnderTest.ModelState.IsValid);
        }

        [Test]
        public void ThatEditActionReturnsAView()
        {
            //--Arrange
            _controller.Get<IMovieService>().Expect(x => x.GetByID(Arg<int>.Is.Equal(42), Arg<string>.Is.Anything))
                .Return(new Movie { ID = 42 });

            //--Act
            var result = _controller.ClassUnderTest.Edit(42) as ViewResult;

            //--Assert
            Assert.AreEqual(string.Empty, result.ViewName);
        }

        [Test]
        public void ThatOnEditWhenModelStateIsValidItGoesBackToIndexView()
        {
            //--Arrange
            _controller.Get<IMovieService>().Expect(x => x.GetAll(It.IsAny<string>())).Return(new List<Movie>());

            //--Act
            var result = _controller.ClassUnderTest.Edit(_testModel) as RedirectToRouteResult;

            //--Assert
            result.RouteValues["Action"].ShouldBe("Index");
        }

        [Test]
        public void ThatWhenModelStateIsNotValidItRedirectsBackToEditView()
        {
            _controller.ClassUnderTest.ModelState.AddModelError("", "");

            //--Act
            var result = _controller.ClassUnderTest.Edit(_testModel) as ViewResult;

            //--Assert
            Assert.IsFalse(_controller.ClassUnderTest.ModelState.IsValid);
            Assert.AreEqual(string.Empty, result.ViewName);
        }

        [Test]
        public void ThatOnEditADuplicateMovieIsFoundItRedirectsBackToEditView()
        {
            //--Arrange
            _controller.Get<IMovieService>()
                .Expect(x => x.GetAll(Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<int>.Is.Anything, Arg<int>.Is.Anything))
                .Return(new List<Movie> { new Movie { ID = 1, Title = "Deadpool", Type = MovieMediaTypeEnum.Bluray, UserID = "TestUser" } });
            _testModel.ID = 1;
            _testModel.Title = "Deadpool";
            _testModel.Type = MovieMediaTypeEnum.Bluray;

            //--Act
            var result = _controller.ClassUnderTest.Edit(_testModel) as ViewResult;

            //--Assert
            Assert.AreEqual(string.Empty, result.ViewName);
        }

        [Test]
        public void ThatItGoesToIndexViewAfterDelete()
        {
            _controller.Get<IMovieService>().Expect(x => x.GetByID(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(new Movie { ID = 666, UserID = "Test User" });
            //--Act
            var result = _controller.ClassUnderTest.Delete(666) as RedirectToRouteResult;

            //--Assert
            Assert.AreEqual("Index", result.RouteValues["Action"]);
        }

        [Test]
        public void ThatSearchActionReturnsAView()
        {
            //--Act
            var result = _controller.ClassUnderTest.Search(new MovieSearchModel { Title = string.Empty }) as ViewResult;

            //--Assert
            Assert.AreEqual(string.Empty, result.ViewName);
        }
    }
}