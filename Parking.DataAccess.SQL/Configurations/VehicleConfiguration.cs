using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parking.DataAccess.SQL.Entities;

namespace Parking.DataAccess.SQL.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);
            builder.Property(x => x.PersonId).IsRequired();
            builder.Property(x => x.CarNumber).HasMaxLength(50).IsRequired();

            builder.HasIndex(x => x.CarNumber).IsUnique();
        }
    }
}
