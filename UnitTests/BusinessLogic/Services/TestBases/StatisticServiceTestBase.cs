using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
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
				new Album { IsNew = true, IsPhysical = true, TimesCompleted = 5, CheckedOut = true, CompletionStatus = CompletionStatus.InProgress },
				new Album { IsNew = true , IsPhysical = true, TimesCompleted = 5, CheckedOut = true, CompletionStatus = CompletionStatus.Completed },
				new Album { IsNew = false, IsPhysical = true, TimesCompleted = 0, CheckedOut = false, CompletionStatus = CompletionStatus.Completed },
				new Album { IsNew = true , IsPhysical = true, TimesCompleted = 1, CheckedOut = false, CompletionStatus = CompletionStatus.Completed },
				new Album { IsNew = false , IsPhysical = false, TimesCompleted = 0, CheckedOut = false, CompletionStatus = CompletionStatus.NotStarted },
				new Album { IsNew = true, IsPhysical = false, TimesCompleted = 5,CheckedOut = false, CompletionStatus = CompletionStatus.NotStarted }
			});
			_service.Get<IBookService>().Expect(x => x.GetAll()).Return(new List<Book>());
			_service.Get<IGameService>().Expect(x => x.GetAll()).Return(new List<Game>());
			_service.Get<IMovieService>().Expect(x => x.GetAll()).Return(new List<Movie>());
		}
	}
}