using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
namespace NetCoreCMS.Framework.RouteAnalyzer
{
    public static class RouteAnalyzerRouteBuilderExtensions
    {
        public static string RouteAnalyzerUrlPath { get; private set; } = "";

        //public static IRouteBuilder MapRouteAnalyzer(this IRouteBuilder routes, string routeAnalyzerUrlPath)
        //{
        //    RouteAnalyzerUrlPath = routeAnalyzerUrlPath;
        //    routes.Routes.Add(new Router(routes.DefaultHandler, routeAnalyzerUrlPath));
        //    return routes;
        //}

        public static IEndpointRouteBuilder MapRouteAnalyzer(this IEndpointRouteBuilder endpoints, string routeAnalyzerUrlPath)
        {
            RouteAnalyzerUrlPath = routeAnalyzerUrlPath;
            endpoints.MapControllerRoute(
                        name: "mapRouteAnalyzer",
                        pattern: routeAnalyzerUrlPath,
                        defaults: new { controller = "RouteAnalyzer", action = "ShowAllRoutes" });
            return endpoints;
        }
    } 
}
