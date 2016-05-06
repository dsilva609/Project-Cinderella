using System.Web.Optimization;

namespace UI
{
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery")
				.Include("~/Scripts/jquery-{version}.min.js")
				.Include("~/Scripts/jquery-mobile-{version}.min.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
				"~/Scripts/jquery.validate*"));
			bundles.Add(new ScriptBundle("~/bundles/jqueryui")
				.Include("~/Scripts/jquery-ui-{version}.min.js"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
				"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap")
				.Include("~/Scripts/bootstrap-{version}.min.js")
				.Include("~/Scripts/bootstrap-datepicker.min.js")
				.Include("~/Scripts/respond.js"));

			bundles.Add(new ScriptBundle("~/bundles/custom")
				.Include("~/Scripts/Namespace.js")
				.Include("~/Scripts/Shared/_Layout.js")
				.Include("~/Scripts/Shared/Logout.js")
				.Include("~/Scripts/toastr.min.js")
				.Include("~/Scripts/PageSpecific/RecordIndex.js")
				.Include("~/Scripts/PageSpecific/RecordDetails.js")
				.Include("~/Scripts/PageSpecific/RecordEdit.js"));

			bundles.Add(new StyleBundle("~/Content/css")
				.Include("~/Content/bootstrap.css")
				.Include("~/Content/bootstrap-datepicker3.min.css")
				.Include("~/Content/site.css")
				.Include("~/Content/toastr.min.css")
				.Include("~/Content/font-awesome.min.css"));

			// Set EnableOptimizations to false for debugging. For more information,
			// visit http://go.microsoft.com/fwlink/?LinkId=301862
			BundleTable.EnableOptimizations = true;
		}
	}
}