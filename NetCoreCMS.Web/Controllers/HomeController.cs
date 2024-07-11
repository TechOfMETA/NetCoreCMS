/*************************************************************
 *          Project: NetCoreCMS                              *
 *              Web: http://dotnetcorecms.org                *
 *           Author: OnnoRokom Software Ltd.                 *
 *          Website: www.onnorokomsoftware.com               *
 *            Email: info@onnorokomsoftware.com              *
 *        Copyright: OnnoRokom Software Ltd.                 *
 *          License: BSD-3-Clause                            *
 *************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.Extensions.Logging;
using NetCoreCMS.Framework.Core.App;
using NetCoreCMS.Framework.Core.Mvc.Controllers;
using NetCoreCMS.Framework.i18n;
using NetCoreCMS.Framework.Setup;
using NetCoreCMS.Framework.Utility;

namespace NetCoreCMS.Web.Controllers
{
    public class HomeController : NccController
    {
        IHostingEnvironment _env;
        private readonly IControllerFactory _controllerFactory;
        private readonly IActionDescriptorCollectionProvider _adcProvider;
        private readonly IHttpContextFactory _httpContextFactory;
        private readonly IEnumerable<EndpointDataSource> _endpointSources;

        public HomeController(IHostingEnvironment env,
                              ILoggerFactory factory,
                              IControllerFactory controllerFactory,
                              IActionDescriptorCollectionProvider adcProvider,
                              IHttpContextFactory httpContextFactory,
                              IEnumerable<EndpointDataSource> endpointSources)
        {
            _logger = factory.CreateLogger<HomeController>();
            _env = env;
            _controllerFactory = controllerFactory;
            _adcProvider = adcProvider;
            _httpContextFactory = httpContextFactory;
            _endpointSources = endpointSources;

        }

        [AllowAnonymous]
        public IActionResult Index()
        {

            if (SetupHelper.IsDbCreateComplete && SetupHelper.IsAdminCreateComplete)
            {
                if (GlobalContext.SetupConfig == null)
                {
                    GlobalContext.SetupConfig = SetupHelper.LoadSetup();
                }

                var setupConfig = GlobalContext.SetupConfig;

                if (setupConfig == null)
                {
                    TempData["ErrorMessage"] = "Setup config file is missed. Please reinstall.";
                    return Redirect("~/CmsHome/ResourceNotFound");
                }
                if (setupConfig.StartupData.Trim('/') == "" || setupConfig.StartupData.Trim().ToLower() == "/home")
                {
                    return View();
                }

                var langEnabledUrl = NccUrlHelper.AddLanguageToUrl(CurrentLanguage, NccUrlHelper.EncodeUrl(setupConfig.StartupUrl));

                //string newQueryString = "";
                //string newPath = langEnabledUrl;
                //if (langEnabledUrl.Contains("?"))
                //{
                //    newPath = langEnabledUrl.Split('?')[0];
                //    newQueryString = langEnabledUrl.Split('?')[1];
                //}
                //List<object> parameters = new List<object>();
                //string url = langEnabledUrl;
                //var routeEndpoints = _endpointSources.SelectMany(es => es.Endpoints).OfType<RouteEndpoint>().ToList();
                //foreach (var ep in routeEndpoints)
                //{
                //    var routeValues = new RouteValueDictionary();
                //    var defaultValues = new RouteValueDictionary();
                //    var tm = new TemplateMatcher(TemplateParser.Parse(ep.RoutePattern.RawText), defaultValues);
                //    if (tm.TryMatch(newPath, routeValues))
                //    {
                //        string area = routeValues["area"]?.ToString();
                //        string controller = routeValues["controller"]?.ToString();
                //        string action = routeValues["action"]?.ToString();
                //        parameters.Add(new {ep.RoutePattern,ep.DisplayName, ep.Order, area, controller, action, routeValues });
                //    }
                //}
                //return Json(parameters);

                //if(setupConfig.StartupUrl.Trim(' ','/') =="CmsHome")
                //    return View()

                //IRouteCollection router = RouteData.Routers.OfType<IRouteCollection>().First();
                //HttpContext newHttpContext = _httpContextFactory.Create(HttpContext.Features);
                //newHttpContext.Request.Path = newPath;
                //newHttpContext.Request.QueryString = new QueryString(newQueryString);
                //var routeContext = new RouteContext(newHttpContext);
                ////router.RouteAsync(routeContext).Wait();
                //bool exists = routeContext.RouteData != null;
                //var newRouteData = new RouteData();
                var newActionDescriptor = new ControllerActionDescriptor();
                //ActionContext actionContext = new ActionContext(newHttpContext, newRouteData, newActionDescriptor);
                //if (exists)
                //{
                //    var newControllerContext = new ControllerContext(actionContext);
                //    var newController = (Controller)_controllerFactory.CreateController(newControllerContext);

                var routes = _adcProvider.ActionDescriptors.Items.Where(r => r is ControllerActionDescriptor).Cast<ControllerActionDescriptor>().ToList();
                //    object[] objects = new object[routes.Count];
                //    for (int i = 0; i < routes.Count; i++)
                //    {
                //        var r = routes[i];
                //        if (r is ControllerActionDescriptor)
                //        {
                //            var cad = (ControllerActionDescriptor)r;
                //            objects[i] = new { cad.ControllerName, cad.ActionName, Template = cad.AttributeRouteInfo?.Template };
                //        }
                //    }
                //    return Json(objects);
                //}

                return Redirect(langEnabledUrl);
            }


            return Redirect("/SetupHome/Index");
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult NotAuthorized()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult RedirectToDefaultLanguage()
        {
            var lang = CurrentLanguage;
            var redirectUrl = Request.Path.Value + "" + Request.QueryString;
            if (Request.Path.Value.StartsWith("/en") || Request.Path.Value.StartsWith("/bn"))
            {
                return Redirect("~" + redirectUrl);
            }
            return Redirect("~/" + lang + redirectUrl);
        }

        //[HttpPost]
        [AllowAnonymous]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            culture = culture.ToLower();
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            returnUrl = WebUtility.UrlDecode(returnUrl);

            if (!string.IsNullOrEmpty(returnUrl) && returnUrl.Length > 4)
            {
                if (!IsContainsLangPrefix(returnUrl))
                {
                    returnUrl = culture + returnUrl;
                }

                if (!IsStartedWithCurrentCulture(returnUrl, culture))
                {
                    if (returnUrl.StartsWith("/"))
                    {
                        returnUrl = returnUrl.Substring(3);
                    }
                    else
                    {
                        returnUrl = returnUrl.Substring(2);
                    }

                    returnUrl = culture + returnUrl;
                }
            }

            if (returnUrl.StartsWith("/") == false)
            {
                returnUrl = "/" + returnUrl;
            }

            returnUrl = NccUrlHelper.EncodeUrl(returnUrl);

            return Redirect(returnUrl);
        }

        private bool IsStartedWithCurrentCulture(string returnUrl, string culture)
        {
            if (returnUrl.ToLower().StartsWith(culture) || returnUrl.ToLower().StartsWith("/" + culture))
            {
                return true;
            }
            return false;
        }

        private bool IsContainsLangPrefix(string returnUrl)
        {
            foreach (var item in SupportedCultures.Cultures)
            {
                if (returnUrl.ToLower().StartsWith(item.TwoLetterISOLanguageName.ToLower()) || returnUrl.ToLower().StartsWith("/" + item.TwoLetterISOLanguageName.ToLower()))
                    return true;
            }
            return false;
        }

        [AllowAnonymous]
        public async System.Threading.Tasks.Task<ActionResult> SetupSuccess()
        {
            string referer = Request.Headers["Referer"].ToString();
            if (referer.EndsWith("/SetupHome/CreateAdmin"))
            {
                await Program.RestartAppAsync();
            }
            return View();
        }

        public async System.Threading.Tasks.Task<IActionResult> RestartHost()
        {
            string referer = Request.Headers["Referer"].ToString();
            NetCoreCmsHost.IsRestartRequired = true;
            await Program.RestartAppAsync();
            NetCoreCmsHost.IsRestartRequired = false;
            ViewBag.ReturnUrl = referer;
            ViewBag.ReturnUrlName = referer;

            if (referer.Trim() == "" || referer.Contains("RestartHost"))
            {
                ViewBag.ReturnUrl = "/";
                ViewBag.ReturnUrlName = "Home";
            }
            return View();
        }

        [AllowAnonymous]
        public IActionResult ResourceNotFound()
        {
            if (_env.IsDevelopment())
            {
                ViewData["ErrorMessage"] = "<strong style='color:black;font-family:Monda;'>Possible steps you may try:</strong><br/> 1. Build the modules after change. <br/>2. Restart <br/>3. Delete setup.json and setup the CMS again.";
            }
            return View();
        }
    }
}