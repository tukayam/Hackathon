using System;
using System.Collections.Generic;

namespace OurMobileService.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public List<Reward> Rewards { get; set; }
    }
}