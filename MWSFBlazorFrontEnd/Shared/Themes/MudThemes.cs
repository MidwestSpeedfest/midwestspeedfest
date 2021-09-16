using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MudBlazor;

namespace MWSFBlazorFrontEnd.Shared.Themes
{
    public static class MudThemes
    {

        internal static MudTheme DefaultMudTheme { get; }
        public static MudTheme MidwestSpeedfest { get; }

        static MudThemes()
        {
            DefaultMudTheme = new MudTheme();
            MidwestSpeedfest = new MudTheme
            {
                LayoutProperties = new LayoutProperties(),
                Palette = new Palette
                {
                    Black = "#27272f",
                    Background = "#32333d",
                    BackgroundGrey = "#27272f",
                    Surface = "#373740",
                    DrawerBackground = "#55C6FF",
                    DrawerText = "rgba(255,255,255, 0.90)",
                    DrawerIcon = "rgba(255,255,255, 0.90)",
                    AppbarBackground = "#526FFF",
                    AppbarText = "rgba(255,255,255, 0.90)",
                    TextPrimary = "rgba(255,255,255, 0.90)",
                    TextSecondary = "rgba(255,255,255, 0.50)",
                    ActionDefault = "#adadb1",
                    ActionDisabled = "rgba(255,255,255, 0.26)",
                    ActionDisabledBackground = "rgba(255,255,255, 0.12)",
                    Divider = "rgba(255,255,255, 0.12)",
                    DividerLight = "rgba(255,255,255, 0.06)",
                    TableLines = "rgba(255,255,255, 0.12)",
                    LinesDefault = "rgba(255,255,255, 0.12)",
                    LinesInputs = "rgba(255,255,255, 0.3)",
                    TextDisabled = "rgba(255,255,255, 0.2)"
                },
                Shadows = new Shadow(),
                Typography = new Typography(),
                ZIndex = new ZIndex()
            };
        }

    }
}
