using BusinessLogic.Services.Interfaces;
using Moq;
using NUnit.Framework;
using StructureMap.AutoMocking;
using UI.Controllers;

namespace UnitTests.UI.Controllers.TestBases
{
    public class GameControllerTestBase : ControllerTestBase
    {
        protected RhinoAutoMocker<GameController> _controller;
        protected Mock<IGameService> _service;

        [SetUp]
        public virtual void SetUp()
        {
            _service = new Mock<IGameService>();
            _controller = new RhinoAutoMocker<GameController>();
            _controller.Inject(_service.Object);
            _controller.ClassUnderTest.ControllerContext = SetupAuthorization("Admin", true, true).Object;
            _session["gameResult"] = null;
        }
    }
}