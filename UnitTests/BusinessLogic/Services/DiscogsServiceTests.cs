using NUnit.Framework;
using UnitTests.BusinessLogic.Services.TestBases;

namespace UnitTests.BusinessLogic.Services
{
	[TestFixture]
	public class DiscogsServiceTests : DiscogsServiceTestBase
	{
		[Test]
		public void ThatItIsAbleToGetARelease()
		{
			var result = _service.GetRelease(1772986);

			Assert.IsNotNull(result);
		}

		[Test]
		public void ThatReleaseReturnsNullForAnInvalidID()
		{
			var result = _service.GetRelease(0);

			Assert.IsNotNull(result);
		}

		[Test]
		public void ThatSearchResultsAreFound()
		{
			var result = _service.Search("Dio", "Holy Diver");

			Assert.Greater(result.Count, 0);
		}

		[Test]
		public void ThatNoResultsAreReturnedWhenNothingIsSearched()
		{
			var result = _service.Search(string.Empty, string.Empty);

			Assert.AreEqual(0, result.Count);
		}
	}
}