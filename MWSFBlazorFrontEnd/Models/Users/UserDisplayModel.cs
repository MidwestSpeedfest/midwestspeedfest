using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MudBlazor;

namespace MWSFBlazorFrontEnd.Models.Users
{
    public class UserDisplayModel
    {
        internal IdentityUser User { get; set; }
        internal List<string> SelectedRoles { get; set; }
        internal MudChip[] SelectedRoleChips { get; set; }
        internal bool Changed = false;
        private UserManager<IdentityUser> _userManager;

        public static UserDisplayModel Create(IdentityUser user, List<string> roles)
        {
            UserDisplayModel udm = new UserDisplayModel(); 
            udm.Initialize(user, roles);
            return udm;
        }

        public static async Task<UserDisplayModel> CreateAsync(UserManager<IdentityUser> userManager, string userName)
        {
            UserDisplayModel udm = new UserDisplayModel();
            await udm.InitializeAsync(userManager, userName);
            return udm;
        }

        public static async Task<UserDisplayModel> CreateAsync(UserManager<IdentityUser> userManager, IdentityUser user)
        {
            UserDisplayModel udm = new UserDisplayModel();
            await udm.InitializeAsync(userManager, user.UserName);
            return udm;
        }


        private async Task InitializeAsync(UserManager<IdentityUser> userManager, string userName)
        {
            _userManager = userManager;
            User = await _userManager.FindByNameAsync(userName);
            var roles = await _userManager.GetRolesAsync(User);
            SelectedRoles = roles.ToList();
        }

        private async Task InitializeAsync(UserManager<IdentityUser> userManager, IdentityUser user)
        {
            User = user;
            var roles = await userManager.GetRolesAsync(User);
            SelectedRoles = roles.ToList();
        }

        private void Initialize(IdentityUser user, List<string> roles)
        {
            User = user;
            SelectedRoles = roles;
        }

        // make sure no one but the Create function can call the constructor:
        private UserDisplayModel()
        { }

    }
}
