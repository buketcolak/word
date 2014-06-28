using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Castle.Windsor;

using WordSaver.Presentation.Helpers;

namespace WordSaver.Presentation
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            MvcHandler.DisableMvcResponseHeader = true;
            HtmlHelper.ClientValidationEnabled = false;
            HtmlHelper.UnobtrusiveJavaScriptEnabled = false;

            GlobalFilters.Filters.Add(new HandleErrorAttribute());

            RegisterRoutes(RouteTable.Routes);

            PrepareIocContainer();
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, new[] { "WordSaver.Presentation.Controllers" });
        }

        private void PrepareIocContainer()
        {
            var container = new WindsorContainer();

            container.Install(new ServiceInstaller());
            container.Install(new ControllersInstaller());
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container.Kernel));
        }

        protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Headers.Remove("X-Powered-By");
            HttpContext.Current.Response.Headers.Remove("X-AspNet-Version");
            HttpContext.Current.Response.Headers.Remove("X-AspNetMvc-Version");

            HttpContext.Current.Response.Headers.Set("Server", string.Format("Web Server ({0}) ", Environment.MachineName));
        }
    }
}