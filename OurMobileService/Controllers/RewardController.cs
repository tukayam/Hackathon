using System.Linq;
using System.Web.Http.Controllers;
using Microsoft.WindowsAzure.Mobile.Service;
using OurMobileService.DataObjects;
using OurMobileService.Models;
using System;

namespace OurMobileService.Controllers
{
    public class RewardController : TableController<Reward>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Reward>(context, Request, Services);
        }

        // GET tables/move
        public IQueryable<Reward> GetRewardsForUser(Guid userID)
        {
            return (from m in Query()
                    where m.UserID == userID
                    select m);
        }
    }
}