using Microsoft.WindowsAzure.Mobile.Service;
using System;

namespace OurMobileService.DataObjects
{
    public class Location : EntityData
    {
        public Guid Identifier { get; set; }
        public string Name { get; set; }
        public Beacon Beacon { get; set; }
        public LocationCategory LocationCategory { get; set; }
    }
}