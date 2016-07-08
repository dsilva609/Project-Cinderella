using BusinessLogic.Services.Interfaces;
using Moq;
using NUnit.Framework;
using UI.Controllers;

namespace UnitTests.UI.Controllers.TestBases
{
	public class GameControllerTestBase
	{
		protected Mock<GameController> _controller;
		protected IGameService _service;

		[SetUp]
		public virtual void SetUp()
		{
			_service = Mock.Of<IGameService>();
			_controller = new Mock<GameController>(_service);
		}
	}
}