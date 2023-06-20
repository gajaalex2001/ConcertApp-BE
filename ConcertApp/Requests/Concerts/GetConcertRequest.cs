using FluentValidation;
using Utility.ErrorMessages;
using Utility.Regexes;

namespace ConcertApp.API.Requests.Concerts
{
    public class GetConcertRequest
    {
        public int ConcertId { get; set; }
        public string Email { get; set; }
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

            RuleFor(x => x.Email)
               .NotEmpty()
               .WithMessage(UserErrors.EmailLength)
               .Length(10, 100)
               .WithMessage(UserErrors.EmailLength)
               .Matches(Regexes.Email)
               .WithMessage(UserErrors.EmailFormat);
        }
    }
}
