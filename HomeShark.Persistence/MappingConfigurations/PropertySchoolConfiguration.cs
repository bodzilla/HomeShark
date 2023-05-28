using HomeShark.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeShark.Persistence.MappingConfigurations
{
    internal sealed class PropertySchoolConfiguration : IEntityTypeConfiguration<PropertySchool>
    {
        public void Configure(EntityTypeBuilder<PropertySchool> builder)
        {
            builder.Property(x => x.EntityModified).HasDefaultValue(null);
            builder.Property(x => x.EntityActive).HasDefaultValue(true);

            builder.HasKey(x => new { x.PropertyId, x.SchoolId });

            builder.HasOne(bc => bc.Property)
                .WithMany(b => b.PropertySchools)
                .HasForeignKey(bc => bc.PropertyId);

            builder.HasOne(bc => bc.School)
                .WithMany(b => b.PropertySchools)
                .HasForeignKey(bc => bc.SchoolId);
        }
    }
}
