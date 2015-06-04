using OurMobileService.App_Start;
using OurMobileService.Models;
using System;
using System.Linq;

namespace OurMobileService.BusinessLogic
{
    public class RewardTracker
    {
        public void Track(Guid userId, string zoneId)
        {

            Zone zone = (from z in APIContext.Zones
                         where z.Id == zoneId
                         select z).FirstOrDefault();

            if (zone != null && zone.IsQueueZone == false)
            {
                User user = (from u in APIContext.Users
                             where u.Id == userId
                             select u).FirstOrDefault();

                user.Points += 10;
                if (user != null)
                {
                    Reward reward = (from r in APIContext.Rewards
                                     where r.PointsRequired < user.Points
                                     select r).FirstOrDefault();

                    if (reward != null)
                    {
                        user.Rewards.Add(reward);
                    }
                }

            }
        }
    }
}
