using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
using NUnit.Framework;

namespace UnitTests.BusinessLogic.Services.TestBases
{
	public class BGGServiceTestBase
	{
		protected IBGGService _service;

		[SetUp]
		public void SetUp()
		{
			_service = new BGGService();
		}
	}
}