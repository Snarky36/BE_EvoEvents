﻿using EvoEvents.Business.Events.Handlers;
using EvoEvents.Business.Events.Queries;
using EvoEvents.Data;
using EvoEvents.Data.Models.Addresses;
using EvoEvents.Data.Models.Events;
using FluentAssertions;
using Infrastructure.Utilities;
using Moq;
using Moq.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EvoEvents.UnitTests.Business.Events.Handlers
{
    [TestFixture]
    public class ViewAllEventsQueryHandlerTests
    {
        private Mock<EvoEventsContext> _context;
        private ViewAllEventsQueryHandler _handler;
        private ViewAllEventsQuery _query;
        private string descriptionString = PrimitiveGenerator.Alphanumeric(160);

        [SetUp]
        public void Init()
        {
            _context = new Mock<EvoEventsContext>();
            _handler = new ViewAllEventsQueryHandler(_context.Object);

            SetupContext();
            SetupRequest();
        }

        [TearDown]
        public void Clean()
        {
            _context = null;
            _handler = null;
        }

        [Test]
        public async Task WhenViewAllEventsIsCorrect_ShouldReturnCorrectEventInformation()
        {
            var result = await _handler.Handle(_query, new CancellationToken());

            result.TotalNoItems.Should().Be(2);
            result.Items.First().Id.Should().Be(1);
            result.Items.First().Name.Should().Be("EvoEvent");
            result.Items.First().Description.Should().Be(descriptionString.Substring(0, 150));
            result.Items.First().EventType.Should().Be(EventType.Movie);
            result.Items.First().MaxNoAttendees.Should().Be(10);
            result.Items.First().Address.City.Should().Be(City.Milano);
            result.Items.First().Address.Country.Should().Be(Country.Italia);
            result.Items.First().Address.Location.Should().Be("Strada Bisericii Sud");
        }

        [Test]
        public async Task WhenEventsAreNotFound_ShouldReturnEmptyList()
        {
            _query.PageNumber = 100000000;
            var result = await _handler.Handle(_query, new CancellationToken());

            result.TotalNoItems.Should().Be(2);
            result.Items.Should().BeEmpty();
        }

        private void SetupContext()
        {
            var events = new List<Event>
            {
               new Event
                {
                    Id=1,
                    Name = "EvoEvent",
                    Description = descriptionString,
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
                },
               new Event
                {
                    Id=2,
                    Name = "EvoEvent2",
                    Description = descriptionString,
                    EventType = new EventTypeLookup
                    {
                        Id = EventType.Movie,
                        Name = EventType.Movie.ToString()
                    },
                    MaxNoAttendees = 15,
                    Address = new Address
                    {
                        Location = "Strada Bisericii Sud2",
                        CityId = City.Milano,
                        CountryId = Country.Italia
                    }
                }
            };

            _context.Setup(c => c.Events).ReturnsDbSet(events);
        }

        private void SetupRequest()
        {
            _query = new ViewAllEventsQuery
            {
                PageNumber = 1,
                ItemsPerPage = 1
            };
        }
    }
}