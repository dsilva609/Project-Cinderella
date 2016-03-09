using BusinessLogic.Components.CrudComponents;
using NUnit.Framework;

//using BusinessLogic.Models;

namespace UnitTests.BusinessLogic.Components.CrudComponents.TestBases
{
	[TestFixture]
	public class AddEntityComponentTestBase
	{
		//protected IRepository<Card> _cardRepo;
		//protected IRepository<Player> _playerRepo;
		protected AddEntityComponent _addEntityComponent;

		//protected Mock<IRepository<Card>> _cardRepositoryMock;
		//protected Mock<IRepository<Player>> _playerRepositoryMock;

		[SetUp]
		public virtual void Setup()
		{
			this._addEntityComponent = new AddEntityComponent();
			//this._cardRepositoryMock = new Mock<IRepository<Card>>();
			//this._playerRepositoryMock = new Mock<IRepository<Player>>();
		}
	}
}