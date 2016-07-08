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

		[Test]
		public void ThatSearchForMovieByIDReturnsAResult()
		{
			var result = _service.SearchMovieByID(8909);

			Assert.IsNotNull(result);
		}
	}
}