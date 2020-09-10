using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MidwestSpeedfest.Models;
using MidwestSpeedfest.Utils;

namespace MidwestSpeedfest.Pages.Staff
{
    public class StaffDetailsModel : PageModel
    {
        
        public StaffModel StaffMember;

        [BindProperty(SupportsGet = true)] 
        public string Name { get; set; }

        public void OnGet()
        {
            try
            {
                StaffMember = StaffUtils.GetStaffMemberFromJson(Name);
                return;
            }
            catch
            {
                StaffMember = StaffUtils.GetDefaultStaffMember();
            }
            StaffMember = StaffUtils.GetDefaultStaffMember();
        }
    }
}