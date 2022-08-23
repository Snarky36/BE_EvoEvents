﻿using EvoEvents.API.Requests.Events;
using EvoEvents.Business.Addresses.Models;
using EvoEvents.Business.Events.Handlers;
using EvoEvents.Business.Events.Queries;
using EvoEvents.Data;
using EvoEvents.Data.Models.Addresses;
using EvoEvents.Data.Models.Events;
using FluentAssertions;
using Infrastructure.Utilities.CustomException;
using Infrastructure.Utilities.Errors;
using Infrastructure.Utilities.Errors.ErrorMessages;
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
    public class ViewEventQueryHandlerTests
    {
        private Mock<EvoEventsContext> _context;
        private ViewEventQueryHandler _handler;
        private ViewEventQuery _query;
        private DateTime _fromDate;
        private DateTime _toDate;

        [SetUp]
        public void Init()
        {
            _context = new Mock<EvoEventsContext>();
            _handler = new ViewEventQueryHandler(_context.Object);
            _fromDate = DateTime.Now.AddDays(1);
            _toDate = DateTime.Now.AddDays(2);

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
                    City = "Cluj",
                    Country = "Romania"
                });
            result.FromDate.Should().Be(_fromDate);
            result.ToDate.Should().Be(_toDate);
        }

        [Test]
        public async Task WhenEventIsNotFound_ShouldThrowException()
        {
            _query.Id = 100000;
            var exceptionMessage = new CustomException(ErrorCode.Event_NotFound, EventErrorMessage.EventNotFound).Message;
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
                    EventTypeId = EventType.Movie,
                    MaxNoAttendees = 10,
                    Address = new Address
                    {
                        Location = "Strada Bisericii Sud",
                        CityCountriesId = 2,
                        CityCountries = new CityCountries
                        {
                            City = new CityLookup
                            {
                                Id = (City)1,
                                Name = "Cluj"
                            },
                            Country = new CountryLookup
                            {
                                Id = (Country)1,
                                Name = "Romania"
                            }

                        }
                    },
                    FromDate = _fromDate,
                    ToDate = _toDate,
                    Image = SetupFile().FileToByteArray()
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