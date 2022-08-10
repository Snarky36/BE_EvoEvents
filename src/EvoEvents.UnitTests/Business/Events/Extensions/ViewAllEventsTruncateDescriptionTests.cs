using EvoEvents.Business.Events;
using EvoEvents.Business.Events.Models;
using EvoEvents.Data.Models.Addresses;
using EvoEvents.Data.Models.Events;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace EvoEvents.UnitTests.Business.Events.Extensions
{

    [TestFixture]
    public class ViewAllEventsTruncateDescriptionTests
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
                    Description = "A wonderful serenity has taken possession of my entire soul, " +
                    "like these sweet mornings of spring which " +
                    "I enjoy with my whole heart. I am alone, and " +
                    "feel the charm of existence in this spot, which was.",
                    EventType = new EventTypeLookup
                    {
                        Id = EventType.Movie,
                        Name = EventType.Movie.ToString()
                    },
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
        public void ShouldReturnCorrectTruncatedDescription()
        {
            var events =  _events.ToEventInformation(150);
            

            events.First().Description.Should().Be("A wonderful serenity has taken possession of my entire soul, " +
                "like these sweet mornings of spring which I enjoy with my whole heart. I am alone, and fe");
        }
    }
}