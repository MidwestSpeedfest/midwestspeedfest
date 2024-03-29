﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWSFDataAccess.Models.Events
{
    public interface IEventModel : IDatabaseModel
    {
        string Name { get; set; }
        DateTime EventStart { get; set; }
        DateTime EventEnd { get; set; }
        double MoneyRaised { get; set; }
        string CharityName { get; set; }
        string YouTubeLink { get; set; }
    }
}
