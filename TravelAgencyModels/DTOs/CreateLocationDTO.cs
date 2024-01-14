namespace TravelAgencyModels.DTOs
{
    public class CreateLocationDTO
    {
        public string? street { get; set; } = string.Empty;
        public string? number { get; set; } = string.Empty;
        public string? city { get; set; } = string.Empty;
        public string? country { get; set; } = string.Empty;
        public string? imageUrl { get; set; } = string.Empty;

    }
}
