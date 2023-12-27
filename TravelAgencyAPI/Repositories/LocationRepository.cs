using Microsoft.EntityFrameworkCore;
using TravelAgencyAPI.Data;
using TravelAgencyAPI.Entities;
using TravelAgencyAPI.Extensions;
using TravelAgencyAPI.Repositories.Contracts;
using TravelAgencyModels.DTOs;

namespace TravelAgencyAPI.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly TravelAgencyDbContext travelAgencyDbContext;

        public LocationRepository(TravelAgencyDbContext travelAgencyDbContext)
        {
            this.travelAgencyDbContext = travelAgencyDbContext;
        }
        public async Task<Location> DeleteItem(long id)
        {
            var item = await this.travelAgencyDbContext.Locations.FindAsync(id);

            if (item != null)
            {
                this.travelAgencyDbContext.Locations.Remove(item);
                await this.travelAgencyDbContext.SaveChangesAsync();
            }
            return item;
        }

        public async Task<Location> GetItem(long id)
        {
           var location = await travelAgencyDbContext.Locations.FindAsync(id);

            return location;
        }

        public async Task<IEnumerable<Location>> GetItems()
        {
            var locations = await this.travelAgencyDbContext.Locations.ToListAsync();

            return locations;
        }

        public async Task<Location> AddItem(CreateLocationDTO location)
        {
            //Validations
            //..

            var result = await this.travelAgencyDbContext.Locations.AddAsync(location.ConvertToEntity());

            await this.travelAgencyDbContext.SaveChangesAsync();

            return result.Entity;
           
        }

        public async Task<Location> PutItem(UpdateLocationDTO location)
        {
            //Validations
            //..
            var result = travelAgencyDbContext.Locations.Update(location.ConvertToEntity());

            await this.travelAgencyDbContext.SaveChangesAsync();

            return result.Entity;
        }
    }
}
