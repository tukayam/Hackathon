using Microsoft.WindowsAzure.Mobile.Service;
using System;

namespace OurMobileService.DataObjects
{
    public class UserLocation : EntityData
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string floorID { get; set; }
        public string buildingID { get; set; }
        public Guid UserID { get; set; }
    }
}