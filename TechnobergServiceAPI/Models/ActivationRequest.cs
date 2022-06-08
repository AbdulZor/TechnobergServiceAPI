namespace TechnobergServiceAPI.Models
{
    public class ActivationRequest
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public string ActivationCode { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
