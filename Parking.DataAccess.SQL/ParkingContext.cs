using Microsoft.EntityFrameworkCore;
using Parking.DataAccess.SQL.Configurations;
using Parking.DataAccess.SQL.Entities;

namespace Parking.DataAccess.SQL
{
    public class ParkingContext : DbContext
    {
        public DbSet<Dates> Dates { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Rates> Rates { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(DatesConfiguration).Assembly);
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:localhost;Database=Parking;User ID=sa;Password=pass@word1;Trusted_Connection=False;Connection Timeout=30;Persist Security Info=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
