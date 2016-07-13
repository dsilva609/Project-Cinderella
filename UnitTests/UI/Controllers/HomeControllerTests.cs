using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;
using System.Collections.Generic;
using System.Web.Mvc;
using UnitTests.UI.Controllers.TestBases;

namespace UnitTests.UI.Controllers
{
	[TestFixture]
	public class HomeControllerTests : HomeControllerTestBase
	{
		[Test]
		public void ThatIndexActionReturnsAView()
		{
			//--Arrange
			_homeControllerMock.Get<IAlbumService>().Expect(x => x.GetAll(Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<int>.Is.Anything, Arg<int>.Is.Anything))
				.Return(new List<Album>());

			//--Act
			var result = _homeControllerMock.ClassUnderTest.Index() as ViewResult;

			// Assert
			Assert.AreEqual(string.Empty, result.ViewName);
		}

		[Test]
		public void ThatAboutActionReturnsAView()
		{
			//--Act
			var result = _homeControllerMock.ClassUnderTest.About() as ViewResult;

			//--Assert
			Assert.AreEqual(string.Empty, result.ViewName);
		}

		[Test]
		public void ThatContactActionReturnsAView()
		{
			//--Act
			var result = _homeControllerMock.ClassUnderTest.Contact() as ViewResult;

			//--Assert
			Assert.AreEqual(string.Empty, result.ViewName);
		}
	}
}