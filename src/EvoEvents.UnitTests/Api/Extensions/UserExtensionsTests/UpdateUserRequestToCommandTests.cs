using EvoEvents.API.Requests.Users;
using FluentAssertions;
using NUnit.Framework;

namespace EvoEvents.UnitTests.Api.Extensions.UserExtensionsTests
{
    [TestFixture]
    public class UpdateUserRequestToCommandTests
    {
        [Test]
        public void ShouldReturnCorrectUpdateUserCommand()
        {
            var request = new UpdateUserRequest
            {
                Email = "maria234@yahoo.com",
                NewFirstName = "Maria",
                NewLastName = "Oltean",
                NewCompany = "Evozon",
                Password = "maria123",
                NewPassword = "maria1234"
            };

            var result = request.ToCommand();

            result.Email.Should().Be(request.Email);
            result.NewFirstName.Should().Be(request.NewFirstName);
            result.NewLastName.Should().Be(request.NewLastName);
            result.NewCompany.Should().Be(request.NewCompany);
            result.Password.Should().Be(request.Password);
            result.NewPassword.Should().Be(request.NewPassword);
        }
    }
}
