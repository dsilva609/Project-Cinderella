using BusinessLogic.Services.Interfaces;
using Moq;
using NUnit.Framework;
using StructureMap.AutoMocking;
using UI.Controllers;

namespace UnitTests.UI.Controllers.TestBases
{
    public class AlbumControllerTestBase : ControllerTestBase
    {
        protected RhinoAutoMocker<AlbumController> _controller;
        protected Mock<IAlbumService> _service;

        [SetUp]
        public virtual void SetUp()
        {
            _service = new Mock<IAlbumService>();
            _controller = new RhinoAutoMocker<AlbumController>();
            _controller.Inject(_service.Object);
            _controller.ClassUnderTest.ControllerContext = SetupAuthorization("Admin", true, true).Object;
            _session["albumResult"] = null;
        }
    }
}