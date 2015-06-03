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
                    Id="nogo1"
                    , Name="Toilet 1"
                    , ZoneCategory=ZoneCategory.Toilet
                ,IsQueueZone=false},
                new Zone {
                    Id="nogo2"
                    , Name="Exit 1"
                    , ZoneCategory=ZoneCategory.Exit
                ,IsQueueZone=true},
                 new Zone {
                     Id="bonus1"
                    , Name="Finest Hacking Place"
                    , ZoneCategory=ZoneCategory.SittingZone              },
                  new Zone {
                      Id="bonus2"
                    , Name="Bar"
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

