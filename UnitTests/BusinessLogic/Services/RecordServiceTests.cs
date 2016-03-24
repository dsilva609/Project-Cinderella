using BusinessLogic.Models;
using Moq;
using NUnit.Framework;
using UnitTests.BusinessLogic.Services.TestBases;

namespace UnitTests.BusinessLogic.Services
{
    [TestFixture]
    public class RecordServiceTests : RecordServiceTestBase
    {
        private RecordModel _testModel1 = new RecordModel
        {
            ID = 1984,
            Artist = "Dio",
            AlbumName = "The Last In Line"
        };

        private RecordModel _testModel2 = new RecordModel
        {
            ID = 1983,
            Artist = "Dio",
            AlbumName = "Holy Diver"
        };

        [Test]
        public void ItAddsRecords()
        {
            //--Act
            _service.Object.Add(_testModel1);

            //--Assert
            _repo.Verify(mock => mock.Add(It.Is<RecordModel>(x => x.Equals(_testModel1))), Times.Once);
        }
    }
}