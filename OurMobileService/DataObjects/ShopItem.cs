using Microsoft.WindowsAzure.Mobile.Service;

namespace OurMobileService.DataObjects
{
    public class ShopItem : EntityData
    {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public Location SellingPoint { get; set; }
        public ShopItemCategory ShopItemCategory { get; set; }
        public double Price { get; set; }
    }
}