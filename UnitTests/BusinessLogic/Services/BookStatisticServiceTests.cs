using NUnit.Framework;
using Shouldly;
using System.Linq;
using UnitTests.BusinessLogic.Services.TestBases;

namespace UnitTests.BusinessLogic.Services
{
    public class BookStatisticServiceTests : BookStatisticServiceTestBase
    {
        [Test]
        public void ItGetsNumNovels() => _service.ClassUnderTest.NumNovel().ShouldBe(1);

        [Test]
        public void ItGetsNumComics() => _service.ClassUnderTest.NumComic().ShouldBe(1);

        [Test]
        public void ItGetsNumManga() => _service.ClassUnderTest.NumManga().ShouldBe(1);

        [Test]
        public void ItGetsNumHardCover() => _service.ClassUnderTest.NumHardcover().ShouldBe(2);

        [Test]
        public void ItGetsNumFirstEdition() => _service.ClassUnderTest.NumFirstEdition().ShouldBe(1);

        [Test]
        public void ItGetsTotalPageCount() => _service.ClassUnderTest.TotalPageCount().ShouldBe(30);

        [Test]
        public void ItGetsTopPublishers() => _service.ClassUnderTest.TopPublishers().FirstOrDefault().ShouldBe("DC");

        [Test]
        public void ItGetsTopCountriesOfOrigin() => _service.ClassUnderTest.TopCountriesOfOrigin().FirstOrDefault().ShouldBe("US");

        [Test]
        public void ItGetsTopPurchaseCountries() => _service.ClassUnderTest.TopPurchaseCountries().FirstOrDefault().ShouldBe("US");

        [Test]
        public void ItGetsTopLocationsPurchased() => _service.ClassUnderTest.TopLocationsPurchased().FirstOrDefault().ShouldBe("North Coast");

        [Test]
        public void ItGetsMostCompleted() => _service.ClassUnderTest.MostCompleted().FirstOrDefault().ShouldBe("The Notebook");

        [Test]
        public void ItGetsTopReleaseYears() => _service.ClassUnderTest.TopReleaseYears().FirstOrDefault().ShouldBe(2017);
    }
}