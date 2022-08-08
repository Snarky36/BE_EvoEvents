using EvoEvents.Data.Models.Addresses;
using EvoEvents.Data.Models.Events;
using FluentValidation;
using Infrastructure.Utilities.Errors;
using Infrastructure.Utilities.RegEx;

namespace EvoEvents.API.Requests.Events
{
    public class CreateEventRequest
    {
        public EventType EventType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxNoAttendees { get; set; }
        public string Location { get; set; }
        public City City { get; set; }
        public Country Country { get; set; }
    }
    public class CreateEventRequestValidator : AbstractValidator<CreateEventRequest>
    {
        public CreateEventRequestValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage(ErrorMessage.NameFormatError)
                .MinimumLength(2).WithMessage(ErrorMessage.NameFormatError)
                .MaximumLength(100).WithMessage(ErrorMessage.NameFormatError)
                .Matches(RegularExpression.Alphanumeric).WithMessage(ErrorMessage.NameFormatError);
            RuleFor(e => e.Description)
                .MaximumLength(2000).WithMessage(ErrorMessage.DescriptionFormatError)
                .Matches(RegularExpression.Alphanumeric).WithMessage(ErrorMessage.DescriptionFormatError);
            RuleFor(e => e.EventType)
                .NotEmpty().WithMessage(ErrorMessage.EventTypeNullError)
                .IsInEnum();
            RuleFor(e => e.MaxNoAttendees)
                .NotNull().WithMessage(ErrorMessage.MaxNoAttendeesFormatError)
                .GreaterThan(0).WithMessage(ErrorMessage.MaxNoAttendeesSizeError)
                .LessThan(100000).WithMessage(ErrorMessage.MaxNoAttendeesSizeError);
            RuleFor(e => e.Location)
                .NotEmpty().WithMessage(ErrorMessage.AddressLocationLenghtError)
                .Length(10, 50).WithMessage(ErrorMessage.AddressLocationLenghtError);
            RuleFor(e => e.City)
                .NotEmpty().WithMessage(ErrorMessage.EventTypeNullError)
                .IsInEnum();
            RuleFor(e => e.Country)
                .NotEmpty().WithMessage(ErrorMessage.EventTypeNullError)
                .IsInEnum();
        }
    }
}