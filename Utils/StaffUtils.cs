using System.Collections.Generic;
using System.IO;
using MidwestSpeedfest.Models;
using Newtonsoft.Json;

namespace MidwestSpeedfest.Utils
{
    public static class StaffUtils
    {
        public static readonly string DefaultDescription =
            @"<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec tincidunt est, ullamcorper sagittis urna. Suspendisse sed laoreet sem. Proin nec odio ac massa vehicula rhoncus. Etiam sit amet semper ipsum. Nunc vel metus vitae augue pellentesque ultrices. Integer mattis diam volutpat, venenatis libero vitae, fringilla ex. Nunc fringilla neque sed enim elementum, id consectetur augue convallis. Suspendisse dapibus felis ligula. Donec iaculis rhoncus eros, a lacinia tortor congue non. Etiam quis enim mi. Morbi bibendum mi id ante cursus, eget efficitur orci ornare. </p>

<p>Vestibulum molestie in elit quis molestie. Sed ullamcorper pretium mi, sed commodo turpis. Nam eu magna nec nulla semper luctus. Suspendisse non sem feugiat, aliquam erat ac, lobortis justo. Nulla tempus, ex id blandit volutpat, purus nulla pharetra velit, at dictum ex urna ut tortor. Nulla a orci sed orci maximus mattis ultricies sed mauris. Phasellus eleifend porta justo, sed dignissim dui hendrerit quis. Donec urna ante, tempus vitae posuere nec, ultrices in purus. Aenean lacus purus, dapibus sed dignissim sit amet, ultrices a neque. Ut nisl elit, viverra dapibus metus at, vulputate efficitur enim. Integer erat orci, elementum ultricies placerat sit amet, tristique vitae sapien. Integer egestas arcu id sapien egestas hendrerit.</p> ";

        public static StaffModel GetStaffMemberFromJson(string key)
        {
            Dictionary<string, StaffModel> staffDictionary;

            using (StreamReader reader = new StreamReader($@"wwwroot\Content\StaffBios\Staff.json"))
            {
                staffDictionary = JsonConvert.DeserializeObject<Dictionary<string, StaffModel>>(reader.ReadToEnd());
            }

            var returnVal = staffDictionary[key];
            if (string.IsNullOrEmpty(returnVal.Description))
            {
                returnVal.Description = DefaultDescription;
            }

            return returnVal;
        }

        public static StaffModel GetDefaultStaffMember()
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