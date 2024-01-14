namespace TravelAgencyModels.DTOs
{
    public class UpdateHolidayDTO
    {
        public long? id { get; set; }
        public long? location { get; set; }
        public string? title { get; set; } = String.Empty;
        public DateOnly? startDate { get; set; } = null;
        public int duration { get; set; } = 0;
        public double? price { get; set; }  
        public int? freeSlots { get; set; }  
    }
}
