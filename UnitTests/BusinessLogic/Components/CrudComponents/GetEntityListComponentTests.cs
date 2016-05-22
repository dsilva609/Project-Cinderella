using BusinessLogic.Models;
using NUnit.Framework;
using System.Collections.Generic;
using UnitTests.BusinessLogic.Components.CrudComponents.TestBases;

namespace UnitTests.BusinessLogic.Components.CrudComponents
{
    [TestFixture]
    public class GetEntityListComponentTests : GetEntityListComponentTestBase
    {
        [Test]
        public void ThatRepositoryReturnsAllRecords()
        {
            //--Arrange
            _recordRepositoryMock.Setup(m => m.GetAll()).Returns(new List<Album>
            {
                new Album
                {
                    ID = 1981,
                    AlbumName = "Kill 'em All!",
                    Artist = "Metallica"
                },

                new Album
                {
                    ID = 1984,
                    AlbumName = "Ride The Lightning",
                    Artist = "Metallica"
                },

                new Album
                {
                    ID = 1986,
                    AlbumName = "Master of Puppets",
                    Artist = "Metallica"
                }
            });
            _recordRepo = _recordRepositoryMock.Object;

            //--Act
            var result = _getEntityListComponent.Execute(_recordRepo);

            //--Assert
            Assert.AreEqual(3, result.Count);
        }
    }
}