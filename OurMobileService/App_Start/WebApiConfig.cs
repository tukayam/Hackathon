using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Web.Http;
using OurMobileService.DataObjects;
using OurMobileService.Models;
using Microsoft.WindowsAzure.Mobile.Service;
using OurMobileService.App_Start;

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
            try
            {
                List<User> users = AddUsers(context);
                List<Location> locations = AddLocations(context);
                AddMoves(context, users, locations);
            }
            catch (Exception ex)
            {

                throw;
            }
           

            base.Seed(context);
        }

        private List<User> AddUsers(MobileServiceContext context)
        {
            BuildShopOrderOrderedDataset builder = new BuildShopOrderOrderedDataset();
            List<User> users = builder.BuildUsers();


            foreach (User user in users)
            {
                context.Set<User>().Add(user);
            }

            foreach (User user in users)
            {
                context.Set<User>().Add(user);
            }
            try
            {
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            
            return users;
        }

        private List<Location> AddLocations(MobileServiceContext context)
        {
            Guid shopID = new Guid("ef514b47-1ec7-493e-bad7-5958b321c006");
            List<Location> locs = new List<Location>
            {
                new Location {
                    Identifier =shopID
                    , Name="Foodshop 1"
                    , ZoneID="foodshop1"
                    , LocationCategory=LocationCategory.FoodShop               },
                new Location {
                    Identifier =new Guid("3e1d6dd0-6ac9-4126-9684-f1bddef2720b")
                    , Name="Entrance 1"
                    , ZoneID="entrance1"
                    , LocationCategory=LocationCategory.QueueArea                },
                 new Location {
                    Identifier =new Guid("3e1d6dd0-6ac9-4126-9684-f1bddef2720c")
                    , Name="Entrance 2"
                    , ZoneID="entrance1"
                    , LocationCategory=LocationCategory.QueueArea              },
                  new Location {
                    Identifier =new Guid("3e1d6dd0-6ac9-4126-9684-f1bddef2720d")
                    , Name="Entrance 3"
                    , ZoneID="entrance3"
                    , LocationCategory=LocationCategory.QueueArea              },
                   new Location {
                    Identifier =new Guid("3e1d6dd0-6ac9-4126-9684-f1bddef2720e")
                    , Name="Entrance 4"
                    , ZoneID="entrance4"
                    , LocationCategory=LocationCategory.QueueArea              },
                    new Location {
                    Identifier =new Guid("3e1d6dd0-6ac9-4126-9684-f1bddef2720g")
                    , Name="Entrance 5"
                    , ZoneID="entrance5"
                    , LocationCategory=LocationCategory.QueueArea              },
            };

            // Get Builder
            BuildShopOrderOrderedDataset builder=new BuildShopOrderOrderedDataset();

            // Get users
            List<User> users = builder.BuildUsers();

            // Get Inventory
            List<ShopItem> shopitems=builder.BuildShopInventory(shopID);
            
            List<Order> orders=null;

            // Create Orders with subitems: OrderItem
            foreach (User user in users)
            {
                orders = builder.BuildOrders(user.Identifier, shopitems);
            }

            // Store in DB
            foreach (Location l in locs)
            {
                context.Set<Location>().Add(l);
            }
            foreach (ShopItem l in shopitems)
            {
                context.Set<ShopItem>().Add(l);
            }
            foreach (Order l in orders)
            {
                context.Set<Order>().Add(l);
            }

            // Save stuff
            context.SaveChanges();
            return locs;
        }

        private void AddMoves(MobileServiceContext context, List<User> users, List<Location> locs)
        {
            List<Move> moves = new List<Move>
            {
                new Move {User=users[0],LocationID=locs[0].Identifier, Time=DateTime.Now.AddMinutes(-5)},
                new Move {User=users[0],LocationID=locs[1].Identifier, Time=DateTime.Now.AddMinutes(-3)},
                 new Move {User=users[0],LocationID=locs[4].Identifier, Time=DateTime.Now.AddMinutes(-2)},
                 new Move {User=users[0],LocationID=locs[5].Identifier, Time=DateTime.Now.AddMinutes(-1)},
               new Move {User=users[1],LocationID=locs[4].Identifier, Time=DateTime.Now.AddMinutes(-5)},
                new Move {User=users[1],LocationID=locs[2].Identifier, Time=DateTime.Now.AddMinutes(-3)},
                 new Move {User=users[1],LocationID=locs[3].Identifier, Time=DateTime.Now.AddMinutes(-2)},
                 new Move {User=users[1],LocationID=locs[4].Identifier, Time=DateTime.Now.AddMinutes(-1)},
            };

            foreach (Move m in moves)
            {
                context.Set<Move>().Add(m);
            }
            context.SaveChanges();
        }
    }
}

