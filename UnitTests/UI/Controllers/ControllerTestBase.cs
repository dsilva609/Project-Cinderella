using Moq;
using System.Security.Principal;
using System.Web.Mvc;

namespace UnitTests.UI.Controllers
{
    public class ControllerTestBase
    {
        private Mock<ControllerContext> _controllerContext = new Mock<ControllerContext>();
        private Mock<IPrincipal> _principal = new Mock<IPrincipal>();
        private MockHttpSession _session = new MockHttpSession();

        public virtual Mock<ControllerContext> SetupAuthorization(string userRole, bool userIsOfRole, bool userIsAuthenticated)
        {
            _principal.Setup(p => p.IsInRole(userRole)).Returns(userIsOfRole);
            _principal.SetupGet(x => x.Identity.IsAuthenticated).Returns(userIsAuthenticated);
            _controllerContext.SetupGet(x => x.HttpContext.User).Returns(_principal.Object);
            _controllerContext.Setup(c => c.HttpContext.Session).Returns(_session);

            return _controllerContext;
        }

        public virtual Mock<ControllerContext> SetupSession()
        {
            _controllerContext.Setup(c => c.HttpContext.Session).Returns(_session);

            return _controllerContext;
        }
    }
}