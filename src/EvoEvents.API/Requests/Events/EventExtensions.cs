using EvoEvents.API.Requests.Versions;
using EvoEvents.Business.Events.Commands;
using EvoEvents.Business.Users.Commands;

namespace EvoEvents.API.Requests.Events
{
    public static class EventExtensions
    {
        public static CreateEventCommand ToCommand(this CreateEventRequest request)
        {
            return new CreateEventCommand
            {
                EventType = request.EventType,
                Name = request.Name,
                Description = request.Description,
                MaxNoAttendees = request.MaxNoAttendees
            };
        }
    }
}
