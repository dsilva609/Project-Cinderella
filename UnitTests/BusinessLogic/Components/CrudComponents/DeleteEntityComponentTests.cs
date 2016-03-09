using NUnit.Framework;
using UnitTests.BusinessLogic.Components.CrudComponents.TestBases;

namespace UnitTests.BusinessLogic.Components.CrudComponents
{
	[TestFixture]
	public class DeleteEntityComponentTests : DeleteEntityComponentTestBase
	{
		//private Card _card;
		//private Player _player;

		//[TestInitialize]
		//public override void Setup()
		//{
		//	base.Setup();

		//	this._card = new Card
		//	{
		//		Name = "Bang!",
		//		ID = 1,
		//		Description = "Kill 'Em All",
		//		Rank = Rank.Eight,
		//		IsActive = true
		//	};

		//	this._player = new Player
		//	{
		//		ID = 1,
		//		Name = "Smitty Werbenjagermanjensen",
		//		IsActive = true
		//	};
		//}

		//[TestMethod]
		//public void ThatCardIsRemovedFromTheRepository()
		//{
		//	//--Arrange
		//	base._cardRepositoryMock.Setup(m => m.Add(this._card));
		//	base._cardRepo = base._cardRepositoryMock.Object;

		//	//--Act
		//	base._deleteEntityComponent.Execute(base._cardRepo, this._card.ID);
		//	var result = this._cardRepo.GetByID(this._card.ID);

		//	//--Assert
		//	Assert.IsNull(result);
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