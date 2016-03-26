using BusinessLogic.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnitTests.BusinessLogic.Services.TestBases;

namespace UnitTests.BusinessLogic.Services
{
	[TestFixture]
	public class RecordServiceTests : RecordServiceTestBase
	{
		private RecordModel _testModel1 = new RecordModel
		{
			ID = 1984,
			Artist = "Dio",
			AlbumName = "The Last In Line"
		};

		private RecordModel _testModel2 = new RecordModel
		{
			ID = 1983,
			Artist = "Dio",
			AlbumName = "Holy Diver"
		};

		[Test]
		public void ItAddsRecords()
		{
			//--Arrange
			_repo.Setup(mock => mock.GetAll()).Returns(new List<RecordModel>());

			//--Act
			_service.Object.Add(_testModel1);

			//--Assert
			_repo.Verify(mock => mock.Add(It.Is<RecordModel>(x => x.Equals(_testModel1))), Times.Once);
		}

		[Test]
		public void ItThrowsAnExceptionWhenTryingToAddADuplicateRecord()
		{
			//--Arrange
			_repo.Setup(mock => mock.GetAll()).Returns(new List<RecordModel>
			{
				_testModel1
			});

			//--Act/Assert
			Assert.Throws<ApplicationException>(() => _service.Object.Add(_testModel1));
		}

		[Test]
		public void ItDeletesRecords()
		{
			//--Arrange
			_repo.Setup(mock => mock.Add(_testModel2));

			//--Act
			_service.Object.Delete(_testModel2.ID);
			var result = _service.Object.GetByID(_testModel2.ID);

			//--Assert
			Assert.IsNull(result);
		}

		[Test]
		public void ItUpdatesRecords()
		{
			//--Act
			_service.Object.Edit(_testModel2.ID, _testModel2);

			//--Assert
			_repo.Verify(mock => mock.Edit(It.Is<RecordModel>(x => x.Equals(_testModel2))));
		}
	}
}