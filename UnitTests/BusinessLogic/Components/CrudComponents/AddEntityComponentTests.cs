using NUnit.Framework;
using UnitTests.BusinessLogic.Components.CrudComponents.TestBases;

namespace UnitTests.BusinessLogic.Components.CrudComponents
{
	[TestFixture]
	public class AddEntityComponentTests : AddEntityComponentTestBase
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
		//public void ThatANewCardIsAddedToTheRepository()
		//{
		//	//--Arrange
		//	base.Setup();
		//	base._cardRepositoryMock.Setup(m => m.Add(this._card));
		//	base._cardRepo = base._cardRepositoryMock.Object;

		//	//--Act
		//	base._addEntityComponent.Execute(base._cardRepo, this._card);

		//	//--Assert
		//	base._cardRepositoryMock.Verify(m => m.Add(It.Is<Card>(c => c.ID == this._card.ID && c.Name == this._card.Name && c.IsActive == this._card.IsActive)));
		//}

		//[TestMethod]
		//public void ThatNewPlayerIsAddedToTheRepository()
		//{
		//	//--Arrange
		//	base._playerRepositoryMock.Setup(m => m.Add(this._player));
		//	base._playerRepo = base._playerRepositoryMock.Object;

		//	//--Act
		//	base._addEntityComponent.Execute(base._playerRepo, this._player);

		//	//--Assert
		//	base._playerRepositoryMock.Verify(m => m.Add(It.Is<Player>(p => p.ID == this._player.ID && p.Name == this._player.Name && p.IsActive == this._player.IsActive)));
		//}
	}
}