using EvoEvents.Data.Configurations.Addresses;
using EvoEvents.Data.Configurations.ApplicationVersions;
using EvoEvents.Data.Configurations.Events;
using EvoEvents.Data.Configurations.Users;
using EvoEvents.Data.Models.Addresses;
using EvoEvents.Data.Models.ApplicationVersions;
using EvoEvents.Data.Models.Events;
using EvoEvents.Data.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

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
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventTypeLookup> EventTypeLookups { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<CityLookup> CityLookups { get; set; }
        public virtual DbSet<CountryLookup> CountryLookups { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ApplicationVersionConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserDetailConfiguration());
            builder.ApplyConfiguration(new EventConfiguration());
            builder.ApplyConfiguration(new EventTypeConfiguration());
            builder.ApplyConfiguration(new CityConfiguration());
            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new AddressConfiguration());
        }
    }
}
