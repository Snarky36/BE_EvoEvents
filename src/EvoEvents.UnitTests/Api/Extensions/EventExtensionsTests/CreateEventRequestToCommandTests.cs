﻿using EvoEvents.API.Requests.Events;
using EvoEvents.Data.Models.Events;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace EvoEvents.UnitTests.Api.Extensions.EventExtensionsTests
{
    [TestFixture]
    public class CreateEventRequestToCommandTests
    {
        [Test]
        public void ShouldReturnCorrectCreateEventCommand()
        {
            var request = new CreateEventRequest
            {
                Name = "EvoEvents",
                Description = "fain",
                EventType = (EventType)2,
                MaxNoAttendees = 15
            };

            var result = request.ToCommand();

            result.Name.Should().Be(request.Name);
            result.Description.Should().Be(request.Description);
            result.EventType.Should().Be(request.EventType);
            result.MaxNoAttendees.Should().Be(request.MaxNoAttendees);
        }
    }
}