using EvoEvents.API.Requests.Events;
using NUnit.Framework;
using FluentValidation.TestHelper;
using EvoEvents.API.Shared.Models;

namespace EvoEvents.UnitTests.Api.Validators.Events
{
    [TestFixture]
    public class GetEventsRequestValidatorTests
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
                }
            };
        }

        [Test]
        public void WhenPageNumberLowerThanZero_ShouldReturnError()
        {
            _request.PaginationModel.PageNumber = -1;

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.PaginationModel.PageNumber);
        }

        [Test]
        public void WhenItemsPerPateLowerThanZero_ShouldReturnError()
        {
            _request.PaginationModel.ItemsPerPage = -1;

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.PaginationModel.ItemsPerPage);
        }
    }
}