using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using Microsoft.WindowsAzure.Mobile.Service;
using OurMobileService.DataObjects;
using OurMobileService.Models;
using System;
using System.Collections.Generic;

namespace OurMobileService.Controllers
{
    public class UserController : TableController<User>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<User>(context, Request, Services);
        }
        public IQueryable<User> GetAllUsers()
        {
            IQueryable<User> users = (from m in Query()
                         
                         select m);
            return users;
        }

        // GET tables/user/{id}
        public User GetUser(Guid identifier)
        {
            User user = (from m in Query()
                         where m.Id == identifier.ToString()
                         select m).FirstOrDefault();

            //if (user == null)
            //{
            //    user = new User() { Identifier = identifier, Points = 0 };
            //    using (MobileServiceContext context = new MobileServiceContext())
            //    {
            //        context.Users.Add(user);
            //        context.SaveChanges();
            //    }
            //}

            return user;
        }
    }
}