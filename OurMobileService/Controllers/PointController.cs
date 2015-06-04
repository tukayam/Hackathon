using OurMobileService.App_Start;
using OurMobileService.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace OurMobileService.Controllers
{
    public class PointController : ApiController
    {
        public int GetUserPoints(Guid userId)
        {
            User user = (from u in APIContext.Users
                         where u.Id == userId
                         select u).FirstOrDefault();             

            return user != null ? user.Points : 0;
        }
    }
}
