using NUnit.Framework;
using StructureMap.AutoMocking;
using UI.Controllers;

namespace UnitTests.UI.Controllers.TestBases
{
	public class StatisticsControllerTestBase
	{
		protected RhinoAutoMocker<StatisticsController> _controller;

		[SetUp]
		public virtual void SetUp()
		{
			_controller = new RhinoAutoMocker<StatisticsController>();
		}
	}
}