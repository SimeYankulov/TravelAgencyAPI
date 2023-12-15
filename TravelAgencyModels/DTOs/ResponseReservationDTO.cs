using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyModels.DTOs
{
    public class ResponseReservationDTO
    {
        public long id { get; set; }
        public string? contactName { get; set; }
        public string? phoneNumber { get; set; }
        public ResponseHolidayDTO? holiday { get; set; }

    }
}
