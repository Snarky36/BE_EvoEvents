using FluentValidation;
using Infrastructure.Utilities.ErrorStrings;
using Infrastructure.Utilities.RegEx;

namespace EvoEvents.API.Requests.Users
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage(ErrorMessages.WrongCredentialsError)
                .MinimumLength(7).WithMessage(ErrorMessages.WrongCredentialsError)
                .MaximumLength(74).WithMessage(ErrorMessages.WrongCredentialsError)
                .Matches(RegularExpression.EmailFormat).WithMessage(ErrorMessages.WrongCredentialsError);
            RuleFor(u => u.Password)
                .NotEmpty().WithMessage(ErrorMessages.WrongCredentialsError)
                .MinimumLength(2).WithMessage(ErrorMessages.WrongCredentialsError)
                .MaximumLength(20).WithMessage(ErrorMessages.WrongCredentialsError)
                .Matches(RegularExpression.NoWhiteSpaces).WithMessage(ErrorMessages.WrongCredentialsError);
        }
    }
}
