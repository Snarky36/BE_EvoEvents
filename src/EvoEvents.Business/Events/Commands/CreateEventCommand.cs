using EvoEvents.Data.Models.Addresses;
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
        public string Location { get; set; }
        public City City { get; set; }
        public Country Country { get; set; }
    }
}