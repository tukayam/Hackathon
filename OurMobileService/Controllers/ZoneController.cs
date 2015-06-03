using Microsoft.WindowsAzure.Mobile.Service;
using OurMobileService.DataObjects;
using OurMobileService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace OurMobileService.Controllers
{
    public class ZoneController : TableController<Zone>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            var context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Zone>(context, Request, Services);
        }

        // GET tables/zone?queuezones=true
        public IQueryable<Zone> GetZones(bool queueZones)
        {
            return queueZones ?
                (from z in Query()
                 where z.IsQueueZone == true
                 select z) : Query();
        }

    }
}
