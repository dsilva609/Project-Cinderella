using BusinessLogic.Services.Interfaces;
using Moq;
using NUnit.Framework;
using StructureMap.AutoMocking;
using UI.Controllers;

namespace UnitTests.UI.Controllers.TestBases
{
	public class PopControllerTestBase : ControllerTestBase
	{
		protected RhinoAutoMocker<PopController> _controller;
		protected Mock<IPopService> _service;

		[SetUp]
		public virtual void SetUp()
		{
			_service = new Mock<IPopService>();
			_controller = new RhinoAutoMocker<PopController>();
			_controller.Inject(_service.Object);
			_controller.ClassUnderTest.ControllerContext = SetupAuthorization("Admin", true, true).Object;
			_session["popQuery"] = null;
			_session["popWish"] = null;
		}
	}
}