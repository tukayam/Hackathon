using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Web.Http;
using OurMobileService.DataObjects;
using OurMobileService.Models;
using Microsoft.WindowsAzure.Mobile.Service;

namespace OurMobileService
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            Database.SetInitializer(new MobileServiceInitializer());
        }
    }

    public class MobileServiceInitializer : DropCreateDatabaseIfModelChanges<MobileServiceContext>
    {
        protected override void Seed(MobileServiceContext context)
        {
            List<User> users = AddUsers(context);
            List<Location> locations = AddLocations(context);
            AddMoves(context, users, locations);

            base.Seed(context);
        }

        private List<User> AddUsers(MobileServiceContext context)
        {
            List<User> users = new List<User>
            {
                new User { Identifier =new Guid("B6E8F3BD-BAFA-4BB2-B23D-6F46FC356929")},
               new User { Identifier =new Guid("B69F1482-23A0-4C7D-933A-AF502BA2BB58")}
            };

            foreach (User user in users)
            {
                context.Set<User>().Add(user);
            }

            return users;
        }

        private List<Location> AddLocations(MobileServiceContext context)
        {
            Beacon b1 = new Beacon { Identifier = new Guid("F1C2A929-7B5D-4A94-86DB-E0D0FFB55C60") };
            Beacon b2 = new Beacon { Identifier = new Guid("0EFB35A8-C0E2-4343-BF2B-FD8C75816D5B") };
            Beacon b3 = new Beacon { Identifier = new Guid("8bb70150-9d4a-4732-8405-179f1eafa4ea") };
            Beacon b4 = new Beacon { Identifier = new Guid("94ef1d34-c85e-4c6b-84f1-8a9dec89a793") };
            Beacon b5 = new Beacon { Identifier = new Guid("637a9fc7-e1f5-4454-b03a-81f5430553d4") };
            Beacon b6 = new Beacon { Identifier = new Guid("156aedd7-84ed-4b18-a835-0c42c422b261") };
            Beacon b7 = new Beacon { Identifier = new Guid("0825d209-2117-4c40-b52e-5a1708b0917e") };
            Beacon b8 = new Beacon { Identifier = new Guid("53b1fb63-0cd7-47d7-8cd6-58be18582f19") };

            List<Beacon> beacons = new List<Beacon>
            {b1,b2,b3,b4,b5,b6,b7,b8            };

            foreach (Beacon b in beacons)
            {
                context.Set<Beacon>().Add(b);
            }

            List<Location> locs = new List<Location>
            {
                new Location {
                    Identifier =new Guid("ef514b47-1ec7-493e-bad7-5958b321c006")
                    , LocationCategory=LocationCategory.FoodShop      ,Beacon=b1          },
                new Location {
                    Identifier =new Guid("3e1d6dd0-6ac9-4126-9684-f1bddef2720b")
                    , LocationCategory=LocationCategory.QueueArea      ,Beacon=b2          },
            };

            foreach (Location l in locs)
            {
                context.Set<Location>().Add(l);
            }

            return locs;
        }

        private void AddMoves(MobileServiceContext context, List<User> users, List<Location> locs)
        {
            List<Move> moves = new List<Move>
            {
                new Move {User=users[0],Location=locs[0], Time=DateTime.Now.AddMinutes(-5)},
                new Move {User=users[0],Location=locs[3], Time=DateTime.Now.AddMinutes(-3)},
                 new Move {User=users[0],Location=locs[4], Time=DateTime.Now.AddMinutes(-2)},
                 new Move {User=users[0],Location=locs[5], Time=DateTime.Now.AddMinutes(-1)},
               new Move {User=users[1],Location=locs[4], Time=DateTime.Now.AddMinutes(-5)},
                new Move {User=users[1],Location=locs[2], Time=DateTime.Now.AddMinutes(-3)},
                 new Move {User=users[1],Location=locs[3], Time=DateTime.Now.AddMinutes(-2)},
                 new Move {User=users[1],Location=locs[4], Time=DateTime.Now.AddMinutes(-1)},
            };

            foreach (Move m in moves)
            {
                context.Set<Move>().Add(m);
            }
        }
    }
}

