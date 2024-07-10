using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;

namespace NetCoreCMS.Framework.Helpers.UrlHelpers
{

    public class SlugifyParameterTransformer : IOutboundParameterTransformer
    {
        //https://stackoverflow.com/questions/36358751/how-do-you-enforce-lowercase-routing-in-asp-net-core
        //From ASP.NET Core 2.2, along with lowercase you can also make your route dashed
        //using ConstraintMap which will make your route /Employee/EmployeeDetails/1 to /employee/employee-details/1
        //instead of /employee/employeedetails/1.
        public string TransformOutbound(object value)
        {
            // Slugify value
            return value == null ? null : Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1-$2").ToLower();
        }
    }
}
