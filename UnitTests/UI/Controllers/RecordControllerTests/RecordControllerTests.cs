﻿using BusinessLogic.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Web.Mvc;
using UI.Models;
using UnitTests.UI.Controllers.RecordControllerTests.TestBases;

namespace UnitTests.UI.Controllers.RecordControllerTests
{
	[TestFixture]
	public class RecordControllerTests : RecordControllerTestBase
	{
		private RecordModel _testModel = new RecordModel();
		private List<RecordViewModel> _expectedIndexModels = new List<RecordViewModel>();

		[Test]
		public void ThatTheIndexActionReturnsAView()
		{
			//--Arrange
			_controller.Setup(mock => mock.Index()).Returns(new ViewResult { ViewName = MVC.Record.Views.Index });

			//--Act
			var result = _controller.Object.Index() as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Record.Views.Index, result.ViewName);
		}

		[Test]
		public void ThatSpecifiedViewModelIsSentToView()
		{
			//--Arrange
			_controller.Setup(mock => mock.Index())
				.Returns(new ViewResult { ViewName = MVC.Record.Views.Index, ViewData = new ViewDataDictionary(_expectedIndexModels) });

			//--Act
			var result = _controller.Object.Index() as ViewResult;

			//--Assert
			Assert.AreEqual(_expectedIndexModels, result.ViewData.Model);
		}

		[Test]
		public void ThatCreateActionReturnsAView()
		{
			//--Arrange
			_controller.Setup(mock => mock.Create()).Returns(new ViewResult { ViewName = MVC.Record.Views.Edit });

			//--Act
			var result = _controller.Object.Create() as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Record.Views.Edit, result.ViewName);
		}

		[Test]
		public void ThatCorrectModelIsPassedIntoCreateView()
		{
			//--Arrange
			_controller.Setup(mock => mock.Create()).Returns(new ViewResult { ViewData = new ViewDataDictionary(_testModel) });

			//--Act
			var result = _controller.Object.Create() as ViewResult;

			//--Assert
			Assert.AreEqual(_testModel, result.ViewData.Model);
		}

		[Test]
		public void ItRedirectsToIndexActionWhenModelIsValid()
		{
			//--Arrange
			_controller.Setup(mock => mock.Create(It.IsNotNull<RecordModel>()))
				.Returns(new ViewResult { ViewName = MVC.Record.Views.Index });

			//--Act
			var result = _controller.Object.Create(_testModel) as ViewResult;

			//--Assert
			Assert.IsTrue(_controller.Object.ModelState.IsValid);
			Assert.AreEqual(MVC.Record.Views.Index, result.ViewName);
		}

		[Test]
		public void ItGoesBackToTheViewIfModelStateIsInvalid()
		{
			//--Arrange
			_controller.Setup(mock => mock.Create(It.IsNotNull<RecordModel>()))
				.Returns(new ViewResult { ViewName = MVC.Record.Views.Edit });
			_controller.Object.ModelState.AddModelError(string.Empty, string.Empty);

			//--Act
			var result = _controller.Object.Create(_testModel) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Record.Views.Edit, result.ViewName);
			Assert.IsFalse(_controller.Object.ModelState.IsValid);
		}

		[Test]
		public void ItGoesToIndexViewAfterDelete()
		{
			//--Arrange
			_controller.Setup(mock => mock.Delete(It.IsNotNull<int>()))
				.Returns(new ViewResult { ViewName = MVC.Record.Views.Index });

			//--Act
			var result = _controller.Object.Delete(6213) as ViewResult;

			//--Assert
			Assert.AreEqual(MVC.Record.Views.Index, result.ViewName);
		}
	}
}