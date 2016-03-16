﻿using BusinessLogic.Models;
using NUnit.Framework;
using UnitTests.BusinessLogic.Components.CrudComponents.TestBases;

namespace UnitTests.BusinessLogic.Components.CrudComponents
{
    [TestFixture]
    public class GetEntityByIDComponentTests : GetEntityByIDComponentTestBase
    {
        private RecordModel _record;

        [SetUp]
        public override void Setup()
        {
            base.Setup();

            _record = new RecordModel
            {
                ID = 666,
                AlbumName = "Born To Die",
                Artist = "Lana del Rey"
            };
        }

        [Test]
        public void ThatRecordOfMatchingIDIsReturned()
        {
            //--Arrange
            _recordRepositoryMock.Setup(m => m.GetByID(666)).Returns(_record);
            _recordRepo = _recordRepositoryMock.Object;

            //--Act
            var result = _getEntityByIDComponent.Execute(_recordRepo, 666);

            //--Assert
            Assert.AreEqual(666, result.ID);
        }
    }
}