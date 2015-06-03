using Microsoft.WindowsAzure.Mobile.Service;
using System;

namespace OurMobileService.DataObjects
{
    public class OrderItem : EntityData
    {
        public int Identifier { get; set; }
        public Guid ShopItemID { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
    }
}