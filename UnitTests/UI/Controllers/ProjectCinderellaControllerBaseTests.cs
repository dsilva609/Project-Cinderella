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
		public void ThatStartDateIsSetCorrectly()
		{
			var model = new BaseItem { CompletionStatus = CompletionStatus.InProgress };
			_controller.ClassUnderTest.SetTimeStamps(model);

			model.DateStarted.ShouldBeGreaterThan(DateTime.MinValue);
		}
	}
}