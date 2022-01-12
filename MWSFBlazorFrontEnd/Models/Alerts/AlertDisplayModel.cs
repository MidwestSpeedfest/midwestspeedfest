using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MudBlazor;
using MWSFBlazorFrontEnd.Helpers.CustomDataValidators;
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

        [Required]
        [IsWithinEnumValidator(EnumToCheck = typeof(Severity))]
        public int Severity
        {
            get => Severity;
            set
            {
                if (Enum.IsDefined(typeof(Severity), value))
                {
                    Severity = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"value '{value}' is out of range for MudBlazor severity");
                }
            }
        }

        [Required]
        public bool Active { get; set; }
    }
}
