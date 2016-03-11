using BusinessLogic.Components.CrudComponents;
using BusinessLogic.Repositories;
using Moq;
using NUnit.Framework;

namespace UnitTests.BusinessLogic.Components.CrudComponents.TestBases
{
    [TestFixture]
    public class DeleteEntityComponentTestBase
    {
        protected DeleteEntityComponent _deleteEntityComponent;
        protected IRepository<int> _testRepo;
        //protected IRepository<Player> _playerRepo;

        protected Mock<IRepository<int>> _testRepositoryMock;
        //protected Mock<IRepository<Player>> _playerRepositoryMock;

        [SetUp]
        public virtual void Setup()
        {
            this._deleteEntityComponent = new DeleteEntityComponent();
            this._testRepositoryMock = new Mock<IRepository<int>>();
            //this._playerRepositoryMock = new Mock<IRepository<Player>>();
        }
    }
}