using Microsoft.WindowsAzure.Mobile.Service;
using System;

namespace OurMobileService.DataObjects
{
    public class Reward : EntityData
    {
        public Guid Identifier { get; set; }
        public string Name { get; set; }
        public Guid LocationID { get; set; }
        public string Description { get; set; }
        public Guid CampaignID { get; set; }
        public Guid UserID { get; set; }
    }
}