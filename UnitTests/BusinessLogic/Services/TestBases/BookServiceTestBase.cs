using BusinessLogic.Models;
using BusinessLogic.Repositories;
using BusinessLogic.Services;
using Moq;
using NUnit.Framework;

namespace UnitTests.BusinessLogic.Services.TestBases
{
	public class BookServiceTestBase
	{
		protected Mock<BookService> _service;
		protected Mock<IUnitOfWork> _uow;
		protected Mock<IRepository<Book>> _repo;

		[SetUp]
		protected virtual void SetUp()
		{
			_uow = new Mock<IUnitOfWork>();
			_service = new Mock<BookService>(_uow.Object);
			_repo = new Mock<IRepository<Book>>();
			_uow.Setup(mock => mock.GetRepository<Book>()).Returns(_repo.Object);
		}
	}
}