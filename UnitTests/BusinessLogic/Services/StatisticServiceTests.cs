using NUnit.Framework;
using Shouldly;
using UnitTests.BusinessLogic.Services.TestBases;

namespace UnitTests.BusinessLogic.Services
{
	public class StatisticServiceTests : StatisticServiceTestBase
	{
		[Test]
		public void ItReturnsGlobalCollectionCount()
		{
			var result = _service.ClassUnderTest.GetCollectionCount();

			result.ShouldBe(6);
		}

		[Test]
		public void ItReturnsNumberOfNewItems()
		{
			var result = _service.ClassUnderTest.GetNumNew();

			result.ShouldBe(4);
		}

		[Test]
		public void ItReturnsNumOfUsedItems()
		{
			var result = _service.ClassUnderTest.GetNumUsed();

			result.ShouldBe(2);
		}

		[Test]
		public void ItReturnsNumPhysical()
		{
			var result = _service.ClassUnderTest.GetNumPhysical();

			result.ShouldBe(4);
		}

		[Test]
		public void ItReturnsNumDigital()
		{
			var result = _service.ClassUnderTest.GetNumDigital();

			result.ShouldBe(2);
		}

		[Test]
		public void ItGetsNumTimesCompleted()
		{
			var result = _service.ClassUnderTest.GetTimesCompleted();

			result.ShouldBe(16);
		}

		[Test]
		public void ItGetsNumCheckedOut()
		{
			var result = _service.ClassUnderTest.GetNumCheckedOut();

			result.ShouldBe(2);
		}

		[Test]
		public void ItGetsNumInProgress()
		{
			var result = _service.ClassUnderTest.GetNumInProgress();

			result.ShouldBe(1);
		}

		[Test]
		public void ItGetsNumCompleted()
		{
			var result = _service.ClassUnderTest.GetNumCompleted();

			result.ShouldBe(3);
		}

		[Test]
		public void ItGetsNumNotStarted()
		{
			var result = _service.ClassUnderTest.GetNumNotStarted();

			result.ShouldBe(2);
		}
	}
}