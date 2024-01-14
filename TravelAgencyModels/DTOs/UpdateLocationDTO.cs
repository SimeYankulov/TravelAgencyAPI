namespace TravelAgencyModels.DTOs
{
    public class UpdateLocationDTO
    {
        public long id { get; set; } = 0; 
        public string? street { get; set; } = string.Empty;
        public string? number { get; set; } = string.Empty;
        public string? city { get; set; } = string.Empty;
        public string? country { get; set; } = string.Empty;
        public string? imageUrl { get; set; } = string.Empty;
    }
}
