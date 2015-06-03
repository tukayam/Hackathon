using Microsoft.WindowsAzure.Mobile.Service;
using System;

namespace OurMobileService.DataObjects
{
    public class Move : EntityData
    {
        public User User { get; set; }
        public Location Location { get; set; }
        public DateTime Time { get; set; }
    }
}