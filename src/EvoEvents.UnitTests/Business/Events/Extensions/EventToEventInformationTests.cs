﻿using EvoEvents.Business.Addresses.Models;
using EvoEvents.Business.Events;
using EvoEvents.Data.Models.Addresses;
using EvoEvents.Data.Models.Events;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace EvoEvents.UnitTests.Business.Events.Extensions
{
    [TestFixture]
    public class EventToEventInformationTests
    {
        private IQueryable<Event> _events;

        [SetUp]
        public void Innit()
        {
            SetupEvents();
        }

        private void SetupEvents()
        {
            var events = new List<Event>
            {
                new Event
                {
                    Id=1,
                    Name = "EvoEvent",
                    Description = "super",
                    EventTypeId = EventType.Movie,
                    MaxNoAttendees = 10,
                    Address = new Address
                    {
                        Location = "Strada Bisericii Sud",
                        CityId = City.Milano,
                        CountryId = Country.Italia
                    }
                }
            };

            _events = events.AsQueryable();
        }

        [Test]
        public void ShouldReturnCorrectEventInformation()
        {   
            var eventInformation = _events.ToEventInformation().FirstOrDefault();

            eventInformation.Id.Should().Be(1);
            eventInformation.Name.Should().Be("EvoEvent");
            eventInformation.Description.Should().Be("super");
            eventInformation.EventType.Should().Be(EventType.Movie);
            eventInformation.MaxNoAttendees.Should().Be(10);
            eventInformation.Address.Should().BeEquivalentTo(
                new AddressInformation
                {
                    Location = "Strada Bisericii Sud",
                    City = City.Milano,
                    Country = Country.Italia
                });
        }
    }
}