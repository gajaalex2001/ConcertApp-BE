using ConcertApp.API.Models;
using FluentValidation;
using Utility.ErrorMessages;

namespace ConcertApp.API.Requests.Concerts
{
    public class GetPageRequest
    {
        public PageRequest PageRequest { get; set; }
        public ConcertFilters Filters { get; set; }
    }

    public class GetPageRequestValidator : AbstractValidator<GetPageRequest>
    {
        public GetPageRequestValidator()
        {
            RuleFor(x => x.PageRequest)
                .NotEmpty()
                .WithMessage(ConcertErrors.PageRequestEmpty)
                .SetValidator(new PageRequestValidator());

            RuleFor(x => x.Filters)
                .SetValidator(new ConcertFiltersValidator());
        }
    }
}
