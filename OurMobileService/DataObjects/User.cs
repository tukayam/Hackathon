﻿using Microsoft.WindowsAzure.Mobile.Service;
using System.Collections.Generic;

namespace OurMobileService.DataObjects
{
    public class User : EntityData
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public List<Reward> Rewards { get; set; }
    }
}