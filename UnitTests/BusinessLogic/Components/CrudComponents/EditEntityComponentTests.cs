using BusinessLogic.Models;
using Moq;
using NUnit.Framework;
using UnitTests.BusinessLogic.Components.CrudComponents.TestBases;

namespace UnitTests.BusinessLogic.Components.CrudComponents
{
	[TestFixture]
	public class EditEntityComponentTests : EditEntityComponentTestBase
	{
		private Album _record;

		[SetUp]
		public override void Setup()
		{
			base.Setup();

			_record = new Album
			{
				ID = 666,
				Title = "Hypnotize",
				Artist = "System of a Down"
			};
		}

		[Test]
		public void ThatRecordNameIsChanged()
		{
			//--Arrange
			_recordRepositoryMock.Setup(m => m.Add(_record));
			_recordRepo = _recordRepositoryMock.Object;
			_record.Title = "Mezmerize";

			//--Act
			_editEntityComponent.Execute(_recordRepo, _record);

			//--Assert
			_recordRepositoryMock.Verify(m => m.Edit(It.Is<Album>(c => c.Title == "Mezmerize")));
		}
	}
}