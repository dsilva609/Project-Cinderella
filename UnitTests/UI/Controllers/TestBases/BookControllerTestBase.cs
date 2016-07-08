using BusinessLogic.Services.Interfaces;
using Moq;
using NUnit.Framework;
using UI.Controllers;

namespace UnitTests.UI.Controllers.TestBases
{
	public class BookControllerTestBase : ControllerTestBase
	{
		protected Mock<BookController> _controller;
		protected IBookService _service;
		protected IGoogleBookService _googleBookService;

		[SetUp]
		public virtual void SetUp()
		{
			_service = Mock.Of<IBookService>();
			_googleBookService = Mock.Of<IGoogleBookService>();
			_controller = new Mock<BookController>(_service, _googleBookService);
			//TODO: add this in to test controller context
			//	_controller.Object.ControllerContext = SetupSession().Object;
		}
	}
}