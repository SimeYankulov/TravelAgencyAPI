using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgencyAPI.Entities
{
    public class Holiday
    {
        public long? Id { get; set; }
        public int? Duration { get; set; }
        public int? FreeSlots { get; set; }
        public  double? Price { get; set; }
        public string? Title { get; set; }
        public string? StartDate { get; set; } 
        public long? LocationId { get; set; }
        [ForeignKey("LocationId")]
        public Location? Location { get; set; }
    }
}
