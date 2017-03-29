using BusinessLogic.Models;
using BusinessLogic.Repositories;
using BusinessLogic.Services;
using Moq;
using NUnit.Framework;

namespace UnitTests.BusinessLogic.Services.TestBases
{
	public class PopServiceTestBase
	{
		protected Mock<PopService> _service;
		protected Mock<IUnitOfWork> _uow { get; set; }
		protected Mock<IRepository<FunkoModel>> _repo;

		[SetUp]
		protected virtual void SetUp()
		{
			_uow = new Mock<IUnitOfWork>();
			_service = new Mock<PopService>(_uow.Object);
			_repo = new Mock<IRepository<FunkoModel>>();
			_uow.Setup(mock => mock.GetRepository<FunkoModel>()).Returns(_repo.Object);
		}
	}
}