using EvoEvents.API.Shared.Models;
using FluentValidation;

namespace EvoEvents.API.Requests.Events
{
    public class ViewAllEventsRequest 
    {
        public PaginationModel PaginationModel { get; set; }
    }

    public class ViewAllEventsRequestValidator : AbstractValidator<ViewAllEventsRequest>
    {
        public ViewAllEventsRequestValidator()
        {
            RuleFor(x => x.PaginationModel).SetValidator(new PaginationModelValidator());
        }
    }
}