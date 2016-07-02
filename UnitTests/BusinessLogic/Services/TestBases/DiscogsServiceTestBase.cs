﻿using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
using NUnit.Framework;

namespace UnitTests.BusinessLogic.Services.TestBases
{
	public class DiscogsServiceTestBase
	{
		protected IDiscogsService _service;

		[SetUp]
		protected virtual void SetUp()
		{
			_service = new DiscogsService();
		}
	}
}