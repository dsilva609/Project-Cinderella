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
    }
}