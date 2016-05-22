﻿using BusinessLogic.Models;
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
		protected Mock<IRepository<RecordModel>> _repo;

		[SetUp]
		protected virtual void SetUp()
		{
			_uow = new Mock<IUnitOfWork>();
			_service = new Mock<AlbumService>(_uow.Object);
			_repo = new Mock<IRepository<RecordModel>>();
			_uow.Setup(mock => mock.GetRepository<RecordModel>()).Returns(_repo.Object);
		}
	}
}