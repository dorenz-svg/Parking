using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parking.DataAccess.SQL.Entities;

namespace Parking.DataAccess.SQL.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.SurName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(11).IsRequired();

            builder.HasIndex(x => x.Phone).IsUnique();
            builder.HasMany(x => x.Vehicles).WithOne(x => x.Person).HasForeignKey(x => x.IdPerson).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
