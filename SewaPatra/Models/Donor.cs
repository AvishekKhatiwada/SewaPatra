namespace SewaPatra.Models
{
    public class Donor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Mobile_No { get; set; }
        public string Mobile_no2 { get; set; }
        public string Email { get; set; }
        public int Area { get; set; }
        public int Coordinator { get; set; }
        public string? Location { get; set; }
        public bool Active { get; set; }
        public string? AreaName { get; set; }
        public string? CoordinatorName { get; set; }

    }
}
