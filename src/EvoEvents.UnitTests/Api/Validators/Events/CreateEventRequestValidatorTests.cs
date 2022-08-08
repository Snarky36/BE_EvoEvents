using EvoEvents.API.Requests.Events;
using EvoEvents.Data.Models.Addresses;
using EvoEvents.Data.Models.Events;
using FluentValidation.TestHelper;
using Infrastructure.Utilities;
using NUnit.Framework;

namespace EvoEvents.UnitTests.Api.Validators.Events
{
    [TestFixture]
    public class CreateEventRequestValidatorTests
    {
        private CreateEventRequestValidator _validator;
        private CreateEventRequest _request;

        [SetUp]
        public void Init()
        {
            _validator = new CreateEventRequestValidator();
            SetupRequest();
        }

        private void SetupRequest()
        {
            _request = new CreateEventRequest
            {
                Name = "EvoEvent",
                Description = "este fain",
                EventType = (EventType)2,
                MaxNoAttendees = 10,
                Location = "Strada Bisericii Sud",
                City = City.Milano,
                Country = Country.Italia
            };
        }

        [Test]
        public void WhenAddressLocationMissing_ShouldReturnError()
        {
            _request.Location = null;

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.Location);
        }

        [Test]
        public void WhenAddressLocationTooShort_ShouldReturnError()
        {
            _request.Location = PrimitiveGenerator.Alpha(2);

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.Location);
        }

        [Test]
        public void WhenAddressLocationTooLong_ShouldReturnError()
        {
            _request.Location = PrimitiveGenerator.Alpha(51);

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.Location);
        }

        [Test]
        public void WhenCityNotInEnum_ShouldReturnError()
        {
            _request.City = (City)(-2);

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.City);
        }

        [Test]
        public void WhenCountryNotInEnum_ShouldReturnError()
        {
            _request.Country = (Country)(-2);

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.Country);
        }

        [Test]
        public void WhenNameMissing_ShouldReturnError()
        {
            _request.Name = null;

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.Name);
        }

        [Test]
        public void WhenNameTooShortMissing_ShouldReturnError()
        {
            _request.Name = PrimitiveGenerator.Alpha(1);

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.Name);
        }

        [Test]
        public void WhenNameTooLong_ShouldReturnError()
        {
            _request.Name = PrimitiveGenerator.Alpha(101);

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.Name);
        }

        [Test]
        public void WhenDescriptionTooLong_ShouldReturnError()
        {
            _request.Description = PrimitiveGenerator.Alpha(2001);

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.Description);
        }

        [Test]
        public void WhenEventTypeNotInEnumBounds_ShouldReturnError()
        {
            _request.EventType = (EventType)7;

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.EventType);
        }

        [Test]
        public void WhenMaxNoAttendeesSizeTooSmall_ShouldReturnError()
        {
            _request.MaxNoAttendees = -4;

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.MaxNoAttendees);
        }

        [Test]
        public void WhenMaxNoAttendeesSizeTooBig_ShouldReturnError()
        {
            _request.MaxNoAttendees = 10000001;

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.MaxNoAttendees);
        }
    }
}
