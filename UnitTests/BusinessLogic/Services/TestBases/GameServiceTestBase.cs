using BusinessLogic.Models;
using BusinessLogic.Repositories;
using BusinessLogic.Services;
using Moq;
using NUnit.Framework;

namespace UnitTests.BusinessLogic.Services.TestBases
{
	public class GameServiceTestBase
	{
		protected Mock<GameService> _service;
		protected Mock<IUnitOfWork> _uow;
		protected Mock<IRepository<Game>> _repo;

		[SetUp]
		protected virtual void SetUp()
		{
			_uow = new Mock<IUnitOfWork>();
			_service = new Mock<GameService>(_uow.Object);
			_repo = new Mock<IRepository<Game>>();
			_uow.Setup(mock => mock.GetRepository<Game>()).Returns(_repo.Object);
		}
	}
}