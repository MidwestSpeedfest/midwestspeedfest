using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MWSFDataAccess.Models.Alerts;

namespace MWSFBlazorFrontEnd.Models.Alerts
{
    public class AlertDisplayModel : IAlertModel
    {
        public int Id { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public string Name { get; set; }
        public string HtmlContent { get; set; }
        public string Severity { get; set; }
        public bool Active { get; set; }
    }
}
