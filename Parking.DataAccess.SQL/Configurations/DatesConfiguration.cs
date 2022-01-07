using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parking.DataAccess.SQL.Entities;

namespace Parking.DataAccess.SQL.Configurations
{
    public class DatesConfiguration : IEntityTypeConfiguration<Dates>
    {
        public void Configure(EntityTypeBuilder<Dates> builder)
        {
            builder.ToTable("Dates");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);
            builder.Property(x => x.DateArrival).IsRequired();
            builder.Property(x => x.DateLeaving);

            builder.HasOne(x => x.Place).WithMany(x => x.Dates).HasForeignKey(x => x.IdPlace).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
