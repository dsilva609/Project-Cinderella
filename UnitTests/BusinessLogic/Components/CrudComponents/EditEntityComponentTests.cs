using BusinessLogic.Models;
using Moq;
using NUnit.Framework;
using UnitTests.BusinessLogic.Components.CrudComponents.TestBases;

namespace UnitTests.BusinessLogic.Components.CrudComponents
{
    [TestFixture]
    public class EditEntityComponentTests : EditEntityComponentTestBase
    {
        private RecordModel _record;

        [SetUp]
        public override void Setup()
        {
            base.Setup();

            _record = new RecordModel
            {
                ID = 666,
                AlbumName = "Hypnotize",
                Artist = "System of a Down"
            };
        }

        [Test]
        public void ThatRecordNameIsChanged()
        {
            //--Arrange
            _recordRepositoryMock.Setup(m => m.Add(_record));
            _recordRepo = _recordRepositoryMock.Object;
            _record.AlbumName = "Mezmerize";

            //--Act
            _editEntityComponent.Execute(_recordRepo, _record);

            //--Assert
            _recordRepositoryMock.Verify(m => m.Edit(It.Is<RecordModel>(c => c.AlbumName == "Mezmerize")));
        }
    }
}