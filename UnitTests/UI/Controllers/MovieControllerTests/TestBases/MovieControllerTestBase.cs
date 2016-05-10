using Moq;
using NUnit.Framework;
using UI.Controllers;

namespace UnitTests.UI.Controllers.MovieControllerTests.TestBases
{
	public class MovieControllerTestBase
	{
		protected Mock<MovieController> _controller;

		[SetUp]
		public virtual void SetUp()
		{
			_controller = new Mock<MovieController>();
		}
	}
}