using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.ComponentModel.DataAnnotations;

namespace OurMobileService.DataObjects
{
    public class User : EntityData
    {
        [Key]
        public Guid Identifier { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
    }
}