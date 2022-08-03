using AutoFixture;
using EvoEvents.API.Requests.Events;
using EvoEvents.Data.Models.Events;
using FluentValidation.TestHelper;
using Infrastructure.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoEvents.UnitTests.Api.Validators.Events
{
    [TestFixture]
    public class ViewEventRequestValidatorTests
    {
        private ViewEventRequestValidator _validator;
        private ViewEventRequest _request;

        [SetUp]
        public void Init()
        {
            _validator = new ViewEventRequestValidator();
            SetupRequest();
        }

        private void SetupRequest()
        {
            _request = new ViewEventRequest
            {
                Id=1
            };
        }

        [Test]
        public void WhenIdMissing_ShouldReturnError()
        {
            _request = new ViewEventRequest();

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.Id);
        }

        [Test]
        public void WhenIdNegative_ShouldReturnError()
        {
            _request.Id = -1;

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.Id);
        }
    }
}