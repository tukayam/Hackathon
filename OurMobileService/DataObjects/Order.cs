using Microsoft.WindowsAzure.Mobile.Service;
using System.Collections.Generic;

namespace OurMobileService.DataObjects
{
    public class Order : EntityData
    {
        public int Identifier { get; set; }      
        public User User { get; set; }

        public IEnumerable<OrderItem> Items { get; set; }
    }
}