using BusinessLogic.Components.CrudComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace UnitTests.BusinessLogic.Components.CrudComponents.TestBases
{
	[TestFixture]
	public class EditEntityComponentTestBase
	{
		//protected IRepository<Card> _cardRepo;
		//protected IRepository<Player> _playerRepo;
		protected EditEntityComponent _editEntityComponent;

		//protected Mock<IRepository<Card>> _cardRepositoryMock;
		//protected Mock<IRepository<Player>> _playerRepositoryMock;

		[SetUp]
		public virtual void Setup()
		{
			this._editEntityComponent = new EditEntityComponent();
			//this._cardRepositoryMock = new Mock<IRepository<Card>>();
			//this._playerRepositoryMock = new Mock<IRepository<Player>>();
		}
	}
}