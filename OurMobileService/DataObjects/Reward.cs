using Microsoft.WindowsAzure.Mobile.Service;
using System;

namespace OurMobileService.DataObjects
{
    public class Reward : EntityData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ZoneID { get; set; }        
        public Guid UserID { get; set; }
        public RewardCategory RewardCategory { get; set; }
    }
}