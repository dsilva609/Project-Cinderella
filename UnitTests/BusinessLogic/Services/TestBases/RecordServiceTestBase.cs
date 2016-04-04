using BusinessLogic.Models;
using BusinessLogic.Repositories;
using BusinessLogic.Services;
using Moq;
using NUnit.Framework;

namespace UnitTests.BusinessLogic.Services.TestBases
{
    public class RecordServiceTestBase
    {
        protected Mock<RecordService> _service;
        protected Mock<IUnitOfWork> _uow;
        protected Mock<IRepository<RecordModel>> _repo;

        [SetUp]
        protected virtual void SetUp()
        {
            _uow = new Mock<IUnitOfWork>();
            _service = new Mock<RecordService>(_uow.Object);
            _repo = new Mock<IRepository<RecordModel>>();
            _uow.Setup(mock => mock.GetRepository<RecordModel>()).Returns(_repo.Object);
        }
    }
}