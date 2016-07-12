using NUnit.Framework;
using StructureMap.AutoMocking;
using UI.Controllers;

namespace UnitTests.UI.Controllers.TestBases
{
	public class GameControllerTestBase : ControllerTestBase
	{
		protected RhinoAutoMocker<GameController> _controller;

		[SetUp]
		public virtual void SetUp()
		{
			_controller = new RhinoAutoMocker<GameController>();
			_controller.ClassUnderTest.ControllerContext = SetupAuthorization("Admin", true, true).Object;
			_session["gameResult"] = null;
		}
	}
}