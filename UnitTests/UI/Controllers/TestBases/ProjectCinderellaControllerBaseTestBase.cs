using NUnit.Framework;
using StructureMap.AutoMocking;
using UI.Controllers;

namespace UnitTests.UI.Controllers.TestBases
{
	public class ProjectCinderellaControllerBaseTestBase : ControllerTestBase
	{
		protected RhinoAutoMocker<ProjectCinderellaControllerBase> _controller;

		[SetUp]
		public virtual void SetUp()
		{
			_controller = new RhinoAutoMocker<ProjectCinderellaControllerBase>();
			_controller.ClassUnderTest.ControllerContext = SetupAuthorization("Admin", true, true).Object;
		}
	}
}