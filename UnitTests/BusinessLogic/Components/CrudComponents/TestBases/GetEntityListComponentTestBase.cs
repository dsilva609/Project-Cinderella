using BusinessLogic.Components.CrudComponents;
using NUnit.Framework;

namespace UnitTests.BusinessLogic.Components.CrudComponents.TestBases
{
	[TestFixture]
	public class GetEntityListComponentTestBase
	{
		//protected IRepository<Card> _cardRepo;
		//protected IRepository<Player> _playerRepo;
		protected GetEntityListComponent _getEntityListComponent;

		//protected Mock<IRepository<Card>> _cardRepositoryMock;
		//protected Mock<IRepository<Player>> _playerRepositoryMock;

		[SetUp]
		public virtual void Setup()
		{
			this._getEntityListComponent = new GetEntityListComponent();
			//this._cardRepositoryMock = new Mock<IRepository<Card>>();
			//this._playerRepositoryMock = new Mock<IRepository<Player>>();
		}
	}
}