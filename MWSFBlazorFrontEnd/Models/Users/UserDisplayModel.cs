using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using MudBlazor;

namespace MWSFBlazorFrontEnd.Models.Users
{
    public class UserDisplayModel
    {
        internal IdentityUser User { get; set; }
        internal List<string> SelectedRoles { get; set; }
        internal MudChip[] SelectedRoleChips { get; set; }

    }
}
