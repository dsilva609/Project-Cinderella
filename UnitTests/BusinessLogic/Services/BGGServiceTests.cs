using NUnit.Framework;
using UnitTests.BusinessLogic.Services.TestBases;

namespace UnitTests.BusinessLogic.Services
{
	public class BGGServiceTests : BGGServiceTestBase
	{
		[Test]
		public void ThatSearchingReturnsAResult()
		{
			var result = _service.Search("Mansions of madness");

			Assert.IsNotNull(result);
			Assert.Greater(result.Items.Count, 0);
		}

		[Test]
		public void ThatSearchingByIDReturnsAResult()
		{
			var result = _service.SearchByID(83330);

			Assert.IsNotNull(result);
		}
	}
}