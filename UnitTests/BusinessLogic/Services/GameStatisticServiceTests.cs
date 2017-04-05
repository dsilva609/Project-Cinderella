using NUnit.Framework;
using Shouldly;
using System.Linq;
using UnitTests.BusinessLogic.Services.TestBases;

namespace UnitTests.BusinessLogic.Services
{
    [TestFixture]
    public class GameStatisticServiceTests : GameStatisticServiceTestBase
    {
        [Test]
        public void ItGetsNumFullGames() => _service.ClassUnderTest.NumFullGame().ShouldBe(1);

        [Test]
        public void ItGetsNumDLC() => _service.ClassUnderTest.NumDLC().ShouldBe(1);

        [Test]
        public void ItGetsNumExpansions() => _service.ClassUnderTest.NumExpansion().ShouldBe(1);

        [Test]
        public void ItGetsNumRatedEC() => _service.ClassUnderTest.NumRatedEC().ShouldBe(0);

        [Test]
        public void ItGetsNumRatedE() => _service.ClassUnderTest.NumRatedE().ShouldBe(0);

        [Test]
        public void ItGetsNumRatedE10() => _service.ClassUnderTest.NumRatedE10().ShouldBe(1);

        [Test]
        public void ItGetsNumRatedT() => _service.ClassUnderTest.NumRatedT().ShouldBe(1);

        [Test]
        public void ItGetsNumRatedM() => _service.ClassUnderTest.NumRatedM().ShouldBe(1);

        [Test]
        public void ItGetsNumRatedA() => _service.ClassUnderTest.NumRatedA().ShouldBe(0);

        [Test]
        public void ItGetsNumBoardGame() => _service.ClassUnderTest.NumBoardGame().ShouldBe(1);

        [Test]
        public void ItGetsNumPC() => _service.ClassUnderTest.NumPC().ShouldBe(1);

        [Test]
        public void ItGetsNumPlayStation() => _service.ClassUnderTest.NumPlayStation().ShouldBe(0);

        [Test]
        public void ItGetsNumPlayStation2() => _service.ClassUnderTest.NumPlayStation2().ShouldBe(0);

        [Test]
        public void ItGetsNumPlayStation3() => _service.ClassUnderTest.NumPlayStation3().ShouldBe(0);

        [Test]
        public void ItGetsNumPlayStation4() => _service.ClassUnderTest.NumPlayStation4().ShouldBe(1);

        [Test]
        public void ItGetsNumXbox() => _service.ClassUnderTest.NumXbox().ShouldBe(0);

        [Test]
        public void ItGetsNumXbox360() => _service.ClassUnderTest.NumXbox360().ShouldBe(0);

        [Test]
        public void ItGetsNumXboxOne() => _service.ClassUnderTest.NumXboxOne().ShouldBe(0);

        [Test]
        public void ItGetsNumNintendo64() => _service.ClassUnderTest.NumNintendo64().ShouldBe(0);

        [Test]
        public void ItGetsNumGameCube() => _service.ClassUnderTest.NumGameCube().ShouldBe(0);

        [Test]
        public void ItGetsNumWii() => _service.ClassUnderTest.NumWii().ShouldBe(0);

        [Test]
        public void ItGetsNumWiiU() => _service.ClassUnderTest.NumWiiU().ShouldBe(0);

        [Test]
        public void ItGetsNumNintendoSwitch() => _service.ClassUnderTest.NumNintendoSwitch().ShouldBe(0);

        [Test]
        public void ItGetsNumGameBoy() => _service.ClassUnderTest.NumGameBoy().ShouldBe(0);

        [Test]
        public void ItGetsNumGameBoyAdvance() => _service.ClassUnderTest.NumGameBoyAdvance().ShouldBe(0);

        [Test]
        public void ItGetsNumNintendoDS() => _service.ClassUnderTest.NumNintendoDS().ShouldBe(0);

        [Test]
        public void ItGetsNumNintendo3DS() => _service.ClassUnderTest.NumNintendo3DS().ShouldBe(0);

        [Test]
        public void ItGetsNumPSVita() => _service.ClassUnderTest.NumPSVita().ShouldBe(0);

        [Test]
        public void ItGetsNumPSP() => _service.ClassUnderTest.NumPSP().ShouldBe(0);

        [Test]
        public void ItGetsTopDevelopers() => _service.ClassUnderTest.TopDevelopers().FirstOrDefault().ShouldBe("Naughty Dog");

        [Test]
        public void ItGetsTopPublishers() => _service.ClassUnderTest.TopPublishers().FirstOrDefault().ShouldBe("Sony");

        [Test]
        public void ItGetsTopCountriesOfOrigin() => _service.ClassUnderTest.TopCountriesOfOrigin().FirstOrDefault().ShouldBe("US");

        [Test]
        public void ItGetsTopPurchaseCountries() => _service.ClassUnderTest.TopPurchaseCountries().FirstOrDefault().ShouldBe("US");

        [Test]
        public void ItGetsTopLocationsPurchased() => _service.ClassUnderTest.TopLocationsPurchased().FirstOrDefault().ShouldBe("Amazon");

        [Test]
        public void ItGetsMostCompleted() => _service.ClassUnderTest.MostCompleted().FirstOrDefault().ShouldBe("The Last of Us");

        [Test]
        public void ItGetsTopReleaseYears() => _service.ClassUnderTest.TopReleaseYears().FirstOrDefault().ShouldBe(2017);
    }
}