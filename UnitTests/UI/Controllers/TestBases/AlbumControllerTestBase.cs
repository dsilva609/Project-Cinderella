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
		protected IAlbumService _service;
		protected IDiscogsService _discogsService;

		[SetUp]
		public virtual void SetUp()
		{
			_service = Mock.Of<IAlbumService>();
			_discogsService = Mock.Of<IDiscogsService>();
			_controller = new RhinoAutoMocker<AlbumController>();
			_controller.ClassUnderTest.ControllerContext = SetupAuthorization("Admin", true, true).Object;
			//_controller.Inject(_service);
			//_controller.Inject(_discogsService);
		}
	}
}