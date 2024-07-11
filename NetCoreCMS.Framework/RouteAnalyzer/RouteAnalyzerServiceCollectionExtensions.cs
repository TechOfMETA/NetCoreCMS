using Microsoft.Extensions.DependencyInjection;
namespace NetCoreCMS.Framework.RouteAnalyzer
{
    public static class RouteAnalyzerServiceCollectionExtensions
    {
        public static IServiceCollection AddRouteAnalyzer(this IServiceCollection services)
        {
            services.AddSingleton<IRouteAnalyzer, RouteAnalyzerImpl>();
            return services;
        }
    }
}
