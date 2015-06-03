using Microsoft.WindowsAzure.Mobile.Service;
using System;

namespace OurMobileService.DataObjects
{
    public class Zone : EntityData
    {
        public string ZoneID { get; set; }
        public string Name { get; set; }
        public ZoneCategory ZoneCategory { get; set; }
        public bool IsQueueZone { get; set; }
    }
}