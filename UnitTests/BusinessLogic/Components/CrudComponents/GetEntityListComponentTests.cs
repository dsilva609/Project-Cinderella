using NUnit.Framework;
using UnitTests.BusinessLogic.Components.CrudComponents.TestBases;

namespace UnitTests.BusinessLogic.Components.CrudComponents
{
	[TestFixture]
	public class GetEntityListComponentTests : GetEntityListComponentTestBase
	{
		//[TestMethod]
		//public void ThatRepositoryReturnsAllCards()
		//{
		//	//--Arrange
		//	base._cardRepositoryMock.Setup(m => m.GetAll()).Returns(new List<Card>
		//	{
		//		new Card
		//		{
		//			Name = "Bang!",
		//			ID = 1,
		//			Description = "Kill 'Em All",
		//			Rank = Rank.Eight,
		//			IsActive = true
		//		},

		//		new Card
		//		{
		//			Name = "Missed!",
		//			ID = 2,
		//			Description = "Missed me Fool",
		//			Rank = Rank.Eight,
		//			IsActive = true
		//		},

		//		new Card
		//		{
		//			Name = "Beer!",
		//			ID = 3,
		//			Description = "Drink up",
		//			Rank = Rank.Eight,
		//			IsActive = true
		//		}
		//	});
		//	base._cardRepo = base._cardRepositoryMock.Object;

		//	//--Act
		//	var result = base._getEntityListComponent.Execute(base._cardRepo);

		//	//--Assert
		//	Assert.AreEqual(3, result.Count);
		//}

		//[TestMethod]
		//public void ThatRepositoryReturnsAllPlayers()
		//{
		//	//--Arrange
		//	base._playerRepositoryMock.Setup(m => m.GetAll()).Returns(new List<Player> {
		//		new Player
		//		{
		//			ID = 1,
		//			Name = "Smitty Werbenjagermanjensen",
		//			IsActive = true
		//		},

		//		new Player
		//		{
		//			Name = "Walter White",
		//			ID = 2,
		//			IsActive = true
		//		},

		//		new Player
		//		{
		//			Name = "Tom Neville",
		//			ID = 3,
		//			IsActive = true
		//		}
		//	});
		//	base._playerRepo = base._playerRepositoryMock.Object;

		//	//--Act
		//	var result = base._getEntityListComponent.Execute(base._playerRepo);

		//	//--Assert
		//	Assert.AreEqual(3, result.Count);
		//}
	}
}