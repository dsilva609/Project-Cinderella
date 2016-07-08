using Moq;
using NUnit.Framework;
using UI.Controllers;

namespace UnitTests.UI.Controllers.TestBases
{
	[TestFixture]
	public class HomeControllerTestBase
	{
		protected Mock<HomeController> _homeControllerMock;

		[SetUp]
		public void Setup()
		{
			_homeControllerMock = new Mock<HomeController>();
		}
	}
}