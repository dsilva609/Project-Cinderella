using BusinessLogic.Services.Interfaces;
using Moq;
using NUnit.Framework;
using StructureMap.AutoMocking;
using UI.Controllers;

namespace UnitTests.UI.Controllers.TestBases
{
	public class QueueControllerTestBase : ControllerTestBase
	{
		protected RhinoAutoMocker<QueueController> _controller;
		protected Mock<IAlbumService> _albumService;
		protected Mock<IBookService> _bookService;
		protected Mock<IGameService> _gameService;
		protected Mock<IMovieService> _movieService;

		[SetUp]
		public virtual void SetUp()
		{
			_albumService = new Mock<IAlbumService>();
			_bookService = new Mock<IBookService>();
			_gameService = new Mock<IGameService>();
			_movieService = new Mock<IMovieService>();
			_controller = new RhinoAutoMocker<QueueController>();
			_controller.Inject(_albumService.Object);
			_controller.Inject(_bookService.Object);
			_controller.Inject(_gameService.Object);
			_controller.Inject(_movieService.Object);
			_controller.ClassUnderTest.ControllerContext = SetupAuthorization("Admin", true, true).Object;
		}
	}
}