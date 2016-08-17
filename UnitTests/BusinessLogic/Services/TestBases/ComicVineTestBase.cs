using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
using NUnit.Framework;

namespace UnitTests.BusinessLogic.Services.TestBases
{
    public class ComicVineTestBase
    {
        protected IComicVineService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new ComicVineService();
        }
    }
}