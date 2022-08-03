using EvoEvents.Business.Events;
using EvoEvents.Business.Events.Commands;
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
                    EventType = new EventTypeLookup
                    {
                        Id = EventType.Movie,
                        Name = EventType.Movie.ToString()
                    },
                    MaxNoAttendees = 10
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
        }
    }
}