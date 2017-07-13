using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Hacathon.Plumbing;

namespace Hacathon
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private WindsorContainer container;

        protected void Application_Start()
        {
            this.InstallContainer();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private void InstallContainer()
        {
            this.container = new WindsorContainer();
            this.container.Kernel.Resolver.AddSubResolver(new CollectionResolver(this.container.Kernel));
            this.container.Install(FromAssembly.This());

            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator), new WindsorHttpControllerActivator(this.container));
        }
    }
}
