using EvoEvents.Business.Addresses.Models;
using EvoEvents.Data.Models.Events;
using System;

namespace EvoEvents.Business.Events.Models
{
    public record EventInformation
    {   
        public int Id { get; set; }
        public EventType EventType { get; init; }
        public string Name { get; init; }
        public string Description { get; set; }
        public int MaxNoAttendees { get; init; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public AddressInformation Address { get; init; }
    }
}