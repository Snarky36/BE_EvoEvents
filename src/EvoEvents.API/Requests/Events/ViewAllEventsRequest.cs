using EvoEvents.API.Shared.Models;
using EvoEvents.Data.Models.Events;
using FluentValidation;
using Infrastructure.Utilities.Errors.ErrorMessages;
using Infrastructure.Utilities.RegEx;

namespace EvoEvents.API.Requests.Events
{
    public class ViewAllEventsRequest 
    {
        public PaginationModel PaginationModel { get; set; }
        public string Email { get; set; }
        public bool Registered { get; set; } = true;
        public EventType EventType { get; set; }
    }

    public class ViewAllEventsRequestValidator : AbstractValidator<ViewAllEventsRequest>
    {
        public ViewAllEventsRequestValidator()
        {
            RuleFor(x => x.PaginationModel)
                .NotEmpty()
                .SetValidator(new PaginationModelValidator());
            RuleFor(x => x.Email)
                .Length(7, 74).WithMessage(UserErrorMessage.EmailFormat)
                .Matches(RegularExpression.EmailFormat).WithMessage(UserErrorMessage.EmailFormat);
            RuleFor(x => x.EventType)
                .IsInEnum();
        }
    }
}