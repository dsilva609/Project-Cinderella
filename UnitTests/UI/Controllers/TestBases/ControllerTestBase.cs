using Moq;
using System.Security.Principal;
using System.Web.Mvc;

namespace UnitTests.UI.Controllers.TestBases
{
    public class ControllerTestBase
    {
        protected readonly MockHttpSession _session;
        private readonly Mock<ControllerContext> _controllerContext;
        private readonly Mock<IPrincipal> _principal;

        protected ControllerTestBase()
        {
            _controllerContext = new Mock<ControllerContext>();
            _principal = new Mock<IPrincipal>();
            _session = new MockHttpSession();
        }

        public virtual Mock<ControllerContext> SetupAuthorization(string userRole, bool userIsOfRole, bool userIsAuthenticated)
        {
            _principal.Setup(p => p.IsInRole(userRole)).Returns(userIsOfRole);
            var identity = new Mock<IIdentity>();
            identity.Setup(x => x.IsAuthenticated).Returns(userIsAuthenticated);
            identity.Setup(x => x.Name).Returns("Test User");
            _principal.Setup(x => x.Identity).Returns(identity.Object);
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