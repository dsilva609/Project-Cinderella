using BusinessLogic.Services.Interfaces;
using Moq;
using NUnit.Framework;
using UI.Controllers;

namespace UnitTests.UI.Controllers.AlbumControllerTests.TestBases
{
	public class RecordControllerTestBase
	{
		protected Mock<AlbumController> _controller;
		protected IAlbumService _service;

		[SetUp]
		public virtual void SetUp()
		{
			_service = Mock.Of<IAlbumService>();
			_controller = new Mock<AlbumController>(_service);
		}
	}
}