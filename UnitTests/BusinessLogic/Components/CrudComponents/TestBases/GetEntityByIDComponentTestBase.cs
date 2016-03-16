using BusinessLogic.Components.CrudComponents;
using BusinessLogic.Models;
using BusinessLogic.Repositories;
using Moq;
using NUnit.Framework;

namespace UnitTests.BusinessLogic.Components.CrudComponents.TestBases
{
    public class GetEntityByIDComponentTestBase
    {
        protected GetEntityByIDComponent _getEntityByIDComponent;
        protected IRepository<RecordModel> _recordRepo;
        protected Mock<IRepository<RecordModel>> _recordRepositoryMock;

        [SetUp]
        public virtual void Setup()
        {
            _getEntityByIDComponent = new GetEntityByIDComponent();
            _recordRepositoryMock = new Mock<IRepository<RecordModel>>();
        }
    }
}