using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MidwestSpeedfest.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MidwestSpeedfest.Pages.Staff
{
    public class StaffDetailsModel : PageModel
    {
        public readonly string DefaultDescription =
            @"<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec tincidunt est, ullamcorper sagittis urna. Suspendisse sed laoreet sem. Proin nec odio ac massa vehicula rhoncus. Etiam sit amet semper ipsum. Nunc vel metus vitae augue pellentesque ultrices. Integer mattis diam volutpat, venenatis libero vitae, fringilla ex. Nunc fringilla neque sed enim elementum, id consectetur augue convallis. Suspendisse dapibus felis ligula. Donec iaculis rhoncus eros, a lacinia tortor congue non. Etiam quis enim mi. Morbi bibendum mi id ante cursus, eget efficitur orci ornare. </p>

<p>Vestibulum molestie in elit quis molestie. Sed ullamcorper pretium mi, sed commodo turpis. Nam eu magna nec nulla semper luctus. Suspendisse non sem feugiat, aliquam erat ac, lobortis justo. Nulla tempus, ex id blandit volutpat, purus nulla pharetra velit, at dictum ex urna ut tortor. Nulla a orci sed orci maximus mattis ultricies sed mauris. Phasellus eleifend porta justo, sed dignissim dui hendrerit quis. Donec urna ante, tempus vitae posuere nec, ultrices in purus. Aenean lacus purus, dapibus sed dignissim sit amet, ultrices a neque. Ut nisl elit, viverra dapibus metus at, vulputate efficitur enim. Integer erat orci, elementum ultricies placerat sit amet, tristique vitae sapien. Integer egestas arcu id sapien egestas hendrerit.</p> ";
        public StaffModel StaffMember;
        [BindProperty(SupportsGet = true)] 
        public string Name { get; set; }

        public void OnGet()
        {
            try
            {
                StaffMember = GetStaffMemberFromJson();
                return;
            }
            catch
            {
                StaffMember = GetDefaultStaffMember();
            }
            StaffMember = GetDefaultStaffMember();
        }

        private StaffModel GetStaffMemberFromJson()
        {
            Dictionary<string, StaffModel> StaffDictionary;

            using (StreamReader reader = new StreamReader($@"wwwroot\Content\StaffBios\Staff.json"))
            {
                StaffDictionary = JsonConvert.DeserializeObject<Dictionary<string, StaffModel>>(reader.ReadToEnd());
            }

            var returnVal = StaffDictionary[Name];
            if (string.IsNullOrEmpty(returnVal.Description))
            {
                returnVal.Description = DefaultDescription;
            }

            return StaffDictionary[Name];
        }

        private StaffModel GetDefaultStaffMember()
        {
            return new StaffModel
            {
                DisplayName = "Phillip",
                Pronouns = "Balloon/Balloona",
                LogoUrl = "Phillip.jpg",
                Titles = new[] {"Head of Aeronautics"},
                Twitch = "midwestspeedfest",
                Twitter = "MWSpeedfest",
                Youtube = "channel/UCxZU3lVJEAW5P-PI9ozlqOg",
                SrcProfile = "midwestspeedfest",
                Description = DefaultDescription
            };
        }
    }
}