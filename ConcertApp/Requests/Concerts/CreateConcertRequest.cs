using ConcertApp.Data.Models.Concerts;
using FluentValidation;
using Utility.ErrorMessages;
using Utility.Regexes;

namespace ConcertApp.API.Requests.Concerts
{
    public class CreateConcertRequest
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MusicGenre Genre { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class CreateConcertRequestValidator : AbstractValidator<CreateConcertRequest>
    {
        public CreateConcertRequestValidator() 
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(UserErrors.EmailLength)
                .Length(10, 100)
                .WithMessage(UserErrors.EmailLength)
                .Matches(Regexes.Email)
                .WithMessage(UserErrors.EmailFormat);

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(ConcertErrors.Name)
                .Length(2, 100)
                .WithMessage(ConcertErrors.Name)
                .Matches(Regexes.AlphaNumericSpaceDashDotComma)
                .WithMessage(ConcertErrors.Name);

            RuleFor(x => x.Description)
                .MaximumLength(2000)
                .WithMessage(ConcertErrors.Description)
                .Matches(Regexes.AlphaNumericSpaceDashDotComma)
                .WithMessage(ConcertErrors.Description);

            RuleFor(x => x.Location)
                .NotEmpty()
                .WithMessage(ConcertErrors.Location)
                .Length(2, 100)
                .WithMessage(ConcertErrors.Location)
                .Matches(Regexes.AlphaNumericSpaceDashDotComma)
                .WithMessage(ConcertErrors.Location);

            RuleFor(x => x.Genre)
                .NotEmpty()
                .WithMessage(ConcertErrors.Genre)
                .IsInEnum()
                .WithMessage(ConcertErrors.Genre);

            RuleFor(x => x.Capacity)
                .NotEmpty()
                .WithMessage(ConcertErrors.Capacity)
                .InclusiveBetween(1, 100000)
                .WithMessage(ConcertErrors.Capacity);

            RuleFor(x => x.StartDate)
                .NotEmpty()
                .WithMessage(ConcertErrors.StartDate)
                .Must(date => date.ToUniversalTime() > DateTime.UtcNow)
                .WithMessage(ConcertErrors.StartDate);

            RuleFor(x => x)
                .NotEmpty()
                .WithMessage(ConcertErrors.EndDate)
                .Must(x => x.EndDate.ToUniversalTime() > DateTime.UtcNow)
                .WithMessage(ConcertErrors.EndDate)
                .Must(x => x.EndDate.ToUniversalTime() > x.StartDate.ToUniversalTime())
                .WithMessage(ConcertErrors.EndDateAheadOfStartDate);
        }
    }
}
