using Moq;
using NUnit.Framework;
using UnitTests.BusinessLogic.Components.CrudComponents.TestBases;

namespace UnitTests.BusinessLogic.Components.CrudComponents
{
    [TestFixture]
    public class AddEntityComponentTests : AddEntityComponentTestBase
    {
        private string _str;

        [Test]
        public void ThatANewRecordIsAddedToTheRepository()
        {
            //--Arrange
            _str = "Smitty Werbenjagermanjensen";
            _testRepositoryMock.Setup(m => m.Add(_str));
            _testRepo = _testRepositoryMock.Object;

            //--Act
            _addEntityComponent.Execute(_testRepo, _str);

            //--Assert
            _testRepositoryMock.Verify(m => m.Add(It.Is<string>(s => s == _str)));
        }
    }
}