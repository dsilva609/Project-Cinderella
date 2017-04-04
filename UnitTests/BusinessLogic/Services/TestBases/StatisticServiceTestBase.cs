using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using BusinessLogic.Services.Statistics;
using NUnit.Framework;
using Rhino.Mocks;
using StructureMap.AutoMocking;
using System.Collections.Generic;

namespace UnitTests.BusinessLogic.Services.TestBases
{
	public class StatisticServiceTestBase
	{
		protected RhinoAutoMocker<StatisticService> _service;

		[SetUp]
		public virtual void SetUp()
		{
			_service = new RhinoAutoMocker<StatisticService>();

			_service.Get<IAlbumService>().Expect(x => x.GetAll()).Return(new List<Album>
			{
				new Album
				{
					UserID = "Dio",
					IsNew = true,
					IsPhysical = true,
					TimesCompleted = 5,
					CheckedOut = true,
					CompletionStatus = CompletionStatus.InProgress
				},
				new Album {IsNew = true, IsPhysical = true, TimesCompleted = 5, CheckedOut = true, CompletionStatus = CompletionStatus.Completed},
				new Album
				{
					UserID = "Simone",
					IsNew = false,
					IsPhysical = true,
					TimesCompleted = 0,
					CheckedOut = false,
					CompletionStatus = CompletionStatus.Completed
				},
				new Album {IsNew = true, IsPhysical = true, TimesCompleted = 1, CheckedOut = false, CompletionStatus = CompletionStatus.Completed},
				new Album
				{
					IsNew = false,
					IsPhysical = false,
					TimesCompleted = 0,
					CheckedOut = false,
					CompletionStatus = CompletionStatus.NotStarted,
					IsShowcased = true
				},
				new Album
				{
					UserID = "Dio",
					IsNew = true,
					IsPhysical = false,
					TimesCompleted = 5,
					CheckedOut = false,
					CompletionStatus = CompletionStatus.NotStarted,
					IsShowcased = true
				}
			});
			_service.Get<IBookService>().Expect(x => x.GetAll()).Return(new List<Book>());
			_service.Get<IGameService>().Expect(x => x.GetAll()).Return(new List<Game>());
			_service.Get<IMovieService>().Expect(x => x.GetAll()).Return(new List<Movie>());

			_service.Get<IWishService>().Expect(x => x.GetAll()).Return(new List<Wish> {new Wish {UserID = "test"}, new Wish()});
			_service.Get<IWishService>()
				.Expect(x => x.GetAll("test", string.Empty, 0, 1))
				.Return(new List<Wish> {new Wish {UserID = "test"}});
			_service.Get<IPopService>().Expect(x => x.GetAll(string.Empty, string.Empty, 0, 1)).Return(new List<FunkoModel>
			{
				new FunkoModel {UserID = "test"}
			});
		}
	}
}