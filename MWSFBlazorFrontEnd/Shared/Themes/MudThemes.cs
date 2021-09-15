using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MudBlazor;

namespace MWSFBlazorFrontEnd.Shared.Themes
{
    internal static class MudThemes
    {

        internal static MudTheme DefaultMudTheme { get; }

        static MudThemes()
        {
            DefaultMudTheme = new MudTheme();
        }

    }
}
