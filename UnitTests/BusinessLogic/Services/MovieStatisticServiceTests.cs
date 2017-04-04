using NUnit.Framework;
using NUnit.Framework.Internal;
using Shouldly;
using System.Linq;
using UnitTests.BusinessLogic.Services.TestBases;

namespace UnitTests.BusinessLogic.Services
{
    [TestFixture]
    public class MovieStatisticServiceTests : MovieStatisticServiceTestBase
    {
        [Test]
        public void ItGetsTopDirectors() => _service.ClassUnderTest.TopDirectors().FirstOrDefault().ShouldBe("Joss Whedon");

        [Test]
        public void ItGetsNumDVD() => _service.ClassUnderTest.NumDVD().ShouldBe(1);

        [Test]
        public void ItGetsNumBluRay() => _service.ClassUnderTest.NumBluRay().ShouldBe(2);

        [Test]
        public void ItGetsNumRatedG() => _service.ClassUnderTest.NumRatedG().ShouldBe(0);

        [Test]
        public void ItGetsNumRatedPG() => _service.ClassUnderTest.NumRatedPG().ShouldBe(1);

        [Test]
        public void ItGetsNumRatedPG13() => _service.ClassUnderTest.NumRatedPG13().ShouldBe(1);

        [Test]
        public void ItGetsNumRatedR() => _service.ClassUnderTest.NumRatedR().ShouldBe(1);

        [Test]
        public void ItGetsNumRatedNR() => _service.ClassUnderTest.NumRatedNR().ShouldBe(0);

        [Test]
        public void ItGetsTopCountriesOfOrigin() => _service.ClassUnderTest.TopCountriesOfOrigin().FirstOrDefault().ShouldBe("US");

        [Test]
        public void ItGetsTopPurchaseCountries() => _service.ClassUnderTest.TopPurchaseCountries().FirstOrDefault().ShouldBe("US");

        [Test]
        public void ItGetsMostCompleted() => _service.ClassUnderTest.MostCompleted().FirstOrDefault().ShouldBe("Avengers");

        [Test]
        public void ItGetsTopLocationsPurchased() => _service.ClassUnderTest.TopLocationsPurchased().FirstOrDefault().ShouldBe("Ebay");

        [Test]
        public void ItGetsTopReleaseYears() => _service.ClassUnderTest.TopReleaseYears().FirstOrDefault().ShouldBe(2017);
    }
}