using TravelAgencyAPI.Entities;
using TravelAgencyModels.DTOs;

namespace TravelAgencyAPI.Repositories.Contracts
{
    public interface IHolidayRepository
    {
        Task<IEnumerable<Holiday>> GetItems();
        Task<IEnumerable<Holiday>> GetItems(int? duration);
        Task<IEnumerable<Holiday>> GetItems(DateTime? startDate);
        Task<IEnumerable<Holiday>> GetItems(string? location);

        Task<IEnumerable<Holiday>> GetItems(Location? location);
        Task<Holiday> GetItem(long? id);
        Task<Holiday> PutItem(UpdateHolidayDTO holiday);
        Task<Holiday> AddItem(CreateHolidayDTO holiday);
        Task<Holiday> DeleteItem(long id);
    }
}
