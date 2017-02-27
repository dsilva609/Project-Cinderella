using NUnit.Framework;
using StructureMap.AutoMocking;
using UI.Controllers;

namespace UnitTests.UI.Controllers.TestBases
{
    public class WishControllerTestBase : ControllerTestBase
    {
        protected RhinoAutoMocker<WishController> _controller;

        [SetUp]
        public virtual void SetUp()
        {
            _controller = new RhinoAutoMocker<WishController>();
            _controller.ClassUnderTest.ControllerContext = SetupAuthorization("Admin", true, true).Object;
            _session["albumResult"] = null;
        }
    }
}