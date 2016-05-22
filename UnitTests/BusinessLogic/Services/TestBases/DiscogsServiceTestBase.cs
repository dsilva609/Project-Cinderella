using BusinessLogic.Services;
using NUnit.Framework;

namespace UnitTests.BusinessLogic.Services.TestBases
{
	public class DiscogsServiceTestBase
	{
		protected DiscogsService _service;

		[SetUp]
		protected virtual void SetUp()
		{
			_service = new DiscogsService();
		}
	}
}