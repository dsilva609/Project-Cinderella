﻿using NUnit.Framework;
using StructureMap.AutoMocking;
using UI.Controllers;

namespace UnitTests.UI.Controllers.TestBases
{
	public class MovieControllerTestBase : ControllerTestBase
	{
		protected RhinoAutoMocker<MovieController> _controller;

		[SetUp]
		public virtual void SetUp()
		{
			_controller = new RhinoAutoMocker<MovieController>();
			_controller.ClassUnderTest.ControllerContext = SetupAuthorization("Admin", true, true).Object;
			_session["movieResult"] = null;
		}
	}
}