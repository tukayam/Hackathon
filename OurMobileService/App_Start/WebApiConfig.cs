using System;
using System.Collections.Generic;
using System.Web.Http;
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

            // Database.SetInitializer(new MobileServiceInitializer());
            APIContextBuilder builder = new APIContextBuilder();
            builder.BuildAPIContext();
        }
    }

    /*
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
                    orders = builder.BuildOrders(new Guid(user.Id), shopitems);
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
                Guid userId1 = new Guid(users[0].Id);
                Guid userId2 = new Guid(users[1].Id);

                List<Move> moves = new List<Move>
                {
                    new Move {UserID=userId1,LocationID=new Guid( locs[0].Id), Time=DateTime.Now.AddMinutes(-5)},
                    new Move {UserID=userId1,LocationID=new Guid( locs[1].Id), Time=DateTime.Now.AddMinutes(-3)},
                     new Move {UserID=userId1,LocationID=new Guid( locs[3].Id), Time=DateTime.Now.AddMinutes(-2)},
                     new Move {UserID=userId1,LocationID=new Guid( locs[2].Id), Time=DateTime.Now.AddMinutes(-1)},
                   new Move {UserID=userId2,LocationID=new Guid( locs[1].Id), Time=DateTime.Now.AddMinutes(-5)},
                    new Move {UserID=userId2,LocationID=new Guid( locs[2].Id), Time=DateTime.Now.AddMinutes(-3)},
                     new Move {UserID=userId2,LocationID=new Guid( locs[0].Id), Time=DateTime.Now.AddMinutes(-2)},
                     new Move {UserID=userId2,LocationID=new Guid( locs[3].Id), Time=DateTime.Now.AddMinutes(-1)},
                };

                foreach (Move m in moves)
                {
                    context.Set<Move>().Add(m);
                }
                context.SaveChanges();
            }
        }
        */

    public class APIContextBuilder
    {
        public void BuildAPIContext()
        {
            AddUsers();
            AddZones();
            AddMoves();
            AddRewards();
        }

        private void AddUsers()
        {
            List<User> users = new List<User>
            {
                new User{
                    Id=new Guid( "ef514a16-1ec7-493e-bad7-5958b321c006"),
                    Name="Peter",
                    Points=20
                },
                new User{
                    Id= new Guid("8a31d39a-391c-4801-a951-2d0a579a0b4c"),
                    Name="Rok",
                    Points=0
                },
                new User{
                    Id=new Guid("2620b5d1-a743-4fb0-a4fb-26e914a0cb78"),
                    Name="Barry",
                    Points=10
                },
                new User{
                    Id=new Guid("715805e4-ff7f-4292-9312-5d1e4b6a3a01"),
                    Name="Tuba",
                    Points=0
                },
                new User{
                    Id=new Guid("77eabad1-9248-4d45-8be8-8474d249bee1"),
                    Name="Bob",
                    Points=40
                }

            };

            APIContext.Users = users;
        }

        private void AddZones()
        {
            List<Zone> zones = new List<Zone>
            {
                new Zone {
                    Id="nogo1"
                    , Name="Toilet 1"
                    , ZoneCategory=ZoneCategory.Toilet
                ,IsQueueZone=true},
                new Zone {
                    Id="nogo2"
                    , Name="Exit 1"
                    , ZoneCategory=ZoneCategory.Exit
                ,IsQueueZone=true},
                 new Zone {
                     Id="bonus1"
                    , Name="Finest Hacking Place"
                    , ZoneCategory=ZoneCategory.SittingZone
                 ,IsQueueZone=false},
                  new Zone {
                      Id="bonus2"
                    , Name="Bar"
                    , ZoneCategory=ZoneCategory.Bar
                  ,IsQueueZone=false}

            };

            APIContext.Zones = zones;
        }

        private void AddMoves()
        {
            List<User> users = APIContext.Users;
            List<Zone> zones = APIContext.Zones;

            Guid userId1 = users[0].Id;
            Guid userId2 = users[1].Id;

            List<Move> moves = new List<Move>
            {
                new Move {UserID=userId1,ZoneID=zones[0].Id, Time=DateTime.Now.AddMinutes(-5)},
                new Move {UserID=userId1,ZoneID= zones[1].Id, Time=DateTime.Now.AddMinutes(-3)},
                 new Move {UserID=userId1,ZoneID= zones[3].Id, Time=DateTime.Now.AddMinutes(-2)},
                 new Move {UserID=userId1,ZoneID= zones[2].Id, Time=DateTime.Now.AddMinutes(-1)},
               new Move {UserID=userId2,ZoneID=zones[1].Id, Time=DateTime.Now.AddMinutes(-5)},
                new Move {UserID=userId2,ZoneID=zones[2].Id, Time=DateTime.Now.AddMinutes(-3)},
                 new Move {UserID=userId2,ZoneID= zones[0].Id, Time=DateTime.Now.AddMinutes(-2)},
                 new Move {UserID=userId2,ZoneID=zones[3].Id, Time=DateTime.Now.AddMinutes(-1)},
            };

            APIContext.Moves = moves;
        }

        private void AddRewards()
        {
            var reward1 = new Reward() { Name = "BeerAtBar", Description = "Free beer at the bar!", ZoneID = "bonus2", RewardCategory = RewardCategory.Drink, PointsRequired = 20 };
            var reward2 = new Reward() { Name = "DiscountOnFoodAtBar", Description = "10 euro discount at the bar!", ZoneID = "bonus2", RewardCategory = RewardCategory.DiscountOnFood, PointsRequired = 40 };
            var reward3 = new Reward() { Name = "DrinkAtBar", Description = "Free drink of your choice at the bar!", ZoneID = "bonus2", RewardCategory = RewardCategory.Drink, PointsRequired = 30 };

            APIContext.Rewards = new List<Reward>();
            APIContext.Rewards.Add(reward1);
            APIContext.Rewards.Add(reward2);
            APIContext.Rewards.Add(reward3);
        }
    }
}

