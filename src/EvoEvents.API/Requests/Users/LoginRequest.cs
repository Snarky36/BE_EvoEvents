using FluentValidation;
using Infrastructure.Utilities.Errors;
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
                .NotEmpty().WithMessage(ErrorMessage.WrongCredentialsError)
                .Length(7, 74).WithMessage(ErrorMessage.WrongCredentialsError)
                .Matches(RegularExpression.EmailFormat).WithMessage(ErrorMessage.WrongCredentialsError);
            RuleFor(u => u.Password)
                .NotEmpty().WithMessage(ErrorMessage.WrongCredentialsError)
                .Length(2, 20).WithMessage(ErrorMessage.WrongCredentialsError)
                .Matches(RegularExpression.NoWhiteSpaces).WithMessage(ErrorMessage.WrongCredentialsError);
        }
    }
}