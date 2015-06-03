using OurMobileService.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurMobileService
{
    public static class Context
    {
        public static List<User> Users;
        public static List<Location> Locations { get; set; }
        public static List<Order> Orders { get; set; }
        public static List<OrderItem> OrderItems { get; set; }
        public static List<ShopItem> ShopItems { get; set; }
        public static List<Campaign> Campaigns { get; set; }
        public static List<Reward> Rewards { get; set; }
        public static List<Move> Moves { get; set; }

        static Context()
        {
            Users = AddUsers();
            Locations = AddLocations();
            Moves = AddMoves(Users, Locations);
        }

        private static List<User> AddUsers()
        {
            List<User> users = new List<User>
            {
                new User { Identifier =new Guid("B6E8F3BD-BAFA-4BB2-B23D-6F46FC356929")},
               new User { Identifier =new Guid("B69F1482-23A0-4C7D-933A-AF502BA2BB58")}
            };
            return users;
        }

        private static List<Location> AddLocations()
        {
            List<Location> locs = new List<Location>
            {
                new Location {
                    Identifier =new Guid("ef514b47-1ec7-493e-bad7-5958b321c006")
                    , LocationCategory=LocationCategory.FoodShop               },
                new Location {
                    Identifier =new Guid("3e1d6dd0-6ac9-4126-9684-f1bddef2720b")
                    , LocationCategory=LocationCategory.QueueArea                },
                 new Location {
                    Identifier =new Guid("3e1d6dd0-6ac9-4126-9684-f1bddef2720c")
                    , LocationCategory=LocationCategory.QueueArea              },
                  new Location {
                    Identifier =new Guid("3e1d6dd0-6ac9-4126-9684-f1bddef2720d")
                    , LocationCategory=LocationCategory.QueueArea              },
                   new Location {
                    Identifier =new Guid("3e1d6dd0-6ac9-4126-9684-f1bddef2720e")
                    , LocationCategory=LocationCategory.QueueArea              },
                    new Location {
                    Identifier =new Guid("3e1d6dd0-6ac9-4126-9684-f1bddef2720g")
                    , LocationCategory=LocationCategory.QueueArea              },
            };

            return locs;
        }

        private static List<Move> AddMoves(List<User> users, List<Location> locs)
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

            return moves;
        }
    }
}
