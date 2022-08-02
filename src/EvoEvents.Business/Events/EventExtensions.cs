using EvoEvents.Business.Events.Commands;
using EvoEvents.Data.Models.Events;

namespace EvoEvents.Business.Events
{
    public static class EventExtensions
    {
        public static Event ToEvent(this CreateEventCommand command)
        {
            return new Event
            { 
                EventTypeId = command.EventType,
                Name = command.Name,
                Description = command.Description,
                MaxNoAttendees = command.MaxNoAttendees
            };
        }
    }
}
