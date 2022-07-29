using EvoEvents.Data.Configurations.ApplicationVersions;
using EvoEvents.Data.Configurations.Users;
using EvoEvents.Data.Models.ApplicationVersions;
using EvoEvents.Data.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace EvoEvents.Data
{
    public class EvoEventsContext : DbContext
    {
        public EvoEventsContext() { }

        public EvoEventsContext(DbContextOptions options) : base(options)
        { }

        public virtual DbSet<ApplicationVersion> ApplicationVersions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ApplicationVersionConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserDetailConfiguration());
        }
    }
}
