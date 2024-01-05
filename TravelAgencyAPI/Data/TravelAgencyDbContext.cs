using Microsoft.EntityFrameworkCore;
using TravelAgencyAPI.Entities;

namespace TravelAgencyAPI.Data
{
    public class TravelAgencyDbContext : DbContext
    {
        public TravelAgencyDbContext(DbContextOptions<TravelAgencyDbContext> options) : base(options)
        {

        }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Holiday> Holidays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Location>().HasData(new Location
            {
                Id = 1,
                Number = "number",
                Country = "country",
                City = "city",
                Street = "street",
                ImageUrl = "imageUrl"
            });

            modelBuilder.Entity<Holiday>().HasData(new Holiday
            {
                Id = 1,
                FreeSlots = 2,
                Price = 5.5,
                Title = "Title",
                StartDate = "2000-1-1",
                LocationId= 1
            });
        }
    }
}
