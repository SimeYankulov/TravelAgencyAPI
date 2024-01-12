using TravelAgencyAPI.Entities;
using TravelAgencyModels.DTOs;

namespace TravelAgencyAPI.Extensions
{
    public static class ReservationDtoConversion
    {
        public static IEnumerable<ResponseReservationDTO> ConvertToDto(this IEnumerable<Reservation> reservations)
        {
            return (from reservation in reservations
                    select new ResponseReservationDTO
                    {
                        id = reservation.Id,
                        contactName = reservation.contactName,
                        phoneNumber = reservation.phoneNumber,
                        holiday = reservation.Holiday.ConvertToDto()

                    }).ToList();
        }
        public static ResponseReservationDTO ConvertToDto(this Reservation reservation)
        {
            return new ResponseReservationDTO
            {
                id = reservation.Id,
                contactName = reservation.contactName,
                phoneNumber = reservation.phoneNumber,
                holiday = reservation.Holiday.ConvertToDto()
            };
        }
        public static Reservation ConvertToEntity(this CreateReservationDTO reservation)
        {
            return new Reservation
            {
                contactName = reservation.contactName,
                phoneNumber = reservation.phoneNumber,
                HolidayId = reservation.holiday
            };
        }

        public static Reservation ConvertToEntity(this UpdateReservationDTO reservation)
        {
            return new Reservation
            {
                Id = reservation.id,
                contactName = reservation.contactName,
                phoneNumber = reservation.phoneNumber,
                HolidayId = reservation.holiday
            };
        }
    }
}
