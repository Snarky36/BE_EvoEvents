using EvoEvents.Data.Models.Events;
using System;

namespace EvoEvents.Business.Events.Models
{
    public record EventInformation
    {   
        public int Id { get; set; } 
        public EventType EventType { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public int MaxNoAttendees { get; init; }
    }
}