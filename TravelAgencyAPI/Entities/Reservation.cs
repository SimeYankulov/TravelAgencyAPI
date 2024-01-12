using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgencyAPI.Entities
{
    public class Reservation
    {
        public long Id { get; set; }
        public string contactName { get; set; }
        public string phoneNumber { get; set; }
        public long HolidayId { get; set; }
        [ForeignKey("HolidayId")]
        public Holiday Holiday { get; set; }
    }
}
