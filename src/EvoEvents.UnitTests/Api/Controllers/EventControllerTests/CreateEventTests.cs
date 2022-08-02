using EvoEvents.API.Controllers;
using EvoEvents.API.Requests.Events;
using EvoEvents.Business.Events.Commands;
using EvoEvents.Data.Models.Events;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace EvoEvents.UnitTests.Api.Controllers.EventControllerTests
{
    [TestFixture]
    public class CreateEventTests
    {
        private EventController _controller;
        private Mock<IMediator> _mediator;
        private CreateEventRequest _request;

        [SetUp]
        public void Init()
        {
            _mediator = new Mock<IMediator>();

            _controller = new EventController(_mediator.Object);

            CreateRequest();
        }

        [TearDown]
        public void Clean()
        {
            _controller = null;
        }

        [Test]
        public async Task ShouldSendCreateEventCommand()
        {
            _mediator.Setup(m => m.Send(It.IsAny<CreateEventCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new bool()));

            var result = await _controller.CreateEvent(_request);

            _mediator.Verify(m => m.Send(It.IsAny<CreateEventCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task WhenRequestCompletes_ReturnStatusOk()
        {
            var result = await _controller.CreateEvent(_request);

            result.Result.Should().BeOfType<OkObjectResult>();
        }

        private void CreateRequest()
        {
            _request = new CreateEventRequest
            {
                Name = "EvoEvent",
                Description = "cel mai smecher summer party",
                EventType = (EventType)3,
                MaxNoAttendees = 15
            };
        }
    }
}
