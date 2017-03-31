using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;
using System.Collections.Generic;
using System.Web.Mvc;
using UnitTests.UI.Controllers.TestBases;

namespace UnitTests.UI.Controllers
{
	public class ShowcaseControllerTests : ShowcaseControllerTestBase
	{
		[Test]
		public void ThatIndexActionReturnsAView()
		{
			_controller.Get<IAlbumService>()
				.Expect(x => x.GetAll(Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<int>.Is.Anything, Arg<int?>.Is.Anything))
				.Return(new List<Album> { new Album { IsShowcased = true, UserNum = 1 } });
			_controller.Get<IBookService>()
				.Expect(x => x.GetAll(Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<int>.Is.Anything, Arg<int?>.Is.Anything))
				.Return(new List<Book>
				{
					new Book {IsShowcased = true, UserNum = 1}
				});
			_controller.Get<IGameService>()
				.Expect(x => x.GetAll(Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<int>.Is.Anything, Arg<int?>.Is.Anything))
				.Return(new List<Game>
				{
					new Game {IsShowcased = true, UserNum = 1}
				});
			_controller.Get<IMovieService>()
				.Expect(x => x.GetAll(Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<int>.Is.Anything, Arg<int?>.Is.Anything))
				.Return(new List<Movie>
				{
					new Movie {IsShowcased = true, UserNum = 1}
				});
			_controller.Get<IPopService>()
				.Expect(x => x.GetAll(Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<int>.Is.Anything, Arg<int?>.Is.Anything))
				.Return(new List<FunkoModel>
				{
					new FunkoModel {IsShowcased = true, UserNum = 1}
				});

			var result = _controller.ClassUnderTest.Index(1) as ViewResult;

			string.IsNullOrWhiteSpace(result.ViewName).ShouldBeTrue();
		}

		[Test]
		public void ThatAddActionReturnsAView()
		{
			var result = _controller.ClassUnderTest.Add() as ViewResult;

			string.IsNullOrWhiteSpace(result.ViewName).ShouldBeTrue();
		}

		[Test]
		[TestCase(ItemType.Album)]
		[TestCase(ItemType.Book)]
		[TestCase(ItemType.Game)]
		[TestCase(ItemType.Movie)]
		[TestCase(ItemType.Pop)]
		public void ThatSearchRedirectsToCorrectController(ItemType type)
		{
			var result = _controller.ClassUnderTest.SearchItems("test", type) as RedirectToRouteResult;

			result.RouteValues["Controller"].ShouldBe(type.ToString());
			result.RouteValues["Action"].ShouldBe("Index");
		}
	}
}