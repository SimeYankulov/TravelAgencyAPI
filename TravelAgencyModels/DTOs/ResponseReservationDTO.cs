namespace TravelAgencyModels.DTOs
{
    public class ResponseReservationDTO
    {
        public string? phoneNumber { get; set; }
        public string? contactName { get; set; }
        public long id { get; set; }
        public ResponseHolidayDTO? holiday { get; set; }

    }
}
