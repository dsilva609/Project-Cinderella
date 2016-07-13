using NUnit.Framework;
using StructureMap.AutoMocking;
using UI.Controllers;

namespace UnitTests.UI.Controllers.TestBases
{
	public class HomeControllerTestBase
	{
		protected RhinoAutoMocker<HomeController> _homeControllerMock;

		[SetUp]
		public void Setup()
		{
			_homeControllerMock = new RhinoAutoMocker<HomeController>();
		}
	}
}