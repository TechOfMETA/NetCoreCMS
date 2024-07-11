
using Microsoft.AspNetCore.Mvc;
using NetCoreCMS.Framework.Core.Mvc.Controllers;
using NetCoreCMS.Framework.RouteAnalyzer;

namespace NetCoreCMS.Web.Controllers
{
    public class RouteAnalyzerController : NccController
    {
        private readonly IRouteAnalyzer m_routeAnalyzer;
        
        public RouteAnalyzerController(IRouteAnalyzer routeAnalyzer)
        {
            m_routeAnalyzer = routeAnalyzer;
        }

        public IActionResult ShowAllRoutes()
        {
            var infos = m_routeAnalyzer.GetAllRouteInformations();
            string ret = "";
            foreach (var info in infos)
            {
                ret += info.ToString() + "\n";
            }
            return Content(ret);
        }
    }
}
