using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MudBlazor;
using MWSFBlazorFrontEnd.Data.Constants;
using Serilog;

namespace MWSFBlazorFrontEnd.Models.Users
{
    public class UserDisplayModel
    {
        internal IdentityUser User { get; set; }
        public List<string> SelectedRoles { get; set; }
        internal MudChip[] SelectedRoleChips { get; set; }
        public bool Changed = false;
        private UserManager<IdentityUser> _userManager;

        public static UserDisplayModel Create(UserManager<IdentityUser> userManager, IdentityUser user, List<string> roles)
        {
            UserDisplayModel udm = new UserDisplayModel(); 
            udm.Initialize(userManager, user, roles);
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

        private void Initialize(UserManager<IdentityUser> userManager, IdentityUser user, List<string> roles)
        {
            _userManager = userManager;
            User = user;
            SelectedRoles = roles;
        }

        /// <summary>
        /// Empty constructor used for unit tests
        /// </summary>
        /// 
        public UserDisplayModel()
        {
            SelectedRoles = new List<string>();
        }
        
        /// <summary>
        /// Parameterized constructor used for unit tests only.
        /// </summary>
        /// <param name="roles"></param>
        public UserDisplayModel(List<string> roles)
        { SelectedRoles = roles; }

        public async Task SaveRolesAsync(bool isAdmin = false)
        {
            if (Changed) //Only alter changed users
            {
                
                //Set up roles to add / remove
                var checkedRolesNames = GetSelectedRolesFromChips().Where(x => x != RoleConstants.RoleNames.Admin);
                var rolesToAdd = isAdmin ? checkedRolesNames.Except(SelectedRoles) :
                    checkedRolesNames.Except(SelectedRoles).Except(RoleConstants.ProtectedRoles);
                var rolesToRemove = isAdmin ? SelectedRoles.Except(checkedRolesNames) :
                    SelectedRoles.Except(checkedRolesNames).Except(RoleConstants.ProtectedRoles);            

                //Add missing roles
                if (rolesToAdd.Any())
                {
                    foreach (var role in rolesToAdd)
                    {
                        await AddRole(role);
                    }
                }

                //Remove any unselected roles
                if (SelectedRoles.Any() && rolesToRemove.Any())
                {
                    foreach (var role in rolesToRemove)
                    {
                        await RemoveRole(role);
                    }
                }

                //Update in-memory list for model and reset changed flag
                SelectedRoles = isAdmin ? checkedRolesNames.Except(rolesToRemove).ToList() :
                    checkedRolesNames.Except(rolesToRemove).Except(RoleConstants.ProtectedRoles).ToList();
                Changed = false;
            }

        }

        public virtual async Task AddRole(string role)
        {
            try
            {
                await _userManager.AddToRoleAsync(User, role);
            }
            catch (Exception e)
            {
                Log.Error($"Error when saving user {User.UserName} : {e.Message}");
            }
        }

        public virtual async Task RemoveRole(string role)
        {
            try
            {
                await _userManager.RemoveFromRoleAsync(User, role);
            }
            catch (Exception e)
            {
                Log.Error($"Error when saving user {User.UserName} : {e.Message}");
            }
        }

        public virtual List<string> GetSelectedRolesFromChips()
        {
            return SelectedRoleChips.Select(x => x.Text).ToList();
        }

    }
}
