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
                .MinimumLength(7).WithMessage(ErrorMessage.WrongCredentialsError)
                .MaximumLength(74).WithMessage(ErrorMessage.WrongCredentialsError)
                .Matches(RegularExpression.EmailFormat).WithMessage(ErrorMessage.WrongCredentialsError);
            RuleFor(u => u.Password)
                .NotEmpty().WithMessage(ErrorMessage.WrongCredentialsError)
                .MinimumLength(2).WithMessage(ErrorMessage.WrongCredentialsError)
                .MaximumLength(20).WithMessage(ErrorMessage.WrongCredentialsError)
                .Matches(RegularExpression.NoWhiteSpaces).WithMessage(ErrorMessage.WrongCredentialsError);
        }
    }
}