using Moq;
using NUnit.Framework;
using UI.Controllers;

namespace UnitTests.UI.Controllers.GameControllerTests.TestBases
{
	public class GameControllerTestBase
	{
		protected Mock<GameController> _controller;

		[SetUp]
		public virtual void SetUp()
		{
			_controller = new Mock<GameController>();
		}
	}
}