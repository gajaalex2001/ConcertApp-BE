using FluentValidation;
using Utility.ErrorMessages;
using Utility.Regexes;

namespace ConcertApp.API.Requests.Concerts
{
    public class GetUpcomingConcertsRequest
    {
        public string Email { get; set; }
        public DateTime CurrentDate { get; set; }
    }

    public class GetUpcomingConcertRequestValidator : AbstractValidator<GetUpcomingConcertsRequest>
    {
        public GetUpcomingConcertRequestValidator() 
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(UserErrors.EmailLength)
                .Length(10, 100)
                .WithMessage(UserErrors.EmailLength)
                .Matches(Regexes.Email)
                .WithMessage(UserErrors.EmailFormat);

            RuleFor(x => x.CurrentDate)
                .NotEmpty()
                .WithMessage(ConcertErrors.CurrentDate);
        }
    }
}
