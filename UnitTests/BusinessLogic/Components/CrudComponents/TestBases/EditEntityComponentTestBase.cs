using BusinessLogic.Components.CrudComponents;
using BusinessLogic.Models;
using BusinessLogic.Repositories;
using Moq;
using NUnit.Framework;

namespace UnitTests.BusinessLogic.Components.CrudComponents.TestBases
{
    public class EditEntityComponentTestBase
    {
        protected EditEntityComponent _editEntityComponent;
        protected IRepository<Album> _recordRepo;
        protected Mock<IRepository<Album>> _recordRepositoryMock;

        [SetUp]
        public virtual void Setup()
        {
            _editEntityComponent = new EditEntityComponent();
            _recordRepositoryMock = new Mock<IRepository<Album>>();
        }
    }
}