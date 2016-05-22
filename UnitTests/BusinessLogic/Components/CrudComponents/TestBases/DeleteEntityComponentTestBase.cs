using BusinessLogic.Components.CrudComponents;
using BusinessLogic.Models;
using BusinessLogic.Repositories;
using Moq;
using NUnit.Framework;

namespace UnitTests.BusinessLogic.Components.CrudComponents.TestBases
{
    public class DeleteEntityComponentTestBase
    {
        protected DeleteEntityComponent _deleteEntityComponent;
        protected IRepository<Album> _testRepo;
        protected Mock<IRepository<Album>> _testRepositoryMock;

        [SetUp]
        public virtual void Setup()
        {
            _deleteEntityComponent = new DeleteEntityComponent();
            _testRepositoryMock = new Mock<IRepository<Album>>();
        }
    }
}