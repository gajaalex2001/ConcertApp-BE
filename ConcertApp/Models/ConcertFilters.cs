using ConcertApp.Data.Models.Concerts;
using ConcertApp.Data.Models.UserConcerts;
using FluentValidation;
using Utility.ErrorMessages;
using Utility.Regexes;

namespace ConcertApp.API.Models
{
    public class ConcertFilters
    {
        public string? Email { get; set; }
        public MusicGenre? MusicGenre { get; set; }
        public UserStatus? UserStatus { get; set; }
    }

    public class ConcertFiltersValidator : AbstractValidator<ConcertFilters>
    {
        public ConcertFiltersValidator()
        {
            RuleFor(x => x.MusicGenre)
                .IsInEnum()
                .WithMessage(ConcertErrors.Genre);

            RuleFor(x => x.UserStatus)
                .IsInEnum()
                .WithMessage(ConcertErrors.UserStatus);

            RuleFor(x => x)
                .Must(x => (x.Email != null) == (x.UserStatus != null))
                .WithMessage(ConcertErrors.EmailAndUserStatus);

            RuleFor(x => x.Email)
                    .Length(10, 100)
                    .WithMessage(UserErrors.EmailLength)
                    .Matches(Regexes.Email)
                    .WithMessage(UserErrors.EmailFormat);
        }
    }
}
