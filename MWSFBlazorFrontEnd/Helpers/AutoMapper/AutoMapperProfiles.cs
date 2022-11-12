using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MWSFBlazorFrontEnd.Models.Events;
using MWSFBlazorFrontEnd.Models.FrontPage;
using MWSFDataAccess.Models.Events;
using MWSFDataAccess.Models.FrontPage;

namespace MWSFBlazorFrontEnd.Helpers.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<FrontPageSettingsModel, DisplayFrontPageSettingsModel>();
            CreateMap<EventModel, EventDisplayModel>();
        }
    }
}
