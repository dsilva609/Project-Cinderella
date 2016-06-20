using BusinessLogic.Services.Interfaces;
using NUnit.Framework;
using StructureMap.AutoMocking;
using UI.Controllers;

namespace UnitTests.UI.Controllers.AlbumControllerTests.TestBases
{
	public class AlbumControllerTestBase
	{
		protected RhinoAutoMocker<AlbumController> _controller;
		protected IAlbumService _service;
		protected IDiscogsService _discogsService;

		[SetUp]
		public virtual void SetUp()
		{
			//_service = Mock.Of<IAlbumService>();
			//_discogsService = Mock.Of<IDiscogsService>();
			_controller = new RhinoAutoMocker<AlbumController>();
			_controller.PartialMockTheClassUnderTest();
			//_controller.Inject(_service);
			//_controller.Inject(_discogsService);
		}
	}
}