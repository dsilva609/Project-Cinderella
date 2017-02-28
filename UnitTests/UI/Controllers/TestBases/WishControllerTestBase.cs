using BusinessLogic.Services.Interfaces;
using Moq;
using NUnit.Framework;
using StructureMap.AutoMocking;
using UI.Controllers;

namespace UnitTests.UI.Controllers.TestBases
{
    public class WishControllerTestBase : ControllerTestBase
    {
        protected RhinoAutoMocker<WishController> _controller;
        protected Mock<IWishService> _service;

        [SetUp]
        public virtual void SetUp()
        {
            _service = new Mock<IWishService>();
            _controller = new RhinoAutoMocker<WishController>();
            _controller.Inject(_service.Object);
            _controller.ClassUnderTest.ControllerContext = SetupAuthorization("Admin", true, true).Object;
            _session["albumResult"] = null;
        }
    }
}