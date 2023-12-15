using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyModels.DTOs
{
    public class ResponseHolidayDTO
    {
        public int id { get; set; } = 0;
        public ResponseLocationDTO? locationDTO { get; set; }
        public string? title { get; set; }
        public DateTime? startDate { get; set; }
        public int duration { get; set; } = 0;
        public double price { get; set; } = 0;
        public int freeSlots { get; set; } = 0;
 
    }
}
