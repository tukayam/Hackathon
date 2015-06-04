using System;

namespace OurMobileService.Models
{
    public class Move
    {
        public Guid UserID { get; set; }
        public DateTime Time { get; set; }

        // Location data
        public int X { get; set; }
        public int Y { get; set; }
        public string ZoneID { get; set; }
        public string FloorID { get; set; }
        public string BuildingID { get; set; }
    }
}