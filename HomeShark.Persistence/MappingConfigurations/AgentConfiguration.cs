using HomeShark.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeShark.Persistence.MappingConfigurations
{
    internal sealed class AgentConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.Property(x => x.EntityModified).HasDefaultValue(null);
            builder.Property(x => x.EntityActive).HasDefaultValue(true);

            builder.Property(x => x.Name).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();

            builder.Property(x => x.Logo).IsRequired();

            builder.HasMany(x => x.AgentBranches)
                .WithOne(x => x.Agent)
                .HasForeignKey(x => x.AgentId);
        }
    }
}
