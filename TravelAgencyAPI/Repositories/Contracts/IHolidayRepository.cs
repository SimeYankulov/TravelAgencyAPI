using TravelAgencyAPI.Entities;
using TravelAgencyModels.DTOs;

namespace TravelAgencyAPI.Repositories.Contracts
{
    public interface IHolidayRepository
    {
        Task<IEnumerable<Holiday>> GetItems();
        Task<Holiday> GetItem(long id);
        Task<Holiday> PutItem(UpdateHolidayDTO holiday);
        Task<Holiday> AddItem(CreateHolidayDTO holiday);
        Task<Holiday> DeleteItem(long id);
    }
}
