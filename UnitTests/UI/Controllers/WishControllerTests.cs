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
    public class WishControllerTests : WishControllerTestBase
    {
        private Wish _testModel = new Wish();

        [Test]
        public void ThatTheIndexActionReturnsAView()
        {
            _session["query"] = string.Empty;

            //--Act
            var result = _controller.ClassUnderTest.Index(string.Empty, string.Empty, 1) as ViewResult;

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
            //--Arrange
            _controller.Get<IWishService>().Expect(x => x.GetByID(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(new Wish { ID = 666 });

            //--Act
            var result = _controller.ClassUnderTest.Edit(666) as ViewResult;

            //--Assert
            Assert.AreEqual(string.Empty, result.ViewName);
        }

        [Test]
        public void ItGoesToIndexViewAfterDelete()
        {
            _controller.Get<IWishService>().Expect(x => x.GetByID(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(new Wish { ID = 666, UserID = "Test User" });

            //--Act
            var result = _controller.ClassUnderTest.Delete(666) as RedirectToRouteResult;

            //--Assert
            Assert.AreEqual("Index", result.RouteValues["Action"]);
        }

        [Test]
        public void ThatOnEditWhenModelStateIsValidItGoesBackToIndexView()
        {
            //--Arrange
            _controller.Get<IWishService>()
                .Expect(x => x.GetAll(Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<int>.Is.Anything, Arg<int>.Is.Anything))
                .Return(new List<Wish>());

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
        public void ThatOnEditADuplicateRecordIsFoundItRedirectsBackToEditView()
        {
            //--Arrange
            _controller.Get<IWishService>()
                .Expect(x => x.GetAll(Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<int>.Is.Anything, Arg<int>.Is.Anything))
                .Return(new List<Wish> { new Wish { ID = 1, Title = "Kill 'Em All" } });
            _testModel.ID = 2;
            _testModel.Title = "Kill 'Em All";

            //--Act
            var result = _controller.ClassUnderTest.Edit(_testModel) as ViewResult;

            //--Assert
            result.ViewName.ShouldBe(string.Empty);
        }

        [Test]
        public void ThatDetailsActionReturnsAView()
        {
            //--Act
            var result = _controller.ClassUnderTest.Details(72) as ViewResult;

            //--Assert
            Assert.AreEqual(string.Empty, result.ViewName);
        }
    }
}