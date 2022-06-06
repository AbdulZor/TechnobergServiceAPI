namespace TechnobergServiceAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public bool IsEnrolled { get; set; }
        public virtual ICollection<Device>? Devices { get; set; }
        public virtual ICollection<ActivationRequest>? ActivationRequests { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
