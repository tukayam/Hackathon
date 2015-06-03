using Microsoft.WindowsAzure.Mobile.Service;
using System;

namespace OurMobileService.DataObjects
{
    public class Reward : EntityData
    {
        public Guid Identifier { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public string Description { get; set; }
        public Campaign Campaign { get; set; }
        public User User { get; set; }
    }
}