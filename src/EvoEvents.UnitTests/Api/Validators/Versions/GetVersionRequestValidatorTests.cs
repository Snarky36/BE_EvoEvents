using AutoFixture;
using EvoEvents.API.Requests.Versions;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace EvoEvents.UnitTests.Api.Validators.Versions
{
    [TestFixture]
    public class GetVersionRequestValidatorTests
    {
        private GetVersionRequestValidator _validator;
        private IFixture _fixture;

        [SetUp]
        public void Init()
        {
            _validator = new GetVersionRequestValidator();
            _fixture = new Fixture();
        }

        [Test]
        public void WhenNameMissing_ShouldReturnError()
        {
            var model = _fixture.Build<GetVersionRequest>()
                .Without(x => x.Name)
                .Create();
            var result = _validator.Validate(model);

            result.Errors.Any(error => error.PropertyName == "Name").Should().BeTrue();
        }
    }
}
