using EvoEvents.Data.Configurations.ApplicationVersions;
using EvoEvents.Data.Models.ApplicationVersions;
using Microsoft.EntityFrameworkCore;

namespace EvoEvents.Data
{
    public class EvoEventsContext : DbContext
    {
        public EvoEventsContext() { }

        public EvoEventsContext(DbContextOptions options) : base(options)
        { }

        public virtual DbSet<ApplicationVersion> ApplicationVersions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ApplicationVersionConfiguration());
        }
    }
}
