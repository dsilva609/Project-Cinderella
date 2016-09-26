using BusinessLogic.Services.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;
using UnitTests.BusinessLogic.Services.TestBases;

namespace UnitTests.BusinessLogic.Services
{
	public class StatisticServiceTests : StatisticServiceTestBase
	{
		[Test]
		public void ThatItReturnsGlobalCollectionCount()
		{
			_service.Get<IAlbumService>().Expect(x => x.GetCount()).Return(5);
			_service.Get<IBookService>().Expect(x => x.GetCount()).Return(10);
			_service.Get<IGameService>().Expect(x => x.GetCount()).Return(5);
			_service.Get<IMovieService>().Expect(x => x.GetCount()).Return(20);

			var result = _service.ClassUnderTest.GetCollectionCount();

			result.ShouldBe(40);
		}
	}
}