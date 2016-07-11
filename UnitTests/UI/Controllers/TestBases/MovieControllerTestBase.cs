using BusinessLogic.Services.Interfaces;
using Moq;
using NUnit.Framework;
using StructureMap.AutoMocking;
using UI.Controllers;

namespace UnitTests.UI.Controllers.TestBases
{
	public class MovieControllerTestBase : ControllerTestBase
	{
		protected RhinoAutoMocker<MovieController> _controller;
		protected IMovieService _service;
		protected ITMDBService _tmdbService;
		protected Mock<MovieController> _test;

		[SetUp]
		public virtual void SetUp()
		{
			_service = Mock.Of<IMovieService>();
			_tmdbService = Mock.Of<ITMDBService>();
			_controller = new RhinoAutoMocker<MovieController>();
			_test = new Mock<MovieController>();
			_controller.Inject(_service);
			_controller.Inject(_tmdbService);
			_controller.ClassUnderTest.ControllerContext = SetupAuthorization("Admin", true, true).Object;
			_session["movieResult"] = null;
		}
	}
}