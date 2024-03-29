﻿using Microsoft.EntityFrameworkCore;
using TravelAgencyAPI.Data;
using TravelAgencyAPI.Entities;
using TravelAgencyAPI.Extensions;
using TravelAgencyAPI.Repositories.Contracts;
using TravelAgencyModels.DTOs;

namespace TravelAgencyAPI.Repositories
{
    public class HolidayRepository : IHolidayRepository
    {
        private readonly TravelAgencyDbContext travelAgencyDbContext;
        public HolidayRepository(TravelAgencyDbContext travelAgencyDbContext)
        {
            this.travelAgencyDbContext = travelAgencyDbContext;
        }
        public async Task<Holiday> AddItem(CreateHolidayDTO holiday)
        {

            var result = await this.travelAgencyDbContext.Holidays.AddAsync(holiday.ConvertToEntity());

            await this.travelAgencyDbContext.SaveChangesAsync();

            return result.Entity;

        }
        public async Task<Holiday> DeleteItem(long id)
        {

            var item = await this.travelAgencyDbContext.Holidays.FindAsync(id);

            if (item != null)
            {
                this.travelAgencyDbContext.Holidays.Remove(item);
                await this.travelAgencyDbContext.SaveChangesAsync();
            }
            return item;
        }
        public async Task<Holiday> GetItem(long? id)
        {
            var holiday = await travelAgencyDbContext.Holidays.
                                                        Include(h => h.Location)
                                                        .SingleOrDefaultAsync(h => h.Id == id);

            return holiday;
        }
        public async Task<IEnumerable<Holiday>> GetItems()
        {
            var holidays = await this.travelAgencyDbContext.Holidays
                  .Include(h => h.Location).ToArrayAsync();

            return holidays;
        }
        public async Task<IEnumerable<Holiday>> GetItems(int? duration)
        {

                var holidays = await this.travelAgencyDbContext.Holidays
                                   .Include(h => h.Location)
                                   .Where(h => h.Duration == duration)
                                   .ToArrayAsync();    
              
                return holidays;

        }
        public async Task<IEnumerable<Holiday>> GetItems(DateTime? date)
        {
            var justDate = date.Value.ToShortDateString();
            var holidays = await this.travelAgencyDbContext.Holidays
                           .Include(h => h.Location)
                           .Where(h => h.StartDate == justDate)
                           .ToArrayAsync();

            return holidays;
        }
        public async Task<IEnumerable<Holiday>> GetItems(String? location)
        {
            var holidays = await this.travelAgencyDbContext.Holidays
                           .Include(h => h.Location)
                           .Where(h => 
                           h.Location.Country == location || h.Location.City == location)
                          
                           .ToArrayAsync();

            return holidays;
        }
        public async Task<IEnumerable<Holiday>> GetItems(Location? location)
        {
            
                var holidays = await this.travelAgencyDbContext.Holidays
                                           .Include(h => h.Location)
                                           .Where(h => h.Location == location)
                                           .ToArrayAsync();

                return holidays;
            
        }

        public async Task<Holiday> PutItem(UpdateHolidayDTO holiday)
        {
            //Validations
            //..
            
            var resultId = travelAgencyDbContext.Holidays.Update(holiday.ConvertToEntity()).Entity.Id;
            await this.travelAgencyDbContext.SaveChangesAsync();

            //result.Entity.Location = await travelAgencyDbContext.Locations.FindAsync(result.Entity.LocationId);

            var result = await GetItem(resultId);

            return result;
        }
    }
}
