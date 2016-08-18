using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
using NUnit.Framework;

namespace UnitTests.BusinessLogic.Services.TestBases
{
	public class GiantBombServiceTestBase
	{
		protected IGiantBombService _service;

		[SetUp]
		public void SetUp()
		{
			_service = new GiantBombService();
		}
	}
}