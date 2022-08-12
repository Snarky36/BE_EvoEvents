﻿using EvoEvents.Data.Models.Addresses;
using EvoEvents.Data.Models.Events;
using FluentValidation;
using Infrastructure.Utilities.Errors.ErrorMessages;
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
                .NotEmpty().WithMessage(EventErrorMessage.NameFormat)
                .Length(2, 100).WithMessage(EventErrorMessage.NameFormat)
                .Matches(RegularExpression.Alphanumeric).WithMessage(EventErrorMessage.NameFormat);
            RuleFor(e => e.Description)
                .Length(0, 2000).WithMessage(EventErrorMessage.DescriptionFormat)
                .Matches(RegularExpression.Alphanumeric).WithMessage(EventErrorMessage.DescriptionFormat);
            RuleFor(e => e.EventType)
                .NotEmpty().WithMessage(EventErrorMessage.EventTypeNull)
                .IsInEnum();
            RuleFor(e => e.MaxNoAttendees)
                .NotNull().WithMessage(EventErrorMessage.MaxNoAttendeesFormat)
                .InclusiveBetween(1, 100000).WithMessage(EventErrorMessage.MaxNoAttendeesFormat);
            RuleFor(e => e.Location)
                .NotEmpty().WithMessage(AddressErrorMessage.LocationFormat)
                .Length(10, 50).WithMessage(AddressErrorMessage.LocationFormat);
            RuleFor(e => e.City)
                .NotEmpty().WithMessage(EventErrorMessage.EventTypeNull)
                .IsInEnum();
            RuleFor(e => e.Country)
                .NotEmpty().WithMessage(EventErrorMessage.EventTypeNull)
                .IsInEnum();
        }
    }
}