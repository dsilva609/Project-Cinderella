using BusinessLogic.Services;
using Google.Apis.Books.v1;
using NUnit.Framework;

namespace UnitTests.BusinessLogic.Services.TestBases
{
	public class GoogleBookServiceTestBase
	{
		protected GoogleBookService _service;

		[SetUp]
		protected virtual void SetUp()
		{
			_service = new GoogleBookService(new BooksService());
		}
	}
}