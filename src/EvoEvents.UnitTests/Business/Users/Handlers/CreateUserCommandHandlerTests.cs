using Moq;
using Moq.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using FluentAssertions;
using EvoEvents.Data;
using EvoEvents.Business.Users.Handlers;
using EvoEvents.Business.Users.Commands;
using EvoEvents.Data.Models.Users;
using System;

namespace EvoEvents.UnitTests.Business.Users.Handlers
{
    [TestFixture]
    public class CreateUserCommandTests
    {
        private Mock<EvoEventsContext> _context;
        private CreateUserCommandHandlers _handler;
        private CreateUserCommand _request;

        [SetUp]
        public void Init()
        {
            _context = new Mock<EvoEventsContext>();
            _handler = new CreateUserCommandHandlers(_context.Object);

            SetupValidRequest();
            SetupContext();
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
            var result = await _handler.Handle(_request, new CancellationToken());
            _context.Verify( m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task WhenDuplicateEmail_ShouldThrowException()
        {
            _request.Email = "asd@asd.com";
            Func<Task> act = async () => await _handler.Handle(_request, new CancellationToken());
            
            await act.Should().ThrowAsync<ApplicationException>()
                        .WithMessage("Email should be unique");
        }

        private void SetupContext()
        {
            var users = new List<User>
            {
                new User
                {
                    Email = "asd@asd.com",
                    Password = "123ASDF",
                    Information = new UserDetail
                    {
                        FirstName = "absc",
                        LastName = "asdfg",
                        Company = "comnapi"
                    }
                }
            };

            _context.Setup(c => c.Users).ReturnsDbSet(users);
        }

        private void SetupValidRequest()
        {
            _request = new CreateUserCommand {
                FirstName = "Ion",
                LastName = "Snow",
                Email = "ion@snow.com",
                Company = "Accessa",
                Password = "tradator"
            };
        }

        private void SetupInvalidRequest()
        {
            _request = new CreateUserCommand
            {
                LastName = null,
                Email = "ion@snow.comion@snow.comion@snow.comion@snow.comion@snow.comion@snow.comion@snow.comion@snow.comion@snow.comion@snow.comion@snow.comion@snow.comion@snow.comion@snow.comion@snow.comion@snow.comion@snow.comion@snow.comion@snow.comion@snow.comion@snow.comion@snow.comion@snow.comion@snow.comion@snow.comion@snow.comion@snow.comion@snow.comion@snow.comion@snow.comion@snow.comion@snow.comion@snow.com",
                Company = "Accessa",
                Password = "tradator"
            };
        }
    }
}
