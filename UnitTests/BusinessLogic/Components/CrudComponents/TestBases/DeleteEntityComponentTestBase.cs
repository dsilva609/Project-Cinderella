using BusinessLogic.Components.CrudComponents;
using NUnit.Framework;

namespace UnitTests.BusinessLogic.Components.CrudComponents.TestBases
{
	[TestFixture]
	public class DeleteEntityComponentTestBase
	{
		//protected IRepository<Card> _cardRepo;
		//protected IRepository<Player> _playerRepo;
		protected DeleteEntityComponent _deleteEntityComponent;

		//protected Mock<IRepository<Card>> _cardRepositoryMock;
		//protected Mock<IRepository<Player>> _playerRepositoryMock;

		[SetUp]
		public virtual void Setup()
		{
			this._deleteEntityComponent = new DeleteEntityComponent();
			//this._cardRepositoryMock = new Mock<IRepository<Card>>();
			//this._playerRepositoryMock = new Mock<IRepository<Player>>();
		}
	}
}