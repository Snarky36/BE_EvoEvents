using AutoFixture;
using EvoEvents.API.Requests.Users;
using FluentValidation.TestHelper;
using Infrastructure.Utilities;
using NUnit.Framework;

namespace EvoEvents.UnitTests.Api.Validators.Users
{
    [TestFixture]
    public class UpdateUserRequestValidatorTests
    {
        private UpdateUserRequestValidator _validator;
        private IFixture _fixture;
        private UpdateUserRequest _request;

        [SetUp]
        public void Init()
        {
            _validator = new UpdateUserRequestValidator();
            _fixture = new Fixture();
            SetupRequest();
        }

        private void SetupRequest()
        {
            _request = new UpdateUserRequest
            {
                Email = "maria234@yahoo.com",
                NewFirstName = "Maria",
                NewLastName = "Oltean",
                NewCompany = "Evozon",
                Password = "maria123",
                NewPassword = "maria1234"
            };
        }

        [Test]
        public void WhenNewFirstNameMissing_ShouldReturnError()
        {
            _request.NewFirstName = null;

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.NewFirstName);
        }

        [Test]
        public void WhenNewLastNameMissing_ShouldReturnError()
        {
            _request.NewLastName = null;

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.NewLastName);
        }

        [Test]
        public void WhenNewCompanyMissing_ShouldReturnError()
        {
            _request.NewCompany = null;

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.NewCompany);
        }

        [Test]
        public void WhenEmailMissing_ShouldReturnError()
        {
            _request.Email = null;

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.Email);
        }

        [Test]
        public void WhenNewFirstNameTooShort_ShouldReturnError()
        {
            _request.NewFirstName = PrimitiveGenerator.Alpha(1);

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.NewFirstName);
        }

        [Test]
        public void WhenNewLastNameTooShort_ShouldReturnError()
        {
            _request.NewLastName = PrimitiveGenerator.Alpha(1);

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.NewLastName);
        }

        [Test]
        public void WhenNewCompanyTooShort_ShouldReturnError()
        {
            _request.NewCompany = PrimitiveGenerator.Alpha(1);

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.NewCompany);
        }

        [Test]
        public void WhenEmailTooShort_ShouldReturnError()
        {
            _request.Email = PrimitiveGenerator.Alphanumeric(1) + "@.com";

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.Email);
        }

        [Test]
        public void WhenPasswordTooShort_ShouldReturnError()
        {
            _request.Password = PrimitiveGenerator.Alphanumeric(1);

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.Password);
        }

        [Test]
        public void WhenNewPasswordTooShort_ShouldReturnError()
        {
            _request.NewPassword = PrimitiveGenerator.Alphanumeric(1);

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.NewPassword);
        }

        [Test]
        public void WhenNewFirstNameTooLong_ShouldReturnError()
        {
            _request.NewFirstName = PrimitiveGenerator.Alpha(101);

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.NewFirstName);
        }

        [Test]
        public void WhenEmailTooLong_ShouldReturnError()
        {
            _request.Email = PrimitiveGenerator.Alphanumeric(50) + "@" + PrimitiveGenerator.Alpha(50) + ".com";

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.Email);
        }

        [Test]
        public void WhenNewCompanyTooLong_ShouldReturnError()
        {
            _request.NewCompany = PrimitiveGenerator.Alphanumeric(101);

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.NewCompany);
        }

        [Test]
        public void WhenNewLastNameTooLong_ShouldReturnError()
        {
            _request.NewLastName = PrimitiveGenerator.Alpha(101);

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.NewLastName);
        }

        [Test]
        public void WhenPasswordTooLong_ShouldReturnError()
        {
            _request.Password = PrimitiveGenerator.Alphanumeric(101);

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.Password);
        }

        [Test]
        public void WhenNewPasswordTooLong_ShouldReturnError()
        {
            _request.NewPassword = PrimitiveGenerator.Alphanumeric(101);

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.NewPassword);
        }

        [Test]
        public void WhenNewFirstNameHasWrongFormat_ShouldReturnError()
        {
            _request.NewFirstName = PrimitiveGenerator.Alpha(10) + "1";

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.NewFirstName);
        }

        [Test]
        public void WhenNewLastNameHasWrongFormat_ShouldReturnError()
        {
            _request.NewLastName = PrimitiveGenerator.Alphanumeric(10) + "1";

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.NewLastName);
        }

        [Test]
        public void WhenEmailHasWrongFormat_ShouldReturnError()
        {
            _request.Email = PrimitiveGenerator.Alphanumeric(10);

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.Email);
        }

        [Test]
        public void WhenNewCompanyHasWrongFormat_ShouldReturnError()
        {
            _request.NewCompany = PrimitiveGenerator.Alpha(10) + "!";

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.NewCompany);
        }

        [Test]
        public void WhenPasswordHasWrongFormat_ShouldReturnError()
        {
            _request.Password = PrimitiveGenerator.Alpha(10) + " ";

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.Password);
        }

        [Test]
        public void WhenNewPasswordHasWrongFormat_ShouldReturnError()
        {
            _request.NewPassword = PrimitiveGenerator.Alpha(10) + " ";

            _validator.TestValidate(_request).ShouldHaveValidationErrorFor(request => request.NewPassword);
        }
    }
}
