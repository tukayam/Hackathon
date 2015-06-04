namespace OurMobileService.Models
{
    public class Zone
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ZoneCategory ZoneCategory { get; set; }
        public bool IsQueueZone { get; set; }
    }
}