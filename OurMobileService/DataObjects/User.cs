using Microsoft.WindowsAzure.Mobile.Service;
using System;

namespace OurMobileService.DataObjects
{
    public class User : EntityData
    {
        public Guid Identifier { get; set; }
        public int Points { get; set; }
    }
}