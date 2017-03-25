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
		protected Mock<IMovieService> _service;

		[SetUp]
		public virtual void SetUp()
		{
			_service = new Mock<IMovieService>();
			_controller = new RhinoAutoMocker<MovieController>();
			_controller.Inject(_service.Object);
			_controller.ClassUnderTest.ControllerContext = SetupAuthorization("Admin", true, true).Object;
			_session["movieResult"] = null;
			_session["wish"] = null;
		}
	}
}