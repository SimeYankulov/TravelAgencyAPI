using TravelAgencyAPI.Entities;
using TravelAgencyModels.DTOs;

namespace TravelAgencyAPI.Repositories.Contracts
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetItems();
        Task<Location> GetItem(long id);
        Task<Location> PutItem(UpdateLocationDTO location);
        Task<Location> AddItem(CreateLocationDTO location);
        Task<Location> DeleteItem(long id);

    }
}
