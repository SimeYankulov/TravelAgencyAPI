namespace TravelAgencyModels.DTOs
{
    public class UpdateReservationDTO
    {
        public long id { get; set; } = 0;
        public string? contactName { get; set; }
        public string? phoneNumber { get; set; }
        public long holiday { get; set; } = 0;
    }
}
