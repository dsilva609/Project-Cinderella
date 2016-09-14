using NUnit.Framework;
using Shouldly;
using UnitTests.BusinessLogic.Services.TestBases;

namespace UnitTests.BusinessLogic.Services
{
    [TestFixture]
    public class GoogleBookServiceTests : GoogleBookServiceTestBase
    {
        [Test]
        public void ThatSearchReturnsResults()
        {
            var result = _service.Search(string.Empty, "Wonder Woman");

            result.Count.ShouldBeGreaterThan(0);
        }

        [Test]
        public void ThatSearchByIDReturnsAResult()
        {
            var result = _service.SearchByID("nhe2BQAAQBAJ");

            result.ShouldNotBeNull();
        }
    }
}