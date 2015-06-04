using OurMobileService.App_Start;
using OurMobileService.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace OurMobileService.Controllers
{
    public class ZoneController : ApiController
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
        }

        // GET api/zone?queuezones=true
        public IEnumerable<Zone> GetZones(bool queueZones)
        {
            return queueZones ?
                (from z in APIContext.Zones
                 where z.IsQueueZone == true
                 select z) : APIContext.Zones;
        }

    }
}
