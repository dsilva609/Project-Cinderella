using NUnit.Framework;
using UnitTests.BusinessLogic.Components.CrudComponents.TestBases;

namespace UnitTests.BusinessLogic.Components.CrudComponents
{
	[TestFixture]
	public class EditEntityComponentTests : EditEntityComponentTestBase
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
		//public void ThatCardNameIsChanged()
		//{
		//	//--Arrange
		//	base._cardRepositoryMock.Setup(m => m.Add(this._card));
		//	base._cardRepo = this._cardRepositoryMock.Object;
		//	this._card.Name = "Indians!";

		//	//--Act
		//	base._editEntityComponent.Execute(base._cardRepo, this._card);

		//	//--Assert
		//	base._cardRepositoryMock.Verify(m => m.Edit(It.Is<Card>(c => c.Name == "Indians!")));
		//}

		//[TestMethod]
		//public void TestThatPlayerNameIsChanged()
		//{
		//	//--Arrange
		//	base._playerRepositoryMock.Setup(m => m.Add(this._player));
		//	base._playerRepo = base._playerRepositoryMock.Object;
		//	this._player.Name = "Liam Neeson";

		//	//--Act
		//	base._editEntityComponent.Execute(base._playerRepo, this._player);

		//	//--Assert
		//	base._playerRepositoryMock.Verify(m => m.Edit(It.Is<Player>(p => p.Name == "Liam Neeson")));
		//}
	}
}