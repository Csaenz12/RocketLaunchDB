namespace Rocket_Launch_Database__2_.Models
{
    public class RocketLaunch
    {
        public int Id { get; set; }
        public int LaunchSiteId { get; set; }
        public int LaunchVehicleId { get; set; }
        public int PayloadId { get; set; }
        public int UserId { get; set; }
        public DateTime LaunchDate { get; set; }
        public string MissionOutcome { get; set; }

        public LaunchSite LaunchSite { get; set; }
        public LaunchVehicle LaunchVehicle { get; set; }
        public Payload Payload { get; set; }
        public User User { get; set; }
    }
}
