/*************************************************************
 *          Project: NetCoreCMS                              *
 *              Web: http://dotnetcorecms.org                *
 *           Author: OnnoRokom Software Ltd.                 *
 *          Website: www.onnorokomsoftware.com               *
 *            Email: info@onnorokomsoftware.com              *
 *        Copyright: OnnoRokom Software Ltd.                 *
 *          License: BSD-3-Clause                            *
 *************************************************************/

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NetCoreCMS.Framework.Setup;
using NetCoreCMS.Framework.Utility;
using System;

namespace NetCoreCMS.Framework.Core.Extensions
{
    public static class NccRouteExtension
    {
        public static IApplicationBuilder UseNccRoutes(this IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                if (SetupHelper.IsAdminCreateComplete && GlobalContext.WebSite.IsMultiLangual)
                {
                    endpoints.MapControllerRoute(
                      name: "multiLangualAreaDefault",
                      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );

                    endpoints.MapControllerRoute(
                      name: "multiLangualAreaDefaultWithLang",
                      pattern: "{lang:lang}/{area:exists}/{controller}/{action}/{id?}",
                      defaults: new
                      {
                          controller = "Home",
                          action = "Index"
                      }
                    );

                    endpoints.MapControllerRoute(
                      name: "MultiLangAnyControlerAction",
                      pattern: "{lang:lang}/{controller}/{action}/{id?}",
                      defaults: new
                      {
                          controller = "Home",
                          action = "Index"
                      }
                    );

                    endpoints.MapControllerRoute(
                      name: "MultiLangCmsPage",
                      pattern: "{lang:lang}/{slug?}",
                      defaults: new
                      {
                          controller = "CmsPage",
                          action = "Index"
                      });

                    endpoints.MapControllerRoute(
                      name: "MultiLangBlogPost",
                      pattern: "{lang:lang}/post/{slug?}",
                      defaults: new
                      {
                          controller = "Post",
                          action = "Index"
                      });

                    endpoints.MapControllerRoute(
                      name: "MultiLangBlogCategory",
                      pattern: "{lang:lang}/category/{slug?}",
                      defaults: new
                      {
                          controller = "Category",
                          action = "Index"
                      });

                    endpoints.MapControllerRoute(
                      name: "login",
                      pattern: "Login",
                      defaults: new
                      {
                          controller = "Account",
                          action = "Login"
                      }
                    );

                    endpoints.MapControllerRoute(
                      name: "default",
                      pattern: "{controller}/{action}/{id?}",
                      defaults: new
                      {
                          controller = "Home",
                          action = "Index"
                      }
                    );

                    endpoints.MapControllerRoute(
                      name: "cmsPage",
                      pattern: "{slug}",
                      defaults: new
                      {
                          controller = "CmsPage",
                          action = "Index"
                      });

                    endpoints.MapControllerRoute(
                      name: "blogPost",
                      pattern: "post/{slug?}",
                      defaults: new
                      {
                          controller = "Post",
                          action = "Index"
                      });

                    endpoints.MapControllerRoute(
                      name: "blogCategory",
                      pattern: "category/{slug?}",
                      defaults: new
                      {
                          controller = "Category",
                          action = "Index"
                      });

                    endpoints.MapControllerRoute(
                      name: "MultiLangDefault",
                      pattern: "{lang:lang}/",
                      defaults: new
                      {
                          controller = "Home",
                          action = "Index"
                      }
                    );

                    endpoints.MapControllerRoute(
                      name: "ForMultiLangRedirect",
                      pattern: "{*catchall}",
                      defaults: new
                      {
                          controller = "Home",
                          action = "ResourceNotFound"
                      });
                }
                else
                {
                    /************************DEFAULT*********************************************/

                    endpoints.MapControllerRoute(
                        name: "areaDefault",
                        pattern: "{area:exists}/{controller}/{action}/{id?}",
                         defaults: new { controller = "Home", action = "Index" }
                    );

                    endpoints.MapControllerRoute(
                    name: "login",
                    pattern: "Login",
                    defaults: new { controller = "Account", action = "Login" });



                    endpoints.MapControllerRoute(
                        name: "blogPost",
                        pattern: "blog/{slug}.html",
                        defaults: new { controller = "Post", action = "Index" });

                     endpoints.MapControllerRoute(
                        name: "blogCategory",
                        pattern: "blog/{slug}",
                        defaults: new { controller = "Category", action = "Index" });

                    endpoints.MapControllerRoute(
                        name: "blogPostIndex",
                        pattern: "blog",
                        defaults: new { controller = "Post", action = "Index" });

                   

                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller}/{action}/{id?}",
                         defaults: new { controller = "Home", action = "Index" }
                    );

                    endpoints.MapControllerRoute(
                        name: "cmsPage",
                        pattern: "{slug}",
                        defaults: new { controller = "CmsPage", action = "Index" });

                    endpoints.MapControllerRoute(
                        name: "MultiLangDefault",
                        pattern: "{lang:lang}/",
                        defaults: new { controller = "Home", action = "Index" }
                    );

                    endpoints.MapControllerRoute(
                     name: "ForMultiLangRedirect",
                     pattern: "{*catchall}",
                     defaults: new { controller = "Home", action = "ResourceNotFound" });
                }

            });

            return app;
        }
    }
}