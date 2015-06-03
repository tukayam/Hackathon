using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using Microsoft.WindowsAzure.Mobile.Service;
using OurMobileService.DataObjects;
using OurMobileService.Models;
using OurMobileService.BusinessLogic;

namespace OurMobileService.Controllers
{
    public class OrderController : TableController<Order>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Order>(context, Request, Services);
        }

        // GET tables/order/user
        public IQueryable<Order> GetOrdersForUser(User user)
        {
            return (from m in Query()
                    where m.User == user
                    select m);
        }

        // POST tables/order
        public async Task<IHttpActionResult> AddOrder(Order order)
        {
            Order current = await InsertAsync(order);

            var rewardCalc = new RewardGenerator();
            rewardCalc.Generate(order);

            return CreatedAtRoute("Tables", new { Id = current.Identifier }, current);
        }
    }
}