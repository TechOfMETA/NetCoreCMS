/*************************************************************
 *          Project: NetCoreCMS                              *
 *              Web: http://dotnetcorecms.org                *
 *           Author: OnnoRokom Software Ltd.                 *
 *          Website: www.onnorokomsoftware.com               *
 *            Email: info@onnorokomsoftware.com              *
 *        Copyright: OnnoRokom Software Ltd.                 *
 *          License: BSD-3-Clause                            *
 *************************************************************/

using System.Diagnostics;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace NetCoreCMS.Framework.Core.Mvc.Views
{
    public class NccRazorViewEngine : RazorViewEngine
    {
        public NccRazorViewEngine(IRazorPageFactoryProvider pageFactory,
                                  IRazorPageActivator pageActivator,
                                  HtmlEncoder htmlEncoder,
                                  IOptions<RazorViewEngineOptions> optionsAccessor,
                                  //RazorProject razorProject,
                                  ILoggerFactory loggerFactory,
                                  DiagnosticListener diagnosticSource) : 
            base(pageFactory,
                 pageActivator,
                 htmlEncoder,
                 optionsAccessor,
                 //razorProject,
                 loggerFactory,
                 diagnosticSource)
        {
           
        }
    }
}
