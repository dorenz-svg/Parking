﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parking.DataAccess.SQL.Entities;

namespace Parking.DataAccess.SQL.Configurations
{
    public class PlaceConfiguration : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.ToTable("Places");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);
            builder.Property(x => x.IdPerson);
            builder.Property(x => x.IdRates).IsRequired();
            builder.Property(x => x.IdVehicle);

            builder.HasMany(x => x.Dates).WithOne(x => x.Place).HasForeignKey(x => x.IdPlace).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Vehicle).WithMany(x => x.Places).HasForeignKey(x => x.IdVehicle).OnDelete(DeleteBehavior.ClientCascade);
            builder.HasOne(x => x.Person).WithMany(x => x.Places).HasForeignKey(x => x.IdPerson).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Rates).WithMany(x => x.Places).HasForeignKey(x => x.IdRates).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
