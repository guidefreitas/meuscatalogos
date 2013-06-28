using System.Web;
using System.Web.Mvc;
using System;

namespace MeusCatalogos.Helpers
{

    public static class UrlExtensions
    {
        public static string Current(this UrlHelper url)
        {
            return url.RequestContext.HttpContext.Request.RawUrl;
        }

        public static string AbsoluteContent(this UrlHelper url, string path)
        {
            var uri = new Uri(path, UriKind.RelativeOrAbsolute);

            if (!uri.IsAbsoluteUri)
            {
                var builder = new UriBuilder(url.RequestContext.HttpContext.Request.Url) { Path = VirtualPathUtility.ToAbsolute(path) };
                uri = builder.Uri;
            }

            return uri.ToString();
        }

        public static string Home(this UrlHelper url)
        {
            return url.RouteUrl(RouteName.Home);
        }

        public static string Price(this UrlHelper url)
        {
            return url.RouteUrl(RouteName.Price);
        }

        public static string SignIn(this UrlHelper url)
        {
            return url.RouteUrl(RouteName.SignIn);
        }

        public static string SignUp(this UrlHelper url)
        {
            return url.RouteUrl(RouteName.SignUp);
        }
    }
}