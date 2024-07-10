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
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Threading;
using NetCoreCMS.Framework.Core.App;
using System.Diagnostics;
using NetCoreCMS.Framework.Utility;
using NetCoreCMS.Framework.Setup;
using System.Text;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using System.Net.WebSockets;

namespace NetCoreCMS.Web
{
    public class Program
    {
        private static IWebHost nccWebHost;
        private static Thread starterThread = new Thread(StartApp);

        public static void Main(string[] args)
        {
            Console.WriteLine($"Launched from [Environment.CurrentDirectory]:\r\n\t\t{Environment.CurrentDirectory}");
            Console.WriteLine($"Physical location [AppDomain.CurrentDomain.BaseDirectory]:\r\n\t\t{AppDomain.CurrentDomain.BaseDirectory}");
            Console.WriteLine($"AppContext.BaseDir [AppContext.BaseDirectory]:\r\n\t\t{AppContext.BaseDirectory}");
            Console.WriteLine($"Runtime Call [MainModule.FileName]:\r\n\t\t{Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName)}");
            Console.WriteLine($"Current directory [Directory.GetCurrentDirectory()]:\r\n\t\t{Directory.GetCurrentDirectory()}");
            Console.WriteLine($"=======================================================================================");


            Console.OutputEncoding = Encoding.UTF8;
            NetCoreCmsHost.StartForerver(starterThread, new ParameterizedThreadStart(StartApp), Directory.GetCurrentDirectory(), args);
        }

        private static void StartApp(object argsObj)
        {
            BuildWebHost((string[])argsObj).Run();
        }

        //public static IHost BuildWebHostV8(string[] args)
        //{
        //    var builder = WebApplication.CreateBuilder(args);
        //    builder.Host.UseContentRoot(Directory.GetCurrentDirectory());
        //    var config = builder.Configuration;
        //    var startup = new Startup_V8(config, builder.Environment);
        //    startup.ConfigureServices(builder.Services);
        //    var app = builder.Build();
        //    startup.Configure(app);
        //    return app;
        //}

        public static IWebHost BuildWebHost(string[] args)
        {
            nccWebHost = WebHost.CreateDefaultBuilder(args)
                .UseKestrel(c => c.AddServerHeader = false)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseDefaultServiceProvider(options => options.ValidateScopes = false)
                //.AddApplicationInsightsTelemetry()
                .Build();
            return nccWebHost;
        }

        public static async Task RestartAppAsync()
        {
            await NetCoreCmsHost.StopAppAsync(nccWebHost);
        }

        public static async Task ShutdownAppAsync()
        {
            await NetCoreCmsHost.ShutdownAppAsync(nccWebHost);
        }
    }
}
