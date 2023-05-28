using HomeShark.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeShark.Persistence.MappingConfigurations
{
    internal sealed class SchoolConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.Property(x => x.EntityModified).HasDefaultValue(null);
            builder.Property(x => x.EntityActive).HasDefaultValue(true);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.SchoolType).IsRequired();
            builder.Property(x => x.Latitude).IsRequired();
            builder.Property(x => x.Longitude).IsRequired();

            builder.HasIndex(x => new { x.Name, x.SchoolType });
        }
    }
}
