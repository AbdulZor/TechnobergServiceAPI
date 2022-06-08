namespace TechnobergServiceAPI.Models
{
    public class Device
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public string OperatingSystem { get; set; }
        public string DeviceToken { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
