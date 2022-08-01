using EvoEvents.Data.Models.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvoEvents.Data.Configurations.Events
{
    internal class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(u => u.Name).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Description).HasMaxLength(2000);
            builder.Property(u => u.MaxNoAttendees).IsRequired();
        }
    }
}
