using BusinessLogic.Services;
using NUnit.Framework;
using StructureMap.AutoMocking;

namespace UnitTests.BusinessLogic.Services.TestBases
{
	public class StatisticServiceTestBase
	{
		protected RhinoAutoMocker<StatisticService> _service;

		[SetUp]
		public virtual void SetUp()
		{
			_service = new RhinoAutoMocker<StatisticService>();
		}
	}
}