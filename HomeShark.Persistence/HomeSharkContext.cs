using HomeShark.Core.Models;
using HomeShark.Persistence.MappingConfigurations;
using Microsoft.EntityFrameworkCore;

namespace HomeShark.Persistence
{
    public sealed class HomeSharkContext : DbContext
    {
        public DbSet<Agent> Agents { get; set; }

        public DbSet<AgentBranch> AgentBranches { get; set; }

        public DbSet<Property> Properties { get; set; }

        public DbSet<KeyFeature> KeyFeatures { get; set; }

        public DbSet<School> Schools { get; set; }

        public DbSet<Station> Stations { get; set; }

        public DbSet<PropertySchool> PropertySchools { get; set; }

        public DbSet<PropertyStation> PropertyStations { get; set; }

        public DbSet<Media> Media { get; set; }

        public HomeSharkContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder) => builder
            .ApplyConfiguration(new AgentConfiguration())
            .ApplyConfiguration(new AgentBranchConfiguration())
            .ApplyConfiguration(new PropertyConfiguration())
            .ApplyConfiguration(new KeyFeatureConfiguration())
            .ApplyConfiguration(new StationConfiguration())
            .ApplyConfiguration(new SchoolConfiguration())
            .ApplyConfiguration(new PropertyStationConfiguration())
            .ApplyConfiguration(new PropertySchoolConfiguration())
            .ApplyConfiguration(new MediaConfiguration());
    }
}