using FluentValidation;
using Infrastructure.Utilities.Errors;
using Infrastructure.Utilities.RegEx;

namespace EvoEvents.API.Requests.Users
{
    public class UpdateUserRequest
    {
        public string Email { get; set; }
        public string NewCompany{ get; set; }   
        public string NewFirstName { get; set; }
        public string NewLastName { get; set; }    
        public string Password { get; set; }    
        public string NewPassword{ get; set; }  
    }

    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty()
                .MinimumLength(7).WithMessage(ErrorMessage.EmailLengthError)
                .MaximumLength(74).WithMessage(ErrorMessage.EmailLengthError)
                .Matches(RegularExpression.EmailFormat).WithMessage(ErrorMessage.EmailFormatError);
            RuleFor(u => u.NewFirstName)
                .NotEmpty()
                .MinimumLength(2).WithMessage(ErrorMessage.FirstNameLengthError)
                .MaximumLength(100).WithMessage(ErrorMessage.FirstNameLengthError)
                .Matches(RegularExpression.AlphaWhiteSpacesDash).WithMessage(ErrorMessage.FirstNameFormatError);
            RuleFor(u => u.NewLastName)
                .NotEmpty()
                .MinimumLength(2).WithMessage(ErrorMessage.LastNameLengthError)
                .MaximumLength(100).WithMessage(ErrorMessage.LastNameLengthError)
                .Matches(RegularExpression.AlphaWhiteSpacesDash).WithMessage(ErrorMessage.LastNameFormatError);
            RuleFor(u => u.NewCompany)
                .NotEmpty()
                .MinimumLength(2).WithMessage(ErrorMessage.CompanyLengthError)
                .MaximumLength(100).WithMessage(ErrorMessage.CompanyLengthError)
                .Matches(RegularExpression.Alphanumeric).WithMessage(ErrorMessage.CompanyFormatError);
            RuleFor(u => u.Password)
                .MinimumLength(2).WithMessage(ErrorMessage.PasswordLengthError)
                .MaximumLength(20).WithMessage(ErrorMessage.PasswordLengthError)
                .Matches(RegularExpression.NoWhiteSpaces).WithMessage(ErrorMessage.PasswordWhiteSpaceError);
            RuleFor(u => u.NewPassword)
               .MinimumLength(2).WithMessage(ErrorMessage.PasswordLengthError)
               .MaximumLength(20).WithMessage(ErrorMessage.PasswordLengthError)
               .Matches(RegularExpression.NoWhiteSpaces).WithMessage(ErrorMessage.PasswordWhiteSpaceError);
            RuleFor(e => e).Must(e => (e.Password != null) == (e.NewPassword != null))
               .WithMessage(ErrorMessage.PasswordAndNewPasswordError);
        }
    }
}