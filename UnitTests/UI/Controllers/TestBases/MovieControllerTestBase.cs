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

		[SetUp]
		public virtual void SetUp()
		{
			_service = Mock.Of<IMovieService>();
			_controller = new RhinoAutoMocker<MovieController>();
			_controller.ClassUnderTest.ControllerContext = SetupAuthorization("Admin", true, true).Object;
		}
	}
}