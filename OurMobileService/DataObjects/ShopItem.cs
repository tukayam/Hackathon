using Microsoft.WindowsAzure.Mobile.Service;
using System;

namespace OurMobileService.DataObjects
{
    public class ShopItem : EntityData
    {
        public Guid Identifier { get; set; }
        public string Name { get; set; }

        //Location
        public Guid SellingPointID { get; set; }

        public ShopItemCategory ShopItemCategory { get; set; }
        public double Price { get; set; }
    }
}