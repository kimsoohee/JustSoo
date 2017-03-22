using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace www
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Board_Remove",
                url: "board/remove/{board_seq}",
                defaults: new { controller = "Board", action = "Remove" }
            );

            routes.MapRoute(
                name: "Board_Read",
                url: "board/read/{board_type}/{board_type_code}/{id}",
                defaults: new { controller = "Board", action = "Read", board_type = UrlParameter.Optional, board_type_code = UrlParameter.Optional, id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Board_Write",
                url: "board/write/{board_type}/{board_type_code}/{id}",
                defaults: new { controller = "Board", action = "Write", board_type = UrlParameter.Optional, board_type_code = UrlParameter.Optional, id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );            
        }
    }
}
