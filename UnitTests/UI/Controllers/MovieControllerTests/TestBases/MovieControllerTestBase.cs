using BusinessLogic.Services.Interfaces;
using Moq;
using NUnit.Framework;
using UI.Controllers;

namespace UnitTests.UI.Controllers.MovieControllerTests.TestBases
{
	public class MovieControllerTestBase
	{
		protected Mock<MovieController> _controller;
		protected IMovieService _service;

		[SetUp]
		public virtual void SetUp()
		{
			_service = Mock.Of<IMovieService>();
			_controller = new Mock<MovieController>(_service);
		}
	}
}