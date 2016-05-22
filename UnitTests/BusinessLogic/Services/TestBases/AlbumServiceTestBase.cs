using BusinessLogic.Models;
using BusinessLogic.Repositories;
using BusinessLogic.Services;
using Moq;
using NUnit.Framework;

namespace UnitTests.BusinessLogic.Services.TestBases
{
	public class AlbumServiceTestBase
	{
		protected Mock<AlbumService> _service;
		protected Mock<IUnitOfWork> _uow;
		protected Mock<IRepository<Album>> _repo;

		[SetUp]
		protected virtual void SetUp()
		{
			_uow = new Mock<IUnitOfWork>();
			_service = new Mock<AlbumService>(_uow.Object);
			_repo = new Mock<IRepository<Album>>();
			_uow.Setup(mock => mock.GetRepository<Album>()).Returns(_repo.Object);
		}
	}
}