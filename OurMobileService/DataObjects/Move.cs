using Microsoft.WindowsAzure.Mobile.Service;
using System;

namespace OurMobileService.DataObjects
{
    public class Move : EntityData
    {
        public Guid UserID { get; set; }
        public Guid LocationID { get; set; }
        public DateTime Time { get; set; }

        // Location data
        public int X { get; set; }
        public int Y { get; set; }
        public string ZoneID { get; set; }
        public string floorID { get; set; }
        public string buildingID { get; set; }
    }
}