
using NUnit.Framework;
using Moq;
using MWSFBlazorFrontEnd.Models.Users;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using MWSFBlazorFrontEnd.Data.Constants;
using System.Linq;

namespace MWSFTest.DisplayTests.Models.Users
{
    public class UserDisplayModelTests
    {
        private Mock<UserDisplayModel> mockSut;
        private UserDisplayModel sut;
        private List<string> currentRoles;
        private List<string> changedRoles;

        [SetUp]
        public void SetUp()
        {
            currentRoles = new List<string>();
            changedRoles = new List<string>();

            mockSut = new Mock<UserDisplayModel>();
            mockSut.Setup(x => x.GetSelectedRolesFromChips()).Returns(() => changedRoles);
            sut = mockSut.Object;
        }

        [Test]
        public async Task AddsAndRemovesCorrectRoles()
        {
            sut.Changed = true;
            currentRoles.AddRange(new List<string> { "role", "role2" });
            sut.SelectedRoles = currentRoles;
            changedRoles.AddRange(new List<string> { "role", "role3", "role4" });

            await mockSut.Object.SaveRolesAsync();
            var roleCount = sut.SelectedRoles.Count;

            Assert.False(sut.Changed, "Changed flag should be false after save");
            Assert.True(roleCount == 3, $"Contains correct number of roles 3 expected {roleCount}");
            Assert.True(sut.SelectedRoles.Contains("role4"), "Contains correct roles after save");
            Assert.False(sut.SelectedRoles.Contains("role2"), "Does not contain undesired role after save");
        }

        [Test]
        public async Task CantAddStaffAsNonAdmin()
        {
            sut.Changed = true;
            sut.SelectedRoles = new List<string> { RoleConstants.RoleNames.Volunteer };
            changedRoles = new List<string> { RoleConstants.RoleNames.Staff, RoleConstants.RoleNames.Volunteer };
            bool isAdmin = false;

            await sut.SaveRolesAsync(isAdmin);
            var roleCount = sut.SelectedRoles.Count;

            Assert.False(sut.Changed, "Changed flag should be false after save");
            Assert.True(roleCount == 1, $"Contains correct number of roles: 1 expected, found {roleCount}");
            Assert.True(sut.SelectedRoles.Contains(RoleConstants.RoleNames.Volunteer), "Did not remove nonstaff role");
            Assert.False(sut.SelectedRoles.Contains(RoleConstants.RoleNames.Staff), "Did not add Staff Role without permission");
        }

        [Test]
        public async Task CanAddStaffRoleAsAdmin()
        {
            sut.Changed = true;
            sut.SelectedRoles = new List<string> { RoleConstants.RoleNames.Volunteer };
            changedRoles = new List<string> { RoleConstants.RoleNames.Staff, RoleConstants.RoleNames.Volunteer };
            bool isAdmin = true;

            await sut.SaveRolesAsync(isAdmin);
            var roleCount = sut.SelectedRoles.Count;

            Assert.False(sut.Changed, "Changed flag should be false after save");
            Assert.True(roleCount == 2, $"Contains correct number of roles: 2 expected, found {roleCount}");
            Assert.True(sut.SelectedRoles.Contains(RoleConstants.RoleNames.Volunteer), "Did not remove nonstaff role");
            Assert.True(sut.SelectedRoles.Contains(RoleConstants.RoleNames.Staff), "Did not add Staff Role without permission");
        }


        [Test]
        public async Task WillNotUpdateUnchangedUser()
        {
            sut.Changed = false;
            sut.SelectedRoles = new List<string> { "Pesto" };
            changedRoles = new List<string> { "Pesto", "Dabesto" };

            await sut.SaveRolesAsync();
            var roleCount = sut.SelectedRoles.Count;

            Assert.False(sut.Changed, "Changed flag should stay as false");
            Assert.True(roleCount == 1, $"Contains correct number of roles: 1 expected, found {roleCount}");
            Assert.True(sut.SelectedRoles.Contains("Pesto"), "Did not remove any roles");
            Assert.False(sut.SelectedRoles.Contains("Dabesto"), "Did not add any roles");
        }

        [Test]
        public void FindsUserIsAdmin()
        {
            sut.SelectedRoles = new List<string> { RoleConstants.RoleNames.Admin };

            var result = sut.IsAdmin();

            Assert.True(result, "User found to be admin");
        }

        [Test]
        public void FindsNonAdmin()
        {
            var nonAdminRoles = RoleConstants.RoleNamesList;
            nonAdminRoles.Remove(RoleConstants.RoleNames.Admin);
            sut.SelectedRoles = nonAdminRoles;

            var result = sut.IsAdmin();

            Assert.False(result, "User not found to be admin");
        }

        [Test]
        public void FindsUserIsStaff()
        {
            sut.SelectedRoles = new List<string> { RoleConstants.RoleNames.Staff };

            var result = sut.IsStaff();

            Assert.True(result, "User found to be Staff");
        }

        [Test]
        public void FindsNonStaff()
        {
            var nonStaffRoles = RoleConstants.RoleNamesList;
            nonStaffRoles.Remove(RoleConstants.RoleNames.Staff);
            sut.SelectedRoles = nonStaffRoles;

            var result = sut.IsStaff();

            Assert.False(result, "User not found to be Staff");
        }

        [Test]
        public void FindsStaffOrAdmin()
        {
            sut.SelectedRoles = new List<string> { RoleConstants.RoleNames.Staff };

            var result = sut.IsStaffOrAdmin();

            Assert.True(result, "User found to be Staff in Staff or Admin");

            sut.SelectedRoles = new List<string> { RoleConstants.RoleNames.Admin };

            result = sut.IsStaffOrAdmin();

            Assert.True(result, "User found to be Admin in Staff or Admin");

            sut.SelectedRoles = new List<string> { RoleConstants.RoleNames.Admin, RoleConstants.RoleNames.Staff };

            result = sut.IsStaffOrAdmin();

            Assert.True(result, "User found to be Admin AND Staff in Staff or Admin");
        }

        [Test]
        public void FindsNonStaffOrAdmin()
        {
            var staffOrAdminRoles = new List<string> { RoleConstants.RoleNames.Admin, RoleConstants.RoleNames.Staff };
         
            sut.SelectedRoles = RoleConstants.RoleNamesList.Except(staffOrAdminRoles).ToList();

            var result = sut.IsStaffOrAdmin();

            Assert.False(result, "User not found to be admin");
        }

        [Test]
        public void UserIsInRole()
        {
            var roleToTest = RoleConstants.RoleNames.User;
            sut.SelectedRoles = new List<string> { roleToTest };

            var result = sut.IsInRole(roleToTest);

            Assert.True(result, "User is found to be in expected role.");
        }

        [Test]
        public void UserIsNotInRole()
        {
            var roleToRemove =  RoleConstants.RoleNames.User;
            sut.SelectedRoles = RoleConstants.RoleNamesList.Except(new List<string> { roleToRemove }).ToList();

            var result = sut.IsInRole(roleToRemove);

            Assert.False(result, "User is found not to be in role (as expected)");
        }
    }
}
