using NUnit.Framework;
using UnitTests.BusinessLogic.Services.TestBases;

namespace UnitTests.BusinessLogic.Services
{
	[TestFixture]
	public class ComicVineServiceTests : ComicVineTestBase
	{
		[Test]
		public void ThatSearchingReturnsAResult()
		{
			var result = _service.Search("wonder woman rebirth");

			Assert.Greater(result.results.Count, 0);
		}

		[Test]
		public void ThatSearchingByIDReturnsAResult()
		{
			var result = _service.SearchByID("4000-151290");

			Assert.IsNotNull(result);
		}
	}
}