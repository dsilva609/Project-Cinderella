using Moq;
using NUnit.Framework;
using System.Security.Principal;
using System.Web.Mvc;

namespace UnitTests.UI.Controllers
{
	[TestFixture]
	public class ControllerTestBase
	{
		private Mock<ControllerContext> _controllerContext = new Mock<ControllerContext>();
		private Mock<IPrincipal> _principal = new Mock<IPrincipal>();
		private MockHttpSession _session = new MockHttpSession();

		public virtual Mock<ControllerContext> SetupAuthorization(string userRole, bool userIsOfRole, bool userIsAuthenticated)
		{
			this._principal.Setup(p => p.IsInRole(userRole)).Returns(userIsOfRole);
			this._principal.SetupGet(x => x.Identity.IsAuthenticated).Returns(userIsAuthenticated);
			this._controllerContext.SetupGet(x => x.HttpContext.User).Returns(this._principal.Object);
			this._controllerContext.Setup(c => c.HttpContext.Session).Returns(this._session);

			return this._controllerContext;
		}

		public virtual Mock<ControllerContext> SetupSession()
		{
			this._controllerContext.Setup(c => c.HttpContext.Session).Returns(this._session);

			return this._controllerContext;
		}
	}
}