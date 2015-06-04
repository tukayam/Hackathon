using OurMobileService.DataObjects;
using OurMobileService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OurMobileService.App_Start
{
    public class BuildShopOrderOrderedDataset
    {
        /*
        public List<ShopItem> BuildShopInventory(Guid shopID)
        {

            List<ShopItem> items = new List<ShopItem>
            {
                new ShopItem {
                    CreatedAt=DateTime.Now,
                    Identifier=new Guid("ef514b12-1ec7-493e-bad7-5958b321c006"),
                    Name="Snickers",
                    Price=0.34,
                    SellingPointID=shopID,
                    ShopItemCategory=ShopItemCategory.Food

                },
                new ShopItem {
                    CreatedAt=DateTime.Now,
                    Identifier=new Guid("ef514b13-1ec7-493e-bad7-5958b321c006"),
                    Name="M&Ms",
                    Price=0.34,
                    SellingPointID=shopID,
                    ShopItemCategory=ShopItemCategory.Food

                },new ShopItem {
                    CreatedAt=DateTime.Now,
                    Identifier=new Guid("ef514b14-1ec7-493e-bad7-5958b321c006"),
                    Name="Hamburger",
                    Price=3.34,
                    SellingPointID=shopID,
                    ShopItemCategory=ShopItemCategory.Food

                },new ShopItem {
                    CreatedAt=DateTime.Now,
                    Identifier=new Guid("ef514b15-1ec7-493e-bad7-5958b321c006"),
                    Name="Popcorn",
                    Price=3.34,
                    SellingPointID=shopID,
                    ShopItemCategory=ShopItemCategory.Food

                },
                new ShopItem {
                    CreatedAt=DateTime.Now,
                    Identifier=new Guid("ef514b16-1ec7-493e-bad7-5958b321c006"),
                    Name="Spa blauw",
                    Price=1,
                    SellingPointID=shopID,
                    ShopItemCategory=ShopItemCategory.Drink

                }

            };
            return items;

        }

             public List<Order> BuildOrders(Guid userID, List<ShopItem> ShopItems)
        {
            
            List<Order> orders = new List<Order>
            {
                new Order{
                    Identifier=2,
                    UserID=userID,
                    DateTime= DateTime.Now,
                    Items=new List<OrderItem>{
                        new OrderItem{
                            Name=ShopItems[0].Name,
                            Amount=2,
                            Price=ShopItems[0].Price,
                            ShopItemID=ShopItems[0].Identifier
                            
                        },
                        new OrderItem{
                            Name=ShopItems[3].Name,
                            Amount=2,
                            Price=ShopItems[3].Price,
                            ShopItemID=ShopItems[3].Identifier
                            
                        }
                    }
                },new Order{
                    Identifier=2,
                    UserID=userID,
                    DateTime= DateTime.Now.AddDays(-2),
                    Items=new List<OrderItem>{
                        new OrderItem{
                            Name=ShopItems[1].Name,
                            Amount=1,
                            Price=ShopItems[1].Price,
                            ShopItemID=ShopItems[1].Identifier
                            
                        },
                        new OrderItem{
                            Name=ShopItems[3].Name,
                            Amount=3,
                            Price=ShopItems[3].Price,
                            ShopItemID=ShopItems[3].Identifier
                            
                        }
                    }
                }

            };

            return orders;
        }
        */
        public List<User> BuildUsers()
        {
            List<User> users = new List<User>
            {
                new User{
                    Id=new Guid( "ef514a16-1ec7-493e-bad7-5958b321c006"),
                    Name="Peter"
                },
                new User{
                    Id= new Guid("8a31d39a-391c-4801-a951-2d0a579a0b4c"),
                    Name="Rok"
                },
                new User{
                    Id=new Guid("2620b5d1-a743-4fb0-a4fb-26e914a0cb78"),
                    Name="Barry"
                },
                new User{
                    Id=new Guid("715805e4-ff7f-4292-9312-5d1e4b6a3a01"),
                    Name="Tuba"
                },
                new User{
                    Id=new Guid("77eabad1-9248-4d45-8be8-8474d249bee1"),
                    Name="Bob"
                }

            };
            return users;
        }       
    }
}