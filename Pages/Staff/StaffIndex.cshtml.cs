using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MidwestSpeedfest.Models;
using MidwestSpeedfest.Utils;

namespace MidwestSpeedfest.Pages.Staff
{
    public class StaffIndexModel : PageModel
    {
        public Dictionary<string, StaffModel> StaffDictionary { get; private set; }

        public StaffIndexModel()
        {
            StaffDictionary = StaffUtils.GetStaffDictionary();
        }

        public void OnGet()
        {

        }
    }
}