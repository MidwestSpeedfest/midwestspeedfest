using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MudBlazor;
using MudBlazor.Extensions;

namespace MWSFBlazorFrontEnd.Helpers.CssHelpers
{
    public static class MudBlazorCssUtil
    {

        public static string SeverityToCssString(int severityNum)
        {
            return SeverityToCssString((Severity)severityNum);
        }

        public static string SeverityToCssString(Severity severity)
        {
            return $"mud-alert-{severity.ToDescriptionString()}";
        }
    }
}
