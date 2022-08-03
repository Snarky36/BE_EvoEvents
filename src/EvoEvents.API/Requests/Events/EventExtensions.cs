using EvoEvents.API.Requests.Versions;
using EvoEvents.Business.Events.Commands;
using EvoEvents.Business.Events.Queries;
using EvoEvents.Business.Users.Commands;

namespace EvoEvents.API.Requests.Events
{
    public static class EventExtensions
    {
        public static ViewEventQuery ToQuery(this ViewEventRequest request)
        {
            return new ViewEventQuery
            {
                Id = request.Id
            };
        }
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