using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Models.DiscogsModels;
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
	public class AlbumControllerTests : AlbumControllerTestBase
	{
		private Album _testModel = new Album();

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
		public void ItGoesToIndexViewAfterDelete()
		{
			_service.Setup(x => x.GetByID(666, Arg<string>.Is.Anything))
				.Returns(new Album { ID = 666, UserID = "Test User" });

			//--Act
			var result = _controller.ClassUnderTest.Delete(666) as RedirectToRouteResult;

			//--Assert
			Assert.AreEqual("Index", result.RouteValues["Action"]);
		}

		[Test]
		public void ThatEditActionReturnsAView()
		{
			//--Arrange
			_service.Setup(x => x.GetByID(666, Arg<string>.Is.Anything))
				.Returns(new Album { ID = 666 });

			//--Act
			var result = _controller.ClassUnderTest.Edit(666) as ViewResult;

			//--Assert
			Assert.AreEqual(string.Empty, result.ViewName);
		}

		[Test]
		public void ThatOnEditWhenModelStateIsValidItGoesBackToIndexView()
		{
			//--Arrange
			_service.Setup(x => x.GetAll(It.Is<string>(y => y == null), string.Empty, 0, 1)).Returns(new List<Album>());

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
			_service.Setup(x => x.GetAll(It.Is<string>(y => y == null), string.Empty, It.IsAny<int>(), It.IsAny<int>()))
				.Returns(new List<Album>
				{
					new Album
					{
						ID = 1,
						Title = "Kill 'Em All",
						Artist = "Metallica",
						UserID = "test",
						DiscogsID = 0,
						MediaType = AlbumMediaTypeEnum.Vinyl
					}
				});
			_testModel.ID = 2;
			_testModel.Title = "Kill 'Em All";
			_testModel.Artist = "Metallica";
			_testModel.MediaType = AlbumMediaTypeEnum.Vinyl;
			_testModel.DiscogsID = 0;

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

		[Test]
		public void ThatSearchActionReturnsAView()
		{
			//--Act
			var result = _controller.ClassUnderTest.Search(new DiscogsSearchModel()) as ViewResult;

			//--Assert
			Assert.AreEqual(string.Empty, result.ViewName);
		}

		[Test]
		public void ThatCreateFromSearchModelActionReturnsAView()
		{
			//--Arrange
			_controller.Get<IDiscogsService>().Expect(x => x.GetRelease(Arg<int>.Is.Anything))
				.Return(new Album());

			//--Act
			var result = _controller.ClassUnderTest.CreateFromSearchResult(It.IsAny<int>()) as RedirectToRouteResult;

			//--Assert
			Assert.AreEqual("Create", result.RouteValues["Action"]);
		}

		[Test]
		public void ThatSearchForWishPopulatesModelCorrectly()
		{
			_session["query"] = null;
			_session["wish"] = "Another Perfect Day";
			_controller.Get<IDiscogsService>()
				.Expect(x => x.Search(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
				.Return(new List<DiscogsResult>());

			var result = _controller.ClassUnderTest.Search(new DiscogsSearchModel()) as ViewResult;

			((DiscogsSearchModel)result.Model).AlbumName.ShouldBe("Another Perfect Day");
		}

		[Test]
		public void ItAddsAnAlbumToShowcase()
		{
			_service.Setup(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>())).Returns(new Album());

			var result = _controller.ClassUnderTest.AddToShowcase(1) as RedirectToRouteResult;

			_service.Verify(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
			_service.Verify(x => x.Edit(It.IsAny<Album>()), Times.Once);

			result.RouteValues["Action"].ShouldBe("Index");
			result.RouteValues["Controller"].ShouldBe("Showcase");
		}

		[Test]
		public void ItRemovesAnAlbumFromTheShowcase()
		{
			_service.Setup(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>())).Returns(new Album());

			var result = _controller.ClassUnderTest.RemoveFromShowcase(1) as RedirectToRouteResult;

			_service.Verify(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
			_service.Verify(x => x.Edit(It.IsAny<Album>()), Times.Once);

			result.RouteValues["Action"].ShouldBe("Index");
			result.RouteValues["Controller"].ShouldBe("Showcase");
		}

		[Test]
		public void ItIncreasesCompletionCount()
		{
			_service.Setup(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>())).Returns(new Album());

			var result = _controller.ClassUnderTest.IncreaseCompletionCount(1) as RedirectToRouteResult;

			_service.Verify(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
			_service.Verify(x => x.Edit(It.IsAny<Album>()), Times.Once);

			result.RouteValues["Action"].ShouldBe("Index");
			result.RouteValues["Controller"].ShouldBe("Album");
		}

		[Test]
		public void ItDecreasesCompletionCount()
		{
			_service.Setup(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>())).Returns(new Album());

			var result = _controller.ClassUnderTest.DecreaseCompletionCount(1) as RedirectToRouteResult;

			_service.Verify(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
			_service.Verify(x => x.Edit(It.IsAny<Album>()), Times.Once);

			result.RouteValues["Action"].ShouldBe("Index");
			result.RouteValues["Controller"].ShouldBe("Album");
		}

		[Test]
		public void ItAddsToQueue()
		{
			_service.Setup(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>())).Returns(new Album());

			var result = _controller.ClassUnderTest.AddToQueue(1) as RedirectToRouteResult;

			_service.Verify(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
			_service.Verify(x => x.Edit(It.IsAny<Album>()), Times.Once);
			_service.Verify(x => x.GetHighestQueueRank(It.IsAny<string>()), Times.Once);

			result.RouteValues["Action"].ShouldBe("Index");
			result.RouteValues["Controller"].ShouldBe("Queue");
		}

		[Test]
		public void ItRemovesFromQueue()
		{
			_service.Setup(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>())).Returns(new Album());

			var result = _controller.ClassUnderTest.RemoveFromQueue(1) as RedirectToRouteResult;

			_service.Verify(x => x.GetByID(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
			_service.Verify(x => x.Edit(It.IsAny<Album>()), Times.Once);

			result.RouteValues["Action"].ShouldBe("Index");
			result.RouteValues["Controller"].ShouldBe("Queue");
		}
	}
}