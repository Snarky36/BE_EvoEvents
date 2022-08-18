using EvoEvents.Business.Events.Commands;
using EvoEvents.Business.Events.Handlers;
using EvoEvents.Data;
using EvoEvents.Data.Models.Events;
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
    public class CreateEventCommandHandlerTests
    {
        private Mock<EvoEventsContext> _context;
        private CreateEventCommandHandler _handler;
        private CreateEventCommand _command;

        [SetUp]
        public void Init()
        {
            _context = new Mock<EvoEventsContext>();
            _handler = new CreateEventCommandHandler(_context.Object);

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
        public async Task ShouldCallSaveChangesAsync()
        {
            var result = await _handler.Handle(_command, new CancellationToken());
            _context.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }


        private void SetupContext()
        {   
            _context.Setup(c => c.Events).ReturnsDbSet(new List<Event> { });
        }

        private void SetupRequest()
        {
            _command = new CreateEventCommand
            {
                Name = "EvoEvent",
                Description = "super",
                EventType = (EventType)2,
                MaxNoAttendees = 10,
                FromDate = DateTime.Now.AddDays(1),
                ToDate = DateTime.Now.AddDays(2)
            };
        }
    }
}