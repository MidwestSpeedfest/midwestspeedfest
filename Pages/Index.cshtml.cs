using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MidwestSpeedfest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly List<string> _twitchEmbedParents = new List<string>()
        {
            "www.midwestspeedfest.com",
            "midwestspeedfest.com",
            "localhost"
        };

        public string TwitchEmbedParentString = "&parent=www.midwestspeedfest.com&parent=midwestspeedfest.com&parent=localhost";

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        private string BuildParentString()
        {
            var sb = new StringBuilder();
            foreach (var parent in _twitchEmbedParents)
            {
                sb.Append($"&parent={parent}");
            }

            return sb.ToString();
        }
    }
}
