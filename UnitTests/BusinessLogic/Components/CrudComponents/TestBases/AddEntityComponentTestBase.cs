﻿using BusinessLogic.Components.CrudComponents;
using BusinessLogic.Repositories;
using Moq;
using NUnit.Framework;

namespace UnitTests.BusinessLogic.Components.CrudComponents.TestBases
{
    [TestFixture]
    public class AddEntityComponentTestBase
    {
        protected AddEntityComponent _addEntityComponent;
        protected IRepository<string> _testRepo;
        protected Mock<IRepository<string>> _testRepositoryMock;

        [SetUp]
        public virtual void Setup()
        {
            _addEntityComponent = new AddEntityComponent();
            _testRepositoryMock = new Mock<IRepository<string>>();
        }
    }
}