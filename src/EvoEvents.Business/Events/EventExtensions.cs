using EvoEvents.Business.Addresses;
using EvoEvents.Business.Events.Commands;
using EvoEvents.Business.Events.Models;
using EvoEvents.Data.Models.Addresses;
using EvoEvents.Data.Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;

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
                MaxNoAttendees = command.MaxNoAttendees,
                Address = new Address
                {
                    CityId = command.City,
                    CountryId = command.Country,
                    Location = command.Location
                }
            };
        }

        public static IQueryable<EventInformation> ToEventInformation(this IQueryable<Event> events)
        {
            return events.Select(e => new EventInformation
            {   
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                EventType = e.EventType.Id,
                MaxNoAttendees = e.MaxNoAttendees,
                Address = e.Address.ToAddressInformation()
            });
        }

        public static IQueryable<EventInformation> ToEventInformation(this IQueryable<Event> events, int descriptionMaxLength)
        {
            return events.Select(e => new EventInformation
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description.Substring(0, descriptionMaxLength),
                EventType = e.EventType.Id,
                MaxNoAttendees = e.MaxNoAttendees,
                Address = e.Address.ToAddressInformation()
            });
        }

        public static IQueryable<Event> FilterById(this IQueryable<Event> events, int id)
        {
            return events.Where(e => e.Id == id);
        }
    }
}