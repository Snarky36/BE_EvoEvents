using EvoEvents.Data.Models.Addresses;
using System;

namespace EvoEvents.Data.Models.Events
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxNoAttendees { get; set; }
        public EventType EventTypeId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public virtual EventTypeLookup EventType { get; set; }
        public Address Address { get; set; } 
    }
}