﻿using Moq;
using NUnit.Framework;
using UI.Controllers;

namespace UnitTests.UI.Controllers.AlbumControllerTests.TestBases
{
	public class RecordControllerTestBase
	{
		protected Mock<AlbumController> _controller;

		[SetUp]
		public virtual void SetUp()
		{
			_controller = new Mock<AlbumController>();
		}
	}
}