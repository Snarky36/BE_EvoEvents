using FluentValidation;
using Infrastructure.Utilities.ErrorStrings;
using Infrastructure.Utilities.RegEx;

namespace EvoEvents.API.Requests.Users
{
    public class CreateUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Company { get; set; }
    }

    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty()
                .MinimumLength(7).WithMessage(ErrorMessages.EmailLengthError)
                .MaximumLength(74).WithMessage(ErrorMessages.EmailLengthError)
                .Matches(RegularExpression.EmailFormat).WithMessage(ErrorMessages.EmailFormatError);
            RuleFor(u => u.FirstName)
                .NotEmpty()
                .MinimumLength(2).WithMessage(ErrorMessages.FirstNameLengthError)
                .MaximumLength(100).WithMessage(ErrorMessages.FirstNameLengthError)
                .Matches(RegularExpression.AlphaWhiteSpacesDash).WithMessage(ErrorMessages.FirstNameFormatError);
            RuleFor(u => u.LastName)
                .NotEmpty()
                .MinimumLength(2).WithMessage(ErrorMessages.LastNameLengthError)
                .MaximumLength(100).WithMessage(ErrorMessages.LastNameLengthError)
                .Matches(RegularExpression.AlphaWhiteSpacesDash).WithMessage(ErrorMessages.LastNameFormatError);
            RuleFor(u => u.Company)
                .NotEmpty()
                .MinimumLength(2).WithMessage(ErrorMessages.CompanyLengthError)
                .MaximumLength(100).WithMessage(ErrorMessages.CompanyLengthError)
                .Matches(RegularExpression.Alphanumeric).WithMessage(ErrorMessages.CompanyFormatError);
            RuleFor(u => u.Password)
                .NotEmpty()
                .MinimumLength(2).WithMessage(ErrorMessages.PasswordLengthError)
                .MaximumLength(20).WithMessage(ErrorMessages.PasswordLengthError)
                .Matches(RegularExpression.NoWhiteSpaces).WithMessage(ErrorMessages.PasswordWhiteSpaceError);
        }
    }
}
