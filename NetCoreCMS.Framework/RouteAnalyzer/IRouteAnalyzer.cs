
using System.Collections.Generic;

namespace NetCoreCMS.Framework.RouteAnalyzer
{
    public interface IRouteAnalyzer
    {
        IEnumerable<RouteInformation> GetAllRouteInformations();
    }
}
