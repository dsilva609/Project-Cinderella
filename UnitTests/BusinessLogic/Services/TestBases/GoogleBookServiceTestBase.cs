using BusinessLogic.Services;
using NUnit.Framework;

namespace UnitTests.BusinessLogic.Services.TestBases
{
	public class GoogleBookServiceTestBase
	{
		protected GoogleBookService _service;

		[SetUp]
		protected virtual void SetUp()
		{
			_service = new GoogleBookService();
		}
	}
}