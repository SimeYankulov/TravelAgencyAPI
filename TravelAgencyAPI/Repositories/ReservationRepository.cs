using Microsoft.EntityFrameworkCore;
using System.Linq;
using TravelAgencyAPI.Data;
using TravelAgencyAPI.Entities;
using TravelAgencyAPI.Extensions;
using TravelAgencyAPI.Repositories.Contracts;
using TravelAgencyModels.DTOs;

namespace TravelAgencyAPI.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly TravelAgencyDbContext travelAgencyDbContext;

        public ReservationRepository(TravelAgencyDbContext travelAgencyDbContext)
        {
            this.travelAgencyDbContext = travelAgencyDbContext;
        }

        public async Task<Reservation> AddItem(CreateReservationDTO reservation)
        {
            var result = await this.travelAgencyDbContext.Reservations.AddAsync(reservation.ConvertToEntity());

            await this.travelAgencyDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Reservation> DeleteItem(long id)
        {
            var item = await this.travelAgencyDbContext.Reservations.FindAsync(id);

            if (item != null)
            {
                this.travelAgencyDbContext.Reservations.Remove(item);
                await this.travelAgencyDbContext.SaveChangesAsync();
            }
            return item;
        }

        public async Task<Reservation> GetItem(long id)
        {
            var reservation = await travelAgencyDbContext.Reservations
                                               .Include(r => r.Holiday)
                                               .ThenInclude(h => h.Location)
                                               .SingleOrDefaultAsync(r => r.Id == id);

            return reservation;
        }

        public async Task<IEnumerable<Reservation>> GetItems()
        {
            var reservations = await this.travelAgencyDbContext.Reservations
                    .Include(r => r.Holiday)
                    .ThenInclude(h => h.Location)
                    .ToListAsync();

            return reservations;
        }

        public async Task<Reservation> PutItem(UpdateReservationDTO reservation)
        {
            var resultId = travelAgencyDbContext.Reservations.Update(reservation.ConvertToEntity()).Entity.Id;
            await this.travelAgencyDbContext.SaveChangesAsync();

            var result = await GetItem(resultId);

            return result;
        }
    }
}
