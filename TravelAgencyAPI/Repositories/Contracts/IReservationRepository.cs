using TravelAgencyAPI.Entities;
using TravelAgencyModels.DTOs;

namespace TravelAgencyAPI.Repositories.Contracts
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetItems();
        Task<IEnumerable<Reservation>> GetItems(String phoneNumber);
        Task<Reservation> GetItem(long id);
        Task<Reservation> DeleteItem(long id);
        Task<Reservation> AddItem(CreateReservationDTO reservation);
        Task<Reservation> PutItem(UpdateReservationDTO reservation);
    }
}
