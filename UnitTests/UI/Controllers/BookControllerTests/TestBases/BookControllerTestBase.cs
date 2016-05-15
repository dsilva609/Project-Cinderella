using BusinessLogic.Services.Interfaces;
using Moq;
using NUnit.Framework;
using UI.Controllers;

namespace UnitTests.UI.Controllers.BookControllerTests.TestBases
{
	public class BookControllerTestBase
	{
		protected Mock<BookController> _controller;
		protected IBookService _service;

		[SetUp]
		public virtual void SetUp()
		{
			_service = Mock.Of<IBookService>();
			_controller = new Mock<BookController>(_service);
		}
	}
}