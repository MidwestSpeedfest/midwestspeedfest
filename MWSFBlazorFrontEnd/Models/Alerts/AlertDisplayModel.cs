using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        [StringLength(50, ErrorMessage = "Name must be at most 50 characters")]
        public string Name { get; set; }
        [Required]
        public string HtmlContent { get; set; }

        public int Severity { get; set; }
        public bool Active { get; set; }
    }
}
