using System.Linq;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.Extensions.DependencyInjection;

namespace NetCoreCMS.Framework.ViewCompiler
{
    public static class ViewCompilerExt
    {
        public static IServiceCollection AddNccViewCompilerProvider(this IServiceCollection services)
        {
            services.AddControllersWithViews();
            ServiceDescriptor descriptor = services.FirstOrDefault(s => s.ServiceType == typeof(IViewCompilerProvider));
            services.Remove(descriptor);
            services.AddSingleton<IViewCompilerProvider, ModuleViewCompilerProvider>();
            return services;
        }
    }
}
