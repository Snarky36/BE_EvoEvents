using EvoEvents.Business.Addresses.Models;
using EvoEvents.Business.Events.Commands;
using EvoEvents.Business.Events.Handlers;
using EvoEvents.Business.Events.Queries;
using EvoEvents.Data;
using EvoEvents.Data.Models.Addresses;
using EvoEvents.Data.Models.Events;
using FluentAssertions;
using Infrastructure.Utilities.CustomException;
using Infrastructure.Utilities.Errors;
using Moq;
using Moq.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EvoEvents.UnitTests.Business.Events.Handlers
{
    [TestFixture]
    public class ViewEventQueryHandlerTests
    {
        private Mock<EvoEventsContext> _context;
        private ViewEventQueryHandler _handler;
        private ViewEventQuery _query;

        [SetUp]
        public void Init()
        {
            _context = new Mock<EvoEventsContext>();
            _handler = new ViewEventQueryHandler(_context.Object);

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
        public async Task WhenEventIsFound_ShouldReturnCorrectEventInformation()
        {
            var result = await _handler.Handle(_query, new CancellationToken());

            result.Id.Should().Be(1);
            result.Name.Should().Be("EvoEvent");
            result.Description.Should().Be("super");
            result.EventType.Should().Be(EventType.Movie);
            result.MaxNoAttendees.Should().Be(10);
            result.Address.Should().BeEquivalentTo(
                new AddressInformation
                {
                    Location = "Strada Bisericii Sud",
                    City = City.Milano,
                    Country = Country.Italia
                });
        }

        [Test]
        public async Task WhenEventIsNotFound_ShouldThrowException()
        {
            _query.Id = 100000;
            var exceptionMessage = new CustomException(ErrorCode.Event_NotFound, ErrorMessage.IdNotFoundError).Message;
            Func<Task> act = async () => await _handler.Handle(_query, new CancellationToken());

            await act.Should().ThrowAsync<CustomException>()
                 .WithMessage(exceptionMessage);
        }

        private void SetupContext()
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
                    MaxNoAttendees = 10,
                    Address = new Address
                    {
                        Location = "Strada Bisericii Sud",
                        CityId = City.Milano,
                        CountryId = Country.Italia
                    }
               }
            };

            _context.Setup(c => c.Events).ReturnsDbSet(events);
        }

        private void SetupRequest()
        {
            _query = new ViewEventQuery
            {
                Id=1
            };
        }
    }
}