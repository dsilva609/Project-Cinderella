using BusinessLogic.Components.CrudComponents;
using BusinessLogic.Models;
using BusinessLogic.Repositories;
using Moq;
using NUnit.Framework;

namespace UnitTests.BusinessLogic.Components.CrudComponents.TestBases
{
    public class AddEntityComponentTestBase
    {
        protected AddEntityComponent _addEntityComponent;
        protected IRepository<Album> _testRepo;
        protected Mock<IRepository<Album>> _testRepositoryMock;

        [SetUp]
        public virtual void Setup()
        {
            _addEntityComponent = new AddEntityComponent();
            _testRepositoryMock = new Mock<IRepository<Album>>();
        }
    }
}