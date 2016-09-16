using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using Moq;
using NUnit.Framework;
using Rhino.Mocks;
using System.Collections.Generic;
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
            //--Arrange
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
            _controller.Get<IGameService>().Expect(x => x.GetByID(Arg<int>.Is.Equal(42), Arg<string>.Is.Anything)).Return(new Game { ID = 42 });
            //--Act
            var result = _controller.ClassUnderTest.Edit(42) as ViewResult;

            //--Assert
            Assert.AreEqual(string.Empty, result.ViewName);
        }

        [Test]
        public void ThatOnEditWhenModelStateIsValidItGoesBackToIndexView()
        {
            //--Arrange
            _controller.Get<IGameService>().Expect(x => x.GetAll(It.IsAny<string>())).Return(new List<Game>());

            //--Act
            var result = _controller.ClassUnderTest.Edit(_testModel) as RedirectToRouteResult;

            //--Assert
            Assert.AreEqual("Index", result.RouteValues["Action"]);
        }

        [Test]
        public void ThatWhenModelStateIsNotValidItRedirectsBackToEditView()
        {
            //--Arrange
            _controller.ClassUnderTest.ModelState.AddModelError("", "");

            //--Act
            var result = _controller.ClassUnderTest.Edit(_testModel) as ViewResult;

            //--Assert
            Assert.IsFalse(_controller.ClassUnderTest.ModelState.IsValid);
            Assert.AreEqual(string.Empty, result.ViewName);
        }

        [Test]
        public void ThatOnEditADuplicateGameIsFoundItRedirectsBackToEditView()
        {
            //--Arrange
            _controller.Get<IGameService>().Expect(x => x.GetAll(It.IsAny<string>()))
                .Return(new List<Game> { new Game { ID = 1, Title = "Final Fantasy", Developer = "Squeenix" } });
            _testModel.ID = 2;
            _testModel.Title = "Final Fantasy";
            _testModel.Developer = "Squeenix";

            //--Act
            var result = _controller.ClassUnderTest.Edit(_testModel) as ViewResult;

            //--Assert
            Assert.AreEqual(string.Empty, result.ViewName);
        }

        [Test]
        public void ThatItGoesToIndexViewAfterDelete()
        {
            _controller.Get<IGameService>().Expect(x => x.GetByID(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(new Game { ID = 666, UserID = "Test User" });

            //--Act
            var result = _controller.ClassUnderTest.Delete(666) as RedirectToRouteResult;

            //--Assert
            Assert.AreEqual("Index", result.RouteValues["Action"]);
        }
    }
}