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
        }
    }
}
