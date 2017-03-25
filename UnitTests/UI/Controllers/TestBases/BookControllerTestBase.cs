using BusinessLogic.Services.Interfaces;
using Moq;
using NUnit.Framework;
using StructureMap.AutoMocking;
using UI.Controllers;

namespace UnitTests.UI.Controllers.TestBases
{
	public class BookControllerTestBase : ControllerTestBase
	{
		protected RhinoAutoMocker<BookController> _controller;
		protected Mock<IBookService> _service;

		[SetUp]
		public virtual void SetUp()
		{
			_service = new Mock<IBookService>();
			_controller = new RhinoAutoMocker<BookController>();
			_controller.Inject(_service.Object);
			_controller.ClassUnderTest.ControllerContext = SetupAuthorization("Admin", true, true).Object;
			_session["BookResult"] = null;
			_session["query"] = string.Empty;
			_session["wish"] = string.Empty;
		}
	}
}