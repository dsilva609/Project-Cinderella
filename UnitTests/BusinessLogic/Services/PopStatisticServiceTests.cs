using NUnit.Framework;
using NUnit.Framework.Internal;
using Shouldly;
using System.Linq;
using UnitTests.BusinessLogic.Services.TestBases;

namespace UnitTests.BusinessLogic.Services
{
    [TestFixture]
    public class PopStatisticServiceTests : PopStatisticServiceTestBase
    {
        [Test]
        public void ItGetsTopSeries() => _service.ClassUnderTest.TopSeries().FirstOrDefault().ShouldBe("DC");

        [Test]
        public void ItGetsTopLines() => _service.ClassUnderTest.TopLines().FirstOrDefault().ShouldBe("Pop");

        [Test]
        public void ItGetsTopCountriesOfOrigin() => _service.ClassUnderTest.TopCountriesOfOrigin().FirstOrDefault().ShouldBe("US");

        [Test]
        public void ItGetsTopPurchaseCountries() => _service.ClassUnderTest.TopPurchaseCountries().FirstOrDefault().ShouldBe("US");

        [Test]
        public void ItGetsTopLocationsPurchased() => _service.ClassUnderTest.TopLocationsPurchased().FirstOrDefault().ShouldBe("Amazon");

        [Test]
        public void ItGetsTopReleaseYears() => _service.ClassUnderTest.TopReleaseYears().FirstOrDefault().ShouldBe(2017);
    }
}