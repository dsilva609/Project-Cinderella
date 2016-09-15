using NUnit.Framework;
using StructureMap.AutoMocking;
using UI.Controllers;

namespace UnitTests.UI.Controllers.TestBases
{
    public class HomeControllerTestBase : ControllerTestBase
    {
        protected RhinoAutoMocker<HomeController> _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new RhinoAutoMocker<HomeController>();
            _controller.ClassUnderTest.ControllerContext = SetupAuthorization("Admin", true, true).Object;
        }
    }
}