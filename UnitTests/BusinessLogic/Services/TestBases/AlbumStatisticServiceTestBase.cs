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
	public class AlbumStatisticServiceTestBase
	{
		protected RhinoAutoMocker<AlbumStatisticService> _service;

		[SetUp]
		public virtual void SetUp()
		{
			_service = new RhinoAutoMocker<AlbumStatisticService>();

			_service.Get<IAlbumService>().Expect(x => x.GetAll()).Return(new List<Album>
			{
				new Album
				{
					Artist = "Dio",
					Title = "The Last In Line",
					Genre = "Rock",
					RecordLabel = "Warner",
					CountryOfOrigin = "US",
					CountryPurchased = "US",
					LocationPurchased = "Rama Lama",
					YearReleased = 1980,
					UserID = "Dio",
					MediaType = AlbumMediaTypeEnum.Vinyl,
					IsNew = true,
					IsPhysical = true,
					TimesCompleted = 5,
					CheckedOut = true,
					CompletionStatus = CompletionStatus.InProgress
				},
				new Album
				{
					Artist = "Dio",
					Title = "Heaven and Hell",
					IsNew = true,
					MediaType = AlbumMediaTypeEnum.Vinyl,
					IsPhysical = true,
					TimesCompleted = 5,
					CheckedOut = true,
					CompletionStatus = CompletionStatus.Completed
				},
				new Album
				{
					Artist = "Epica",
					UserID = "Simone",
					MediaType = AlbumMediaTypeEnum.CD,
					IsNew = false,
					IsPhysical = true,
					TimesCompleted = 0,
					CheckedOut = false,
					CompletionStatus = CompletionStatus.Completed
				},
				new Album
				{
					IsNew = true,
					Size = SizeEnum.Seven,
					IsPhysical = true,
					TimesCompleted = 1,
					CheckedOut = false,
					CompletionStatus = CompletionStatus.Completed
				},
				new Album
				{
					IsNew = false,
					Size = SizeEnum.Ten,
					Speed = SpeedEnum.RPM78,
					IsPhysical = false,
					TimesCompleted = 0,
					CheckedOut = false,
					CompletionStatus = CompletionStatus.NotStarted,
					IsShowcased = true
				},
				new Album
				{
					Title = "Holy Diver",
					UserID = "Dio",
					Size = SizeEnum.Ten,
					Speed = SpeedEnum.RPM45,
					IsNew = true,
					IsPhysical = false,
					TimesCompleted = 5,
					CheckedOut = false,
					CompletionStatus = CompletionStatus.NotStarted,
					IsShowcased = true
				}
			});
		}
	}
}