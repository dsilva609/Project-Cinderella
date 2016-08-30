using BusinessLogic.Models;
using BusinessLogic.Repositories;
using BusinessLogic.Services;
using Moq;
using NUnit.Framework;

namespace UnitTests.BusinessLogic.Services.TestBases
{
	public class MovieServiceTestBase
	{
		protected Mock<MovieService> _service;
		protected Mock<IUnitOfWork> _uow;
		protected Mock<IRepository<Movie>> _repo;

		[SetUp]
		protected virtual void SetUp()
		{
			_uow = new Mock<IUnitOfWork>();
			_service = new Mock<MovieService>(_uow.Object);
			_repo = new Mock<IRepository<Movie>>();
			_uow.Setup(mock => mock.GetRepository<Movie>()).Returns(_repo.Object);
		}
	}
}