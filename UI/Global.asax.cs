using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UI.App_Start;

namespace UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();
        }

        protected void Session_Start()
        {
            //HttpContext.Current.Session.Add("CardSortAscending", true);
            //HttpContext.Current.Session.Add("CardSortPreference", "Name");
            //HttpContext.Current.Session.Add("PlayerSortAscending", true);
            //HttpContext.Current.Session.Add("PlayerSortPreference", "Name");
        }
    }
}