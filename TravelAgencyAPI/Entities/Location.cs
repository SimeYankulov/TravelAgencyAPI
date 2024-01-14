namespace TravelAgencyAPI.Entities
{
    public class Location
    {
        public long? Id { get; set; }
        public string? Number { get; set; } = string.Empty;
        public string? Country { get; set; } = string.Empty;
        public string? City { get; set; } = string.Empty;
        public string? Street { get; set; } = string.Empty;
        public string? ImageUrl { get; set; } = string.Empty;

    }
}
