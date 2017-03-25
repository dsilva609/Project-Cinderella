using BusinessLogic.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Web.Mvc;
using UnitTests.UI.Controllers.TestBases;

namespace UnitTests.UI.Controllers
{
	public class QueueControllerTests : QueueControllerTestBase
	{
		[Test]
		public void ThatTheIndexActionReturnsAView()
		{
			_albumService.Setup(x => x.GetAll(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
				.Returns(new List<Album>());
			_bookService.Setup(x => x.GetAll(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
				.Returns(new List<Book>());
			_gameService.Setup(x => x.GetAll(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
				.Returns(new List<Game>());
			_movieService.Setup(x => x.GetAll(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
				.Returns(new List<Movie>());

			var result = _controller.ClassUnderTest.Index() as ViewResult;

			Assert.AreEqual(string.Empty, result.ViewName);
		}
	}
}