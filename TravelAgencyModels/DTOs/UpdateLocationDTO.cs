using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyModels.DTOs
{
    public class UpdateLocationDTO
    {
        public long id { get; set; } = 0; 
        public string? street { get; set; }
        public string? number { get; set; }
        public string? city { get; set; }
        public string? country { get; set; }
        public string? imageUrl { get; set; }
    }
}
