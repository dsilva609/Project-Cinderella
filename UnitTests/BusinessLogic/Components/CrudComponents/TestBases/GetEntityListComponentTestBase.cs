using BusinessLogic.Components.CrudComponents;
using BusinessLogic.Models;
using BusinessLogic.Repositories;
using Moq;
using NUnit.Framework;

namespace UnitTests.BusinessLogic.Components.CrudComponents.TestBases
{
    public class GetEntityListComponentTestBase
    {
        protected GetEntityListComponent _getEntityListComponent;
        protected IRepository<RecordModel> _recordRepo;
        protected Mock<IRepository<RecordModel>> _recordRepositoryMock;

        [SetUp]
        public virtual void Setup()
        {
            _getEntityListComponent = new GetEntityListComponent();
            _recordRepositoryMock = new Mock<IRepository<RecordModel>>();
        }
    }
}