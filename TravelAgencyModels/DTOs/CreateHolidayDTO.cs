namespace TravelAgencyModels.DTOs
{
    public class CreateHolidayDTO
    {
        public long? location { get; set; }
        public string? title { get; set; } = String.Empty;
        public DateOnly? startDate { get; set; } = DateOnly.MaxValue;
        public int? duration { get; set; } = 0;
        public string? price { get; set; } = "0.0";
        public int? freeSlots { get; set; } = 0;

    }
}
