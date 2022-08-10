using FluentValidation;
using Infrastructure.Utilities.Errors;
using System;

namespace EvoEvents.API.Shared.Models
{
    public class PaginationModel
    {
        public int PageNumber { get; set; }
        public int ItemsPerPage { get; set; }
    }
    public class PaginationModelValidator : AbstractValidator<PaginationModel>
    {
        public PaginationModelValidator()
        {
            RuleFor(e => e.PageNumber)
                .GreaterThan(0).WithMessage(ErrorMessage.InvalidPageNumberError);
            RuleFor(e => e.ItemsPerPage)
                .GreaterThan(0).WithMessage(ErrorMessage.InvalidPageSizeError);
        }
    }
}