using HomeShark.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeShark.Persistence.MappingConfigurations
{
    internal sealed class PropertyStationConfiguration : IEntityTypeConfiguration<PropertyStation>
    {
        public void Configure(EntityTypeBuilder<PropertyStation> builder)
        {
            builder.Property(x => x.EntityModified).HasDefaultValue(null);
            builder.Property(x => x.EntityActive).HasDefaultValue(true);

            builder.HasKey(x => new { x.PropertyId, x.StationId });

            builder.HasOne(bc => bc.Property)
                .WithMany(b => b.PropertyStations)
                .HasForeignKey(bc => bc.PropertyId);

            builder.HasOne(bc => bc.Station)
                .WithMany(b => b.PropertyStations)
                .HasForeignKey(bc => bc.StationId);
        }
    }
}
