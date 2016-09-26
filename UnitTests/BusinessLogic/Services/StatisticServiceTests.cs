using NUnit.Framework;
using Shouldly;
using UnitTests.BusinessLogic.Services.TestBases;

namespace UnitTests.BusinessLogic.Services
{
    public class StatisticServiceTests : StatisticServiceTestBase
    {
        [Test]
        public void ThatItReturnsGlobalCollectionCount()
        {
            0.ShouldBe(1);
        }
    }
}