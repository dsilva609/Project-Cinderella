using BusinessLogic.Models;
using NUnit.Framework;
using UnitTests.BusinessLogic.Components.CrudComponents.TestBases;

namespace UnitTests.BusinessLogic.Components.CrudComponents
{
    [TestFixture]
    public class DeleteEntityComponentTests : DeleteEntityComponentTestBase
    {
        private RecordModel _testModel;

        [SetUp]
        public override void Setup()
        {
            base.Setup();

            _testModel = new RecordModel
            {
                ID = 666,
                AlbumName = "Toxicity",
                Artist = "System of a Down"
            };
        }

        [Test]
        public void ThatRecordIsRemovedFromTheRepository()
        {
            //--Arrange
            _testRepositoryMock.Setup(m => m.Add(_testModel));
            _testRepo = _testRepositoryMock.Object;

            //--Act
            _deleteEntityComponent.Execute(_testRepo, _testModel.ID, string.Empty);
            var result = _testRepo.GetByID(666, string.Empty);

            //--Assert
            Assert.IsNull(result);
        }
    }
}