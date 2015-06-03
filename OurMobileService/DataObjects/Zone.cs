using Microsoft.WindowsAzure.Mobile.Service;
using System;

namespace OurMobileService.DataObjects
{
    public class Zone : EntityData
    {
        public Guid Identifier { get; set; }
        public string ZoneID { get; set; }
        public string Name { get; set; }
        public ZoneCategory ZoneCategory { get; set; }

        // Just for the demo, to keep this simple
        public bool IsNoGoZone{ get; set; }
        public bool IsBonusZone { get; set; } // You (only) get points when you are in a bonus zone

    }
}