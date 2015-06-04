using System;

namespace OurMobileService.Models
{
    public class Reward
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ZoneID { get; set; }  
        public RewardCategory RewardCategory { get; set; }
        public int PointsRequired { get; set; }
    }
}