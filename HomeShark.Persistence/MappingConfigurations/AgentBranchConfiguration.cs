using HomeShark.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeShark.Persistence.MappingConfigurations
{
    internal sealed class AgentBranchConfiguration : IEntityTypeConfiguration<AgentBranch>
    {
        public void Configure(EntityTypeBuilder<AgentBranch> builder)
        {
            builder.Property(x => x.EntityModified).HasDefaultValue(null);
            builder.Property(x => x.EntityActive).HasDefaultValue(true);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Location).IsRequired();
            builder.Property(x => x.Phone).IsRequired();

            builder.HasMany(x => x.Properties)
                .WithOne(x => x.AgentBranch)
                .HasForeignKey(x => x.AgentBranchId);
        }
    }
}
