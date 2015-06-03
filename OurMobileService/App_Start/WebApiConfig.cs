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
                List<Zone> locations = AddZones(context);
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

        private List<Zone> AddZones(MobileServiceContext context)
        {
            Guid shopID = new Guid("ef514b47-1ec7-493e-bad7-5958b321c006");
            List<Zone> locs = new List<Zone>
            {
                new Zone {
                    Id=new Guid("cc2ce2b8-55df-470f-9d5e-223497434670").ToString()
                    , Name="Toilet 1"
                    , ZoneID="nogo1"
                    , ZoneCategory=ZoneCategory.Toilet
                ,IsQueueZone=false},
                new Zone {
                    Id=new Guid("e96c4d32-4f75-4e53-9699-2f6d8b90ef9b").ToString()
                    , Name="Exit 1"
                    , ZoneID="nogo2"
                    , ZoneCategory=ZoneCategory.Exit
                ,IsQueueZone=true},
                 new Zone {
                     Id=new Guid("bb081e4d-727f-4dd1-b055-51383f8533e9").ToString()
                    , Name="Finest Hacking Place"
                    , ZoneID="bonus1"
                    , ZoneCategory=ZoneCategory.SittingZone              },
                  new Zone {
                      Id=new Guid("2ed87fda-21e0-4ef1-bfa9-96e71e1d397d").ToString()
                    , Name="Bar"
                    , ZoneID="bonus2"
                    , ZoneCategory=ZoneCategory.Bar              }

            };

            // Get Builder
            BuildShopOrderOrderedDataset builder = new BuildShopOrderOrderedDataset();

            // Get users
            List<User> users = builder.BuildUsers();

            // Get Inventory
            List<ShopItem> shopitems = builder.BuildShopInventory(shopID);

            List<Order> orders = null;

            // Create Orders with subitems: OrderItem
            foreach (User user in users)
            {
                orders = builder.BuildOrders(user.Identifier, shopitems);
            }

            // Store in DB
            foreach (Zone l in locs)
            {
                context.Set<Zone>().Add(l);
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

        private void AddMoves(MobileServiceContext context, List<User> users, List<Zone> locs)
        {
            List<Move> moves = new List<Move>
            {
                new Move {UserID=users[0].Identifier,LocationID=new Guid( locs[0].Id), Time=DateTime.Now.AddMinutes(-5)},
                new Move {UserID=users[0].Identifier,LocationID=new Guid( locs[1].Id), Time=DateTime.Now.AddMinutes(-3)},
                 new Move {UserID=users[0].Identifier,LocationID=new Guid( locs[3].Id), Time=DateTime.Now.AddMinutes(-2)},
                 new Move {UserID=users[0].Identifier,LocationID=new Guid( locs[2].Id), Time=DateTime.Now.AddMinutes(-1)},
               new Move {UserID=users[1].Identifier,LocationID=new Guid( locs[1].Id), Time=DateTime.Now.AddMinutes(-5)},
                new Move {UserID=users[1].Identifier,LocationID=new Guid( locs[2].Id), Time=DateTime.Now.AddMinutes(-3)},
                 new Move {UserID=users[1].Identifier,LocationID=new Guid( locs[0].Id), Time=DateTime.Now.AddMinutes(-2)},
                 new Move {UserID=users[1].Identifier,LocationID=new Guid( locs[3].Id), Time=DateTime.Now.AddMinutes(-1)},
            };

            foreach (Move m in moves)
            {
                context.Set<Move>().Add(m);
            }
            context.SaveChanges();
        }
    }
}

