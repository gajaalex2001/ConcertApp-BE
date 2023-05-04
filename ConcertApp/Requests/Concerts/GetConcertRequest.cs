using FluentValidation;
using Utility.ErrorMessages;

namespace ConcertApp.API.Requests.Concerts
{
    public class GetConcertRequest
    {
        public int ConcertId { get; set; }
    }

    public class GetConcertRequestValidator : AbstractValidator<GetConcertRequest>
    {
        public GetConcertRequestValidator()
        {
            RuleFor(x => x.ConcertId)
                .NotEmpty()
                .WithMessage(ConcertErrors.ConcertId)
                .GreaterThan(0)
                .WithMessage(ConcertErrors.ConcertId);
        }
    }
}
