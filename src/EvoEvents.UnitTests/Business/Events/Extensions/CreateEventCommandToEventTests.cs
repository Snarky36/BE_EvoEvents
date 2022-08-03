using EvoEvents.Business.Events;
using EvoEvents.Business.Events.Commands;
using EvoEvents.Data.Models.Events;
using FluentAssertions;
using NUnit.Framework;

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
                MaxNoAttendees = 10
            };

            var result = request.ToEvent();

            result.Name.Should().Be(request.Name);
            result.Description.Should().Be(request.Description);
            result.EventTypeId.Should().Be(request.EventType);
            result.MaxNoAttendees.Should().Be(request.MaxNoAttendees);
        }
    }
}