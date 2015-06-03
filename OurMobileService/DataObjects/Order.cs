using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;

namespace OurMobileService.DataObjects
{
    public class Order : EntityData
    {
        public int Identifier { get; set; }
        public Guid UserID { get; set; }

        public IEnumerable<OrderItem> Items { get; set; }
    }
}