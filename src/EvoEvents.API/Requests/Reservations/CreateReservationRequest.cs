using FluentValidation;
using Infrastructure.Utilities.Errors;
using Infrastructure.Utilities.RegEx;
using Microsoft.AspNetCore.Mvc;

namespace EvoEvents.API.Requests.Events.Reservations
{
    public class CreateReservationRequest
    {
        [FromRoute]   
        public int EventId { get; set; }
        [FromBody]
        public RegistrationInformation RegistrationInformation { get; set; }
    }

    public class CreateReservationRequestValidator : AbstractValidator<CreateReservationRequest>
    {
        public CreateReservationRequestValidator()
        {
            RuleFor(e => e.EventId).NotEmpty()
                .GreaterThan(0).WithMessage(ErrorMessage.InvalidIdValueError);
            RuleFor(e => e.RegistrationInformation)
                .NotEmpty()
                .SetValidator(new RegistrationInformationValidator());
        }
    }
}