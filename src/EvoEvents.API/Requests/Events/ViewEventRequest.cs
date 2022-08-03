using EvoEvents.Data.Models.Events;
using FluentValidation;
using Infrastructure.Utilities.Errors;
using Infrastructure.Utilities.RegEx;

namespace EvoEvents.API.Requests.Events
{
    public class ViewEventRequest
    {
        public int Id { get; set; }
    }
    public class ViewEventRequestValidator : AbstractValidator<ViewEventRequest>
    {
        public ViewEventRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty()
                .GreaterThan(0).WithMessage(ErrorMessage.InvalidIdValueError);
        }
    }
}