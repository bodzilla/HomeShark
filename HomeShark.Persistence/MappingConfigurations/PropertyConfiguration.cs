using HomeShark.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeShark.Persistence.MappingConfigurations
{
    internal sealed class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.Property(x => x.EntityModified).HasDefaultValue(null);
            builder.Property(x => x.EntityActive).HasDefaultValue(true);

            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Bedrooms).IsRequired();
            builder.Property(x => x.Bathrooms).IsRequired();
            builder.Property(x => x.Receptions).IsRequired();
            builder.Property(x => x.Area).IsRequired();
            builder.Property(x => x.Location).IsRequired();
            builder.Property(x => x.Latitude).IsRequired();
            builder.Property(x => x.Longitude).IsRequired();
            builder.Property(x => x.Postcode).IsRequired();

            builder.HasIndex(x => x.Area);
            builder.HasIndex(x => x.Location);
            builder.HasIndex(x => x.Postcode);

            builder.Ignore(x => x.Images);
            builder.Ignore(x => x.VirtualTours);
            builder.Ignore(x => x.Floorplans);
            builder.Ignore(x => x.Epcs);
            builder.Ignore(x => x.Documents);

            builder.HasMany(x => x.KeyFeatures)
                .WithOne(x => x.Property)
                .HasForeignKey(x => x.PropertyId);

            builder.HasMany(x => x.Media)
                .WithOne(x => x.Property)
                .HasForeignKey(x => x.PropertyId);
        }
    }
}
