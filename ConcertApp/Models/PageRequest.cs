using FluentValidation;
using Utility.ErrorMessages;

namespace ConcertApp.API.Models
{
    public class PageRequest
    {
        public int PageIndex { get; set; }
        public int ItemsPerPage { get; set; }
    }

    public class PageRequestValidator : AbstractValidator<PageRequest>
    {
        public PageRequestValidator()
        {
            RuleFor(x => x.PageIndex)
                .NotEmpty()
                .WithMessage(ConcertErrors.PageIndexEmpty)
                .GreaterThan(0)
                .WithMessage(ConcertErrors.PageIndexBelowOne);

            RuleFor(x => x.ItemsPerPage)
                .NotEmpty()
                .WithMessage(ConcertErrors.ItemsPerPageEmpty)
                .GreaterThan(0)
                .WithMessage(ConcertErrors.ItemsPerPageBelowOne);
        }
    }
}
