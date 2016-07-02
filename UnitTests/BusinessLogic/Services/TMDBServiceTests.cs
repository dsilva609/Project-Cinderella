using NUnit.Framework;
using UnitTests.BusinessLogic.Services.TestBases;

namespace UnitTests.BusinessLogic.Services
{
	[TestFixture]
	public class TMDBServiceTests : TMDBServiceTestBase
	{
		[Test]
		public void ThatSearchingForMoviesReturnsAResult()
		{
			var result = _service.SearchMovies("Deadpool");

			Assert.Greater(result.Count, 0);
		}
	}
}