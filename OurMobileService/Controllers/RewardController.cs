using System.Linq;
using System.Web.Http.Controllers;
using System;
using System.Web.Http;
using OurMobileService.Models;
using OurMobileService.App_Start;
using System.Collections.Generic;

namespace OurMobileService.Controllers
{
    public class RewardController : ApiController
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
        }

        // GET api/move
        public IEnumerable<Reward> GetRewardsForUser(Guid userID)
        {
            User user = (from m in APIContext.Users
                         where m.Id == userID
                         select m).FirstOrDefault();

            return user != null ? user.Rewards : new List<Reward>();
        }
    }
}