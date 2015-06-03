using OurMobileService.DataObjects;
using OurMobileService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OurMobileService.Controllers
{
    public class PointController : ApiController
    {
        public int GetUserPoints(Guid userId)
        {
            int pointsOfUser = 0;
            using (var context = new MobileServiceContext())
            {
                User user = (from u in context.Users
                             where u.Id == userId.ToString()
                             select u).FirstOrDefault();

                pointsOfUser = user != null ? user.Points : 0;
            }
            return pointsOfUser;
        }
    }
}
