using EvoEvents.API.Requests.Events;
using EvoEvents.Business.Events.Commands;
using EvoEvents.Business.Events.Handlers;
using EvoEvents.Data;
using EvoEvents.Data.Models.Addresses;
using EvoEvents.Data.Models.Events;
using Microsoft.AspNetCore.Http;
using Moq;
using Moq.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
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
                Description = "foarte fain",
                EventType = (EventType)2,
                MaxNoAttendees = 10,
                Location = "Strada Bisericii Sud",
                City = City.Milano,
                FromDate = DateTime.Now.AddDays(1),
                ToDate = DateTime.Now.AddDays(2),
                Country = Country.Italia,
                EventImage = SetupFile().FileToByteArray()
            };
        }

        private byte[] SetupByteArray()
        {
            var base64Image = "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mNkqAcAAIUAgUW0RjgAAAAASUVORK5CYII=";
            byte[] content = Convert.FromBase64String(base64Image);
            return content;
        }

        private IFormFile SetupFile()
        {
            var fileMock = new Mock<IFormFile>();
            byte[] content = SetupByteArray();
            var fileName = "test.png";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);
            return fileMock.Object;
        }
    }
}