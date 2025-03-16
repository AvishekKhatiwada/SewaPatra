namespace SewaPatra.Models
{
    public class Coordinator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Mobile_No { get; set; }
        public string Alternate_Mobile_No { get; set; }

        public string Email { get; set; }
        public int Area_Under { get; set; }
        public string? location { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? AreaName { get; set; }
    }
}
