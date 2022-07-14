
using NUnit.Framework;
using Moq;
using MWSFBlazorFrontEnd.Models.Users;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using MWSFBlazorFrontEnd.Data.Constants;

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
            identityUser = new IdentityUser();
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
    }
}
