using NUnit.Framework;
using System.Web.Mvc;
using UnitTests.UI.Controllers.TestBases;

namespace UnitTests.UI.Controllers
{
	public class QueueControllerTests : QueueControllerTestBase
	{
		[Test]
		public void ThatTheIndexActionReturnsAView()
		{
			var result = _controller.ClassUnderTest.Index() as ViewResult;

			Assert.AreEqual(string.Empty, result.ViewName);
		}
	}
}