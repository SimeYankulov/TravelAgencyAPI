namespace TravelAgencyModels.DTOs
{
    public class ResponseHolidayDTO
    {
        public int duration { get; set; } = 0;
        public int freeSlots { get; set; } = 0;
        public double price { get; set; } = 0;
        public ResponseLocationDTO? location { get; set; }
        public long id { get; set; } = 0;
        public string? title { get; set; }
        public DateOnly? startDate { get; set; }

    }
}
