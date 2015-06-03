using System.Linq;
using System.Web.Http.Controllers;
using Microsoft.WindowsAzure.Mobile.Service;
using OurMobileService.DataObjects;
using OurMobileService.Models;

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
        public IQueryable<Reward> GetRewardsForUser(User user)
        {
            return (from m in Query()
                    where m.User == user
                    select m);
        }
    }
}