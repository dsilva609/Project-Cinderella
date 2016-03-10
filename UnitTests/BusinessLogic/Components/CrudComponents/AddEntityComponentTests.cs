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
        public void ThatANewStringIsAddedToTheRepository()
        {
            //--Arrange
            _str = "Smitty Werbenjagermanjensen";
            base._testRepositoryMock.Setup(m => m.Add(this._str));
            base._testRepo = base._testRepositoryMock.Object;

            //--Act
            base._addEntityComponent.Execute(base._testRepo, this._str);

            //--Assert
            base._testRepositoryMock.Verify(m => m.Add(It.Is<string>(s => s == this._str)));
        }
    }
}