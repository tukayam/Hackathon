using Microsoft.WindowsAzure.Mobile.Service;
using System;

namespace OurMobileService.DataObjects
{
    public class Beacon : EntityData
    {
        public Guid Identifier { get; set; }
    }
}