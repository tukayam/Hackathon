using System.Linq;
using System.Web.Http.Controllers;
using OurMobileService.Models;
using System;
using System.Web.Http;
using OurMobileService.App_Start;
using System.Collections.Generic;

namespace OurMobileService.Controllers
{
    public class UserController : ApiController
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return APIContext.Users;
        }

        // GET api/user/{id}
        public User GetUser(Guid identifier)
        {
            User user = (from m in APIContext.Users
                         where m.Id == identifier
                         select m).FirstOrDefault();

            return user;
        }
    }
}