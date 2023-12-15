using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyModels.DTOs
{
    public class CreateHolidayDTO
    {
        public long? location { get; set; }
        public string? title { get; set; }
        public string? startDate { get; set; }
        public int duration { get; set; } = 0;
        public string? price { get; set; }
        public int freeSlots { get; set; } = 0;

    }
}
