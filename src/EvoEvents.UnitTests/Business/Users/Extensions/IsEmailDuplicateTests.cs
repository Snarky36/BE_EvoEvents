using EvoEvents.Business.Users;
using EvoEvents.Business.Users.Commands;
using EvoEvents.Data.Models.Users;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace EvoEvents.UnitTests.Business.Users.Extensions
{
    [TestFixture]
    public class UsersIsEmailDuplicateTests
    {
        private CreateUserCommand _command;
        private IQueryable<User> _users;

        [SetUp]
        public void Init()
        {
            SetupCommand();
            SetupUsers();
        }

        private void SetupUsers()
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

            _users = users.AsQueryable();
        }

        private void SetupCommand()
        {
            _command = new CreateUserCommand
            {
                FirstName = "Radu",
                LastName = "mifdas",
                Company = "fdasfa",
                Email = "asccc@hh.com",
                Password = "kila"
            };
        }

        [Test]
        public void ShouldReturnTrue()
        {
            _command.Email = "asd@asd.com";
            var result = _users.IsEmailDuplicate(_command);
            result.Should().BeTrue();
        }

        [Test]
        public void ShouldReturnFalse()
        {
            var result = _users.IsEmailDuplicate(_command);
            result.Should().BeFalse();
        }
    }
}
