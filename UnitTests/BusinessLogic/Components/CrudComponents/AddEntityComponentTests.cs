using BusinessLogic.Models;
using Moq;
using NUnit.Framework;
using UnitTests.BusinessLogic.Components.CrudComponents.TestBases;

namespace UnitTests.BusinessLogic.Components.CrudComponents
{
    [TestFixture]
    public class AddEntityComponentTests : AddEntityComponentTestBase
    {
        private Album _record;

        [Test]
        public void ThatANewRecordIsAddedToTheRepository()
        {
            //--Arrange
            _record = new Album { Artist = "Smitty Werbenjagermanjensen" };
            _testRepositoryMock.Setup(m => m.Add(_record));
            _testRepo = _testRepositoryMock.Object;

            //--Act
            _addEntityComponent.Execute(_testRepo, _record);

            //--Assert
            _testRepositoryMock.Verify(m => m.Add(It.Is<Album>(s => s == _record)));
        }
    }
}