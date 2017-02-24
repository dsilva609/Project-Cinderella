using BusinessLogic.Models;
using BusinessLogic.Repositories;
using BusinessLogic.Services;
using Moq;
using NUnit.Framework;

namespace UnitTests.BusinessLogic.Services.TestBases
{
    public class WishServiceTestBase
    {
        protected Mock<WishService> _service;
        protected Mock<IUnitOfWork> _uow;
        protected Mock<IRepository<Wish>> _repo;

        [SetUp]
        protected virtual void SetUp()
        {
            _uow = new Mock<IUnitOfWork>();
            _service = new Mock<WishService>(_uow.Object);
            _repo = new Mock<IRepository<Wish>>();
            _uow.Setup(mock => mock.GetRepository<Wish>()).Returns(_repo.Object);
        }
    }
}