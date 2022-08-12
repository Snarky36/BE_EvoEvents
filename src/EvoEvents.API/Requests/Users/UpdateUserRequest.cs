using FluentValidation;
using Infrastructure.Utilities.Errors;
using Infrastructure.Utilities.RegEx;

namespace EvoEvents.API.Requests.Users
{
    public class UpdateUserRequest
    {
        public string Email { get; set; }
        public string Company{ get; set; }   
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public string OldPassword { get; set; }    
        public string NewPassword{ get; set; }  
    }

    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty()
                .Length(7, 74).WithMessage(ErrorMessage.EmailLengthError)
                .Matches(RegularExpression.EmailFormat).WithMessage(ErrorMessage.EmailFormatError);
            RuleFor(u => u.FirstName)
                .NotEmpty()
                .Length(2, 100).WithMessage(ErrorMessage.FirstNameLengthError)
                .Matches(RegularExpression.AlphaWhiteSpacesDash).WithMessage(ErrorMessage.FirstNameFormatError);
            RuleFor(u => u.LastName)
                .NotEmpty()
                .Length(2, 100).WithMessage(ErrorMessage.LastNameLengthError)
                .Matches(RegularExpression.AlphaWhiteSpacesDash).WithMessage(ErrorMessage.LastNameFormatError);
            RuleFor(u => u.Company)
                .NotEmpty()
                .Length(2, 100).WithMessage(ErrorMessage.CompanyLengthError)
                .Matches(RegularExpression.Alphanumeric).WithMessage(ErrorMessage.CompanyFormatError);
            RuleFor(u => u.OldPassword)
                .Length(2, 20).WithMessage(ErrorMessage.PasswordLengthError)
                .Matches(RegularExpression.NoWhiteSpaces).WithMessage(ErrorMessage.PasswordWhiteSpaceError);
            RuleFor(u => u.NewPassword)
               .Length(2, 20).WithMessage(ErrorMessage.PasswordLengthError)
               .Matches(RegularExpression.NoWhiteSpaces).WithMessage(ErrorMessage.PasswordWhiteSpaceError);
            RuleFor(e => e).Must(e => (e.OldPassword != null) == (e.NewPassword != null))
               .WithMessage(ErrorMessage.PasswordAndNewPasswordError);
        }
    }
}