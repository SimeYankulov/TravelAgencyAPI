using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyModels.DTOs
{
    public class CreateReservationDTO
    {
        public string? contactName { get; set; }
        public string? phoneNumber { get; set; }
        public long holiday { get; set; } = 0; 
    }
}
