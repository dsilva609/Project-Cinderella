using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
using NUnit.Framework;

namespace UnitTests.BusinessLogic.Services.TestBases
{
	public class TMDBServiceTestBase
	{
		protected ITMDBService _service;

		[SetUp]
		public virtual void SetUp()
		{
			_service = new TMDBService();
		}
	}
}