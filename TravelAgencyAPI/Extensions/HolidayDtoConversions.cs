using TravelAgencyAPI.Entities;
using TravelAgencyModels.DTOs;

namespace TravelAgencyAPI.Extensions
{
    public static class HolidayDtoConversions
    {
        public static IEnumerable<ResponseHolidayDTO> ConvertToDto(this IEnumerable<Holiday> holidays)
        {
            return (from holiday in holidays
                    select new ResponseHolidayDTO
                    {
                        id = holiday.Id,
                        duration = holiday.Duration,
                        freeSlots = holiday.FreeSlots,
                        price = holiday.Price,
                        location = holiday.Location.ConvertToDto(),
                        title = holiday.Title,
                        startDate = DateOnly.Parse(holiday.StartDate)

                    }).ToList();
        }
        public static ResponseHolidayDTO ConvertToDto(this Holiday holiday)
        {
            return new ResponseHolidayDTO
            {
                id = holiday.Id,
                duration = holiday.Duration,
                freeSlots = holiday.FreeSlots,
                price = holiday.Price,
                location = holiday.Location.ConvertToDto(),
                title = holiday.Title,
                startDate = DateOnly.Parse(holiday.StartDate)
            };
        }
        public static Holiday ConvertToEntity(this CreateHolidayDTO holiday)
        {
            return new Holiday
            {
                Duration = holiday.duration,
                FreeSlots = holiday.freeSlots,
                Price = double.Parse(holiday.price),
                Title = holiday.title,
                StartDate = holiday.startDate.ToString(),
                LocationId = holiday.location
            };
        }

        public static Holiday ConvertToEntity(this UpdateHolidayDTO holiday)
        {
            return new Holiday
            {
                Id = holiday.id,
                Duration = holiday.duration,
                FreeSlots = holiday.freeSlots,
                Price = holiday.price,
                Title = holiday.title,
                StartDate = holiday.startDate.ToString(),
                LocationId = holiday.location
            };
        }
    }
}
