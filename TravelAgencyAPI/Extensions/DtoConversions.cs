using TravelAgencyAPI.Entities;
using TravelAgencyModels.DTOs;

namespace TravelAgencyAPI.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<ResponseLocationDTO> ConvertToDto(this IEnumerable<Location> locations)
        {
            return (from location in locations
                    select new ResponseLocationDTO
                    {
                        id = location.Id,
                        number = location.Number,
                        country= location.Country,
                        city= location.City,
                        street = location.Street,
                        imageUrl= location.ImageUrl
                    }).ToList();
        }

        public static ResponseLocationDTO ConvertToDto(this Location location)
        {
            return new ResponseLocationDTO
            {
                id = location.Id,
                number = location.Number,
                country = location.Country,
                city = location.City,
                street = location.Street,
                imageUrl = location.ImageUrl
            };
        }

        public static Location ConvertToEntity(this CreateLocationDTO location)
        {
            return new Location
            {
                Street = location.street,
                Number = location.number,
                City = location.city,
                Country = location.country,
                ImageUrl = location.imageUrl
            };
        }

        public static Location ConvertToEntity(this UpdateLocationDTO location)
        {
            return new Location
            {
                Id = location.id,
                Street = location.street,
                Number = location.number,
                City = location.city,
                Country = location.country,
                ImageUrl = location.imageUrl
            };
        }
    }
}
