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
            //var app = (WebApplication)_app;
            //if (SetupHelper.IsAdminCreateComplete && GlobalContext.WebSite.IsMultiLangual)
            //{
            //    app.MapControllerRoute(
            //        name: "multiLangualAreaDefault",
            //        pattern: "{area:exists}/{controller:slugify=Home}/{action:slugify=Index}/{id?}"
            //    );

            //    app.MapControllerRoute(
            //          name: "multiLangualAreaDefaultWithLang",
            //          pattern: "{lang:lang}/{area:exists}/{controller:slugify}/{action:slugify}/{id?}",
            //          defaults: new { controller = "Home", action = "Index" }
            //      );

            //    app.MapControllerRoute(
            //         name: "MultiLangAnyControlerAction",
            //         pattern: "{lang:lang}/{controller:slugify}/{action:slugify}/{id?}",
            //         defaults: new { controller = "Home", action = "Index" }
            //     );

            //    app.MapControllerRoute(
            //        name: "MultiLangCmsPage",
            //        pattern: "{lang:lang}/{slug?}",
            //        defaults: new { controller = "CmsPage", action = "Index" });

            //    app.MapControllerRoute(
            //         name: "MultiLangBlogPost",
            //         pattern: "{lang:lang}/post/{slug?}",
            //         defaults: new { controller = "Post", action = "Index" });

            //    app.MapControllerRoute(
            //          name: "MultiLangBlogCategory",
            //          pattern: "{lang:lang}/category/{slug?}",
            //          defaults: new { controller = "Category", action = "Index" });

            //    app.MapControllerRoute(
            //       name: "login",
            //       pattern: "Login",
            //       defaults: new { controller = "Account", action = "Login" }
            //   );

            //    app.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller:slugify}/{action:slugify}/{id?}",
            //         defaults: new { controller = "Home", action = "Index" }
            //    );

            //    app.MapControllerRoute(
            //         name: "cmsPage",
            //         pattern: "{slug}",
            //         defaults: new { controller = "CmsPage", action = "Index" });

            //    app.MapControllerRoute(
            //        name: "blogPost",
            //        pattern: "post/{slug?}",
            //        defaults: new { controller = "Post", action = "Index" });

            //    app.MapControllerRoute(
            //       name: "blogCategory",
            //       pattern: "category/{slug?}",
            //       defaults: new { controller = "Category", action = "Index" });

            //    app.MapControllerRoute(
            //        name: "MultiLangDefault",
            //        pattern: "{lang:lang}/",
            //        defaults: new { controller = "Home", action = "Index" }
            //    );

            //    app.MapControllerRoute(
            //      name: "ForMultiLangRedirect",
            //      pattern: "{*catchall}",
            //      defaults: new { controller = "Home", action = "ResourceNotFound" });
            //}
            //else
            //{
            //    app.MapControllerRoute(
            //        name: "areaDefault",
            //        pattern: "{area:exists}/{controller:slugify}/{action:slugify}/{id?}",
            //         defaults: new { controller = "Home", action = "Index" }
            //    );

            //    app.MapControllerRoute(
            //    name: "login",
            //    pattern: "Login",
            //    defaults: new { controller = "Account", action = "Login" });

            //    app.MapControllerRoute(
            //          name: "default",
            //          pattern: "{controller:slugify}/{action:slugify}/{id?}",
            //           defaults: new { controller = "Home", action = "Index" }
            //      );

            //    app.MapControllerRoute(
            //        name: "cmsPage",
            //        pattern: "{slug}",
            //        defaults: new { controller = "CmsPage", action = "Index" });

            //    app.MapControllerRoute(
            //        name: "blogPost",
            //        pattern: "post/{slug?}",
            //        defaults: new { controller = "Post", action = "Index" });

            //    app.MapControllerRoute(
            //         name: "blogCategory",
            //         pattern: "category/{slug?}",
            //         defaults: new { controller = "Category", action = "Index" });

            //    app.MapControllerRoute(
            //         name: "MultiLangDefault",
            //         pattern: "{lang:lang}/",
            //         defaults: new { controller = "Home", action = "Index" }
            //     );

            //    app.MapControllerRoute(
            //     name: "ForMultiLangRedirect",
            //     pattern: "{*catchall}",
            //     defaults: new { controller = "Home", action = "ResourceNotFound" });
            //}
            //return app;

            app.UseMvc(routes =>
            {
                if (SetupHelper.IsAdminCreateComplete && GlobalContext.WebSite.IsMultiLangual)
                {
                    routes.MapRoute(
                        name: "multiLangualAreaDefault",
                        template: "{area:exists}/{controller:slugify=Home}/{action:slugify=Index}/{id?}",
                         defaults: new { controller = "Home", action = "Index" }
                    );

                    routes.MapRoute(
                        name: "multiLangualAreaDefaultWithLang",
                        template: "{lang:lang}/{area:exists}/{controller:slugify}/{action:slugify}/{id?}",
                        defaults: new { controller = "Home", action = "Index" }
                    );

                    routes.MapRoute(
                        name: "MultiLangAnyControlerAction",
                        template: "{lang:lang}/{controller:slugify}/{action:slugify}/{id?}",
                        defaults: new { controller = "Home", action = "Index" }
                    );

                    routes.MapRoute(
                        name: "MultiLangCmsPage",
                        template: "{lang:lang}/{slug?}",
                        defaults: new { controller = "CmsPage", action = "Index" });

                    routes.MapRoute(
                        name: "MultiLangBlogPost",
                        template: "{lang:lang}/post/{slug?}",
                        defaults: new { controller = "Post", action = "Index" });

                    routes.MapRoute(
                        name: "MultiLangBlogCategory",
                        template: "{lang:lang}/category/{slug?}",
                        defaults: new { controller = "Category", action = "Index" });

                    routes.MapRoute(
                        name: "login",
                        template: "Login",
                        defaults: new { controller = "Account", action = "Login" }
                    );

                    routes.MapRoute(
                        name: "default",
                        template: "{controller:slugify}/{action:slugify}/{id?}",
                         defaults: new { controller = "Home", action = "Index" }
                    );

                    routes.MapRoute(
                        name: "cmsPage",
                        template: "{slug}",
                        defaults: new { controller = "CmsPage", action = "Index" });

                    routes.MapRoute(
                        name: "blogPost",
                        template: "post/{slug?}",
                        defaults: new { controller = "Post", action = "Index" });

                    routes.MapRoute(
                        name: "blogCategory",
                        template: "category/{slug?}",
                        defaults: new { controller = "Category", action = "Index" });

                    routes.MapRoute(
                        name: "MultiLangDefault",
                        template: "{lang:lang}/",
                        defaults: new { controller = "Home", action = "Index" }
                    );

                    routes.MapRoute(
                      name: "ForMultiLangRedirect",
                      template: "{*catchall}",
                      defaults: new { controller = "Home", action = "ResourceNotFound" });
                }
                else
                {
                    routes.MapRoute(
                        name: "areaDefault",
                        template: "{area:exists}/{controller:slugify}/{action:slugify}/{id?}",
                         defaults: new { controller = "Home", action = "Index" }
                    );

                    routes.MapRoute(
                    name: "login",
                    template: "Login",
                    defaults: new { controller = "Account", action = "Login" });

                    routes.MapRoute(
                        name: "default",
                        template: "{controller:slugify}/{action:slugify}/{id?}",
                         defaults: new { controller = "Home", action = "Index" }
                    );

                    routes.MapRoute(
                        name: "cmsPage",
                        template: "{slug}",
                        defaults: new { controller = "CmsPage", action = "Index" });

                    routes.MapRoute(
                        name: "blogPost",
                        template: "post/{slug?}",
                        defaults: new { controller = "Post", action = "Index" });

                    routes.MapRoute(
                        name: "blogCategory",
                        template: "category/{slug?}",
                        defaults: new { controller = "Category", action = "Index" });

                    routes.MapRoute(
                        name: "MultiLangDefault",
                        template: "{lang:lang}/",
                        defaults: new { controller = "Home", action = "Index" }
                    );

                    routes.MapRoute(
                     name: "ForMultiLangRedirect",
                     template: "{*catchall}",
                     defaults: new { controller = "Home", action = "ResourceNotFound" });
                }
            });
            return app;
        }
    }
}
