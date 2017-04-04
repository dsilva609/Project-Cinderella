using NUnit.Framework;
using Shouldly;
using UnitTests.BusinessLogic.Services.TestBases;

namespace UnitTests.BusinessLogic.Services
{
    public class BookStatisticServiceTests : BookStatisticServiceTestBase
    {
        [Test]
        public void ItGetsNumNovels() => _service.ClassUnderTest.NumNovel().ShouldBe(1);
    }
}