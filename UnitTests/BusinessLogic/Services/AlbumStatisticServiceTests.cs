using NUnit.Framework;
using Shouldly;
using System.Linq;
using UnitTests.BusinessLogic.Services.TestBases;

namespace UnitTests.BusinessLogic.Services
{
    [TestFixture]
    public class AlbumStatisticServiceTests : AlbumStatisticServiceTestBase
    {
        [Test]
        public void ItGetsNumVinyl() => _service.ClassUnderTest.NumVinyl().ShouldBe(5);

        [Test]
        public void ItGetsNumCD() => _service.ClassUnderTest.NumCD().ShouldBe(1);

        [Test]
        public void ItGetsNum33RPM() => _service.ClassUnderTest.Num3313RPM().ShouldBe(4);

        [Test]
        public void ItGetsNum45RPM() => _service.ClassUnderTest.Num45RPM().ShouldBe(1);

        [Test]
        public void ItGetsNum78RPM() => _service.ClassUnderTest.Num78RPM().ShouldBe(1);

        [Test]
        public void ItGetsNum12Inch() => _service.ClassUnderTest.Num12Inch().ShouldBe(3);

        [Test]
        public void ItGetsNum10Inch() => _service.ClassUnderTest.Num10Inch().ShouldBe(2);

        [Test]
        public void ItGetsNum7Inch() => _service.ClassUnderTest.Num7Inch().ShouldBe(1);

        [Test]
        public void ItGetsTopArtists() => _service.ClassUnderTest.TopArtists().Count.ShouldBe(3);

        [Test]
        public void ItGetsTopGenres() => _service.ClassUnderTest.TopGenres().ElementAtOrDefault(1).ShouldBe("Rock");

        [Test]
        public void ItGetsTopRecordLabels() => _service.ClassUnderTest.TopRecordLabels().ElementAtOrDefault(1).ShouldBe("Warner");

        [Test]
        public void ItGetsTopCountriesOfOrigin() => _service.ClassUnderTest.TopCountriesOfOrigin().ElementAtOrDefault(1).ShouldBe("US");

        [Test]
        public void ItGetsTopPurchaseCountries() => _service.ClassUnderTest.TopPurchaseCountries().ElementAtOrDefault(1).ShouldBe("US");

        [Test]
        public void ItGetsMostCompleted() => _service.ClassUnderTest.MostCompleted().FirstOrDefault().ShouldBe("The Last In Line");

        [Test]
        public void ItGetsTopLocationsPurchased() => _service.ClassUnderTest.TopLocationsPurchased().ElementAtOrDefault(1).ShouldBe("Rama Lama");

        [Test]
        public void ItGetsTopReleaseYears() => _service.ClassUnderTest.TopReleaseYears().ElementAtOrDefault(1).ShouldBe(1980);
    }
}