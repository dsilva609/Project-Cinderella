using NUnit.Framework;
using UnitTests.BusinessLogic.Components.CrudComponents.TestBases;

namespace UnitTests.BusinessLogic.Components.CrudComponents
{
    [TestFixture]
    public class DeleteEntityComponentTests : DeleteEntityComponentTestBase
    {
        private int _num;

        [SetUp]
        public override void Setup()
        {
            base.Setup();

            this._num = 27;
        }

        //[Test]
        //public void ThatCardIsRemovedFromTheRepository()
        //{
        //    //--Arrange
        //    base._testRepositoryMock.Setup(m => m.Add(this._num));
        //    base._testRepo = base._testRepositoryMock.Object;

        //    //--Act
        //    base._deleteEntityComponent.Execute(base._testRepo, 27);
        //    var result = this._testRepo.GetByID(this._num);

        //    //--Assert
        //    Assert.IsNull(result);
        //}

        //[TestMethod]
        //public void ThatPlayerIsRemovedFromTheRepository()
        //{
        //	//--Arrange
        //	base._playerRepositoryMock.Setup(m => m.Add(this._player));
        //	base._playerRepo = base._playerRepositoryMock.Object;

        //	//--Act
        //	base._deleteEntityComponent.Execute(base._playerRepo, this._player.ID);
        //	var result = base._playerRepo.GetByID(this._player.ID);

        //	//--Assert
        //	Assert.IsNull(result);
        //}
    }
}