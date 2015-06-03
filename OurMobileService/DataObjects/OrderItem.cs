using Microsoft.WindowsAzure.Mobile.Service;

namespace OurMobileService.DataObjects
{
    public class OrderItem : EntityData
    {
        public int Identifier { get; set; }
        public ShopItem ShopItem { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
    }
}