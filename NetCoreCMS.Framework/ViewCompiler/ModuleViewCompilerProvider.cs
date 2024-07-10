using System.Text;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.Extensions.Logging;

namespace NetCoreCMS.Framework.ViewCompiler
{
    public class ModuleViewCompilerProvider
     : IViewCompilerProvider
    {

        public ModuleViewCompilerProvider(ApplicationPartManager applicationPartManager, ILoggerFactory loggerFactory)
        {
            this.Compiler = new ModuleViewCompiler(applicationPartManager, loggerFactory);
        }

        protected IViewCompiler Compiler { get; }

        public IViewCompiler GetCompiler()
        {
            return this.Compiler;
        }

    }
}
