using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using MWSFBlazorFrontEnd.Data.Constants;
using Serilog;

namespace MWSFBlazorFrontEnd.Helpers
{
    public class JsInteropRunner
    {
        private readonly IJSRuntime _jsRuntime;

        public JsInteropRunner(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        internal async Task SetRadzenHtmlBgColor(string parentId, string color = CssConstants.Colors.BlueTriangleMatch)
        {
            color = color.StartsWith('#') ? color : $"#{color}"; //add # if needed
            try
            {
                await _jsRuntime.InvokeVoidAsync("setRadzenBgColor", parentId, color);
            }
            catch (Exception e)
            {
                Log.Warning("Error in running SetBgToCorrectValue", e.Message);
            }
        }

        public void Dispose()
        {
        }
    }
}
