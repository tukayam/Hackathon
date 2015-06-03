using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using Microsoft.WindowsAzure.Mobile.Service;
using OurMobileService.DataObjects;
using OurMobileService.Models;
using System;

namespace OurMobileService.Controllers
{
    public class MoveController : TableController<Move>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Move>(context, Request, Services);
        }

        // GET tables/move/{user}
        public IQueryable<Move> GetMovesForUser(Guid userIdentifier)
        {
            return (from m in Query()
                    where m.UserID == userIdentifier && m.Time > DateTime.Now.AddHours(-1)
                    select m);
        }

        // POST tables/move
        public async Task<IHttpActionResult> AddMove(Move move)
        {
            Move current = await InsertAsync(move);
            return CreatedAtRoute("Tables", new { userId = current.UserID }, current);
        }
    }
}