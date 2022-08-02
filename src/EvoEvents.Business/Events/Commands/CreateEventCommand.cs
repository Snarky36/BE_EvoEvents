using EvoEvents.Data.Models.Events;
using MediatR;

namespace EvoEvents.Business.Events.Commands
{
    public class CreateEventCommand : IRequest<bool>
    {
        public EventType EventType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public int MaxNoAttendees { get; set; }
    }
}
