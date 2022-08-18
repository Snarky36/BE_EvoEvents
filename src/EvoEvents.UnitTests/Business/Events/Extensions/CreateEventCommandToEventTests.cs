using EvoEvents.Business.Events;
using EvoEvents.Business.Events.Commands;
using EvoEvents.Data.Models.Addresses;
using EvoEvents.Data.Models.Events;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace EvoEvents.UnitTests.Business.Events.Extensions
{
    [TestFixture]
    public class CreateUserCommandToUserTest
    {
        [Test]
        public void ShouldReturnCorrectCreateUserCommand()
        {
            var request = new CreateEventCommand
            {
                Name = "EvoEvent",
                Description = "foarte fain",
                EventType = (EventType)2,
                MaxNoAttendees = 10,
                Location = "Strada Bisericii Sud",
                City = City.Milano,
                Country = Country.Italia,
                FromDate = DateTime.Now.AddDays(1),
                ToDate = DateTime.Now.AddDays(2)
            };

            var result = request.ToEvent();

            result.Name.Should().Be(request.Name);
            result.Description.Should().Be(request.Description);
            result.EventTypeId.Should().Be(request.EventType);
            result.MaxNoAttendees.Should().Be(request.MaxNoAttendees);
            result.Address.Location.Should().Be(request.Location);
            result.Address.CountryId.Should().Be(request.Country);
            result.Address.CityId.Should().Be(request.City);
            result.FromDate.Should().Be(request.FromDate);
            result.ToDate.Should().Be(request.ToDate);
        }
    }
}