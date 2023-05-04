using FluentValidation;
using Utility.ErrorMessages;
using Utility.Regexes;

namespace ConcertApp.API.Requests.Concerts
{
    public class RemoveParticipantRequest
    {
        public string Email { get; set; }
        public int ConcertId { get; set; }
    }

    public class RemoveParticipantRequestValidator : AbstractValidator<RemoveParticipantRequest>
    {
        public RemoveParticipantRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(UserErrors.EmailLength)
                .Length(10, 100)
                .WithMessage(UserErrors.EmailLength)
                .Matches(Regexes.Email)
                .WithMessage(UserErrors.EmailFormat);

            RuleFor(x => x.ConcertId)
                .NotEmpty()
                .WithMessage(ConcertErrors.ConcertId)
                .GreaterThan(0)
                .WithMessage(ConcertErrors.ConcertId);
        }
    }
}
