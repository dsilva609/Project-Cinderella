using Moq;
using NUnit.Framework;
using UI.Controllers;

namespace UnitTests.UI.Controllers.BookControllerTests.TestBases
{
	public class BookControllerTestBase
	{
		protected Mock<BookController> _controller;

		[SetUp]
		public virtual void SetUp()
		{
			_controller = new Mock<BookController>();
		}
	}
}