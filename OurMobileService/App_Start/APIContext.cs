using OurMobileService.Models;
using System.Collections.Generic;

namespace OurMobileService.App_Start
{
    public static class APIContext
    {
        public static List<Move> Moves;
        public static List<User> Users;
        public static List<Reward> Rewards;
        public static List<Zone> Zones;
    }
}
