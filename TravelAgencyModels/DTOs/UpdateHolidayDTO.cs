using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyModels.DTOs
{
    public class UpdateHolidayDTO
    {
        public long id { get; set; }
        public long location { get; set; } = 0;
        public string? title { get; set; }
        public DateOnly? startDate { get; set; }
        public int duration { get; set; } = 0;
        public string price { get; set; }
        public int freeSlots { get; set; } = 0; 
    }
}
