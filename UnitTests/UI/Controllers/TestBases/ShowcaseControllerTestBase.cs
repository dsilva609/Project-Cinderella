using NUnit.Framework;
using StructureMap.AutoMocking;
using UI.Controllers;

namespace UnitTests.UI.Controllers.TestBases
{
    public class ShowcaseControllerTestBase : ControllerTestBase
    {
        protected RhinoAutoMocker<ShowcaseController> _controller;

        [SetUp]
        public virtual void SetUp()
        {
            _controller = new RhinoAutoMocker<ShowcaseController>();
            _controller.ClassUnderTest.ControllerContext = SetupAuthorization("Admin", true, true).Object;
        }
    }
}