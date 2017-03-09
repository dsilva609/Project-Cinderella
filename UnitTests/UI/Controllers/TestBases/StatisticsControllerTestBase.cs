using NUnit.Framework;
using StructureMap.AutoMocking;
using UI.Controllers;

namespace UnitTests.UI.Controllers.TestBases
{
    public class StatisticsControllerTestBase : ControllerTestBase
    {
        protected RhinoAutoMocker<StatisticsController> _controller;

        [SetUp]
        public virtual void SetUp()
        {
            _controller = new RhinoAutoMocker<StatisticsController>();
            _controller.ClassUnderTest.ControllerContext = SetupAuthorization("Admin", true, true).Object;
        }
    }
}