﻿using Microsoft.WindowsAzure.Mobile.Service;
using System;

namespace OurMobileService.DataObjects
{
    public class Campaign : EntityData
    {
        public Guid Identifier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid LocationID { get; set; }

        public int sth { get; set; }
    }
}