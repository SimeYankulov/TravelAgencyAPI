namespace TravelAgencyModels.DTOs
{
    public class ResponseHolidayDTO
    {
        public int? duration { get; set; } 
        public int? freeSlots { get; set; } 
        public double? price { get; set; }
        public ResponseLocationDTO? location { get; set; }
        public long? id { get; set; } 
        public string? title { get; set; }
        public DateOnly? startDate { get; set; }

    }
}
