using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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