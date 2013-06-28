[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MeusCatalogos.AppActivator), "PreStart")]
[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(MeusCatalogos.AppActivator), "PostStart")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MeusCatalogos.AppActivator), "Stop")]
namespace MeusCatalogos
{
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public static class AppActivator
    {
        public static void PreStart()
        {

        }

        public static void PostStart()
        {
            AppPostStart();
        }

        public static void Stop()
        {

        }

        private static void AppPostStart()
        {
            
        }
    }
}