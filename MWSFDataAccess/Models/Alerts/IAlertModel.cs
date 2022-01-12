using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWSFDataAccess.Models.Alerts
{
    public interface IAlertModel
    {
        int Id { get; set; }
        DateTime? Created { get; set; }
        DateTime? Modified { get; set; }

        string Name { get; set; }
        string HtmlContent { get; set; }
        int Severity { get; set; }
        bool Active { get; set; }

    }
}
