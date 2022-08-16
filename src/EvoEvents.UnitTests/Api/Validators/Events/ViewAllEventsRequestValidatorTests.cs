using EvoEvents.API.Requests.Events;
using NUnit.Framework;
using FluentValidation.TestHelper;
using EvoEvents.API.Shared.Models;
using EvoEvents.Data.Models.Events;
using Infrastructure.Utilities;

namespace EvoEvents.UnitTests.Api.Validators.Events
{
    [TestFixture]
    public class ViewAllEventsRequestValidatorTests
    {
        private ViewAllEventsRequestValidator _validator;
        private ViewAllEventsRequest _request;

        [SetUp]
        public void Init()
        {
            _validator = new ViewAllEventsRequestValidator();
            SetupRequest();
        }

        private void SetupRequest()
        {
            _request = new ViewAllEventsRequest
            {
                PaginationModel = new PaginationModel
                {
                    PageNumber = 1,
                    ItemsPerPage = 5
                },
                Email = "ion@evozon.com",
                Registered = true,
                EventType = EventType.Talk
            };
        }

        [Test]
        public void WhenPaginationModelMissing_ShouldReturnError()
        {
            _request.PaginationModel = null;

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.PaginationModel);
        }

        [Test]
        public void WhenEmailTooLong_ShouldReturnError()
        {
            _request.Email = PrimitiveGenerator.Alphanumeric(50) + "@" + PrimitiveGenerator.Alpha(50) + ".com";

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.Email);
        }

        [Test]
        public void WhenEmailTooShort_ShouldReturnError()
        {
            _request.Email = PrimitiveGenerator.Alphanumeric(1) + "@.com";

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.Email);
        }

        [Test]
        public void WhenEmailHasWrongFormat_ShouldReturnError()
        {
            _request.Email = PrimitiveGenerator.Alphanumeric(10);

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.Email);
        }

        [Test]
        public void WhenItemsPerPateLowerThanZero_ShouldReturnError()
        {
            _request.PaginationModel.ItemsPerPage = -1;

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.PaginationModel.ItemsPerPage);
        }

        [Test]
        public void WhenEventTypeNotInEnumBounds_ShouldReturnError()
        {
            _request.EventType = (EventType)1000;

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.EventType);
        }
    }
}