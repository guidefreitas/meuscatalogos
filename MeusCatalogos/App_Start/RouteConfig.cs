using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MeusCatalogos
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                RouteName.Home,
                "home",
                MVC.Home.Index());

            routes.MapRoute(
                RouteName.SignIn,
                "signin",
                MVC.SignIn.Index());

            routes.MapRoute(
                RouteName.SignUp,
                "signup",
                MVC.SignUp.Index());

            routes.MapRoute(
                RouteName.Price,
                "price",
                MVC.Price.Index());
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}