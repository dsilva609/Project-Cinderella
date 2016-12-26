using BusinessLogic.Enums;
using BusinessLogic.Models;
using NUnit.Framework;
using Shouldly;
using System;
using UnitTests.UI.Controllers.TestBases;

namespace UnitTests.UI.Controllers
{
	[TestFixture]
	public class ProjectCinderellaControllerBaseTests : ProjectCinderellaControllerBaseTestBase
	{
		[Test]
		public void ThatStartDateIsSetCorrectlyForNewItems()
		{
			var model = new BaseItem { CompletionStatus = CompletionStatus.InProgress };
			_controller.ClassUnderTest.SetTimeStamps(model);

			model.DateStarted.ShouldBeGreaterThan(DateTime.MinValue);
		}

		[Test]
		public void ThatStartDateIsSetCorrectlyForExistingItems()
		{
			var model = new BaseItem { ID = 1, CompletionStatus = CompletionStatus.InProgress };

			_controller.ClassUnderTest.SetTimeStamps(model);

			model.DateStarted.ShouldBeGreaterThan(DateTime.MinValue);
		}

		[Test]
		public void ThatCompletedDateIsSetCorrectlyForNewItems()
		{
			var model = new BaseItem { CompletionStatus = CompletionStatus.Completed };

			_controller.ClassUnderTest.SetTimeStamps(model);

			model.DateCompleted.ShouldBeGreaterThan(DateTime.MinValue);
		}

		[Test]
		public void ThatCompletedDateIsSetCorrectlyForExistingItems()
		{
			var model = new BaseItem { ID = 1, CompletionStatus = CompletionStatus.Completed };

			_controller.ClassUnderTest.SetTimeStamps(model);

			model.DateCompleted.ShouldBeGreaterThan(DateTime.MinValue);
		}
	}
}