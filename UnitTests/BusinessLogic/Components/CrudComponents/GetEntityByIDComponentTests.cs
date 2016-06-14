using BusinessLogic.Models;
using NUnit.Framework;
using UnitTests.BusinessLogic.Components.CrudComponents.TestBases;

namespace UnitTests.BusinessLogic.Components.CrudComponents
{
	[TestFixture]
	public class GetEntityByIDComponentTests : GetEntityByIDComponentTestBase
	{
		private Album _record;

		[SetUp]
		public override void Setup()
		{
			base.Setup();

			_record = new Album
			{
				ID = 666,
				Title = "Born To Die",
				Artist = "Lana del Rey"
			};
		}

		[Test]
		public void ThatRecordOfMatchingIDIsReturned()
		{
			//--Arrange
			_recordRepositoryMock.Setup(m => m.GetByID(666, string.Empty)).Returns(_record);
			_recordRepo = _recordRepositoryMock.Object;

			//--Act
			var result = _getEntityByIDComponent.Execute(_recordRepo, 666, string.Empty);

			//--Assert
			Assert.AreEqual(666, result.ID);
		}
	}
}