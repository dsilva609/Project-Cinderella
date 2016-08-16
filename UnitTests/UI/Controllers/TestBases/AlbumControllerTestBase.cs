﻿using NUnit.Framework;
using StructureMap.AutoMocking;
using UI.Controllers;

namespace UnitTests.UI.Controllers.TestBases
{
	public class AlbumControllerTestBase : ControllerTestBase
	{
		protected RhinoAutoMocker<AlbumController> _controller;

		[SetUp]
		public virtual void SetUp()
		{
			_controller = new RhinoAutoMocker<AlbumController>();
			_controller.ClassUnderTest.ControllerContext = SetupAuthorization("Admin", true, true).Object;
			_session["albumResult"] = null;
		}
	}
}