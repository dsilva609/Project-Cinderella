using NUnit.Framework;
using UnitTests.BusinessLogic.Services.TestBases;

namespace UnitTests.BusinessLogic.Services
{
	[TestFixture]
	public class GiantBombServiceTests : GiantBombServiceTestBase
	{
		[Test]
		public void ThatSearchReturnsAResult()
		{
			var result = _service.Search("Brutal Legend");

			//	Assert.Greater(result.results.Count, 0);
		}

		[Test]
		public void ThatSearchByIDReturnsAResult()
		{
			var result = _service.SearchByID(20700);

			Assert.IsNotNull(result.results);
		}
	}
}