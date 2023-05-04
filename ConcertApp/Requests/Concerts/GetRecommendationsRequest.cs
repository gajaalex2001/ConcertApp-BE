using FluentValidation;
using Utility.ErrorMessages;
using Utility.Regexes;

namespace ConcertApp.API.Requests.Concerts
{
    public class GetRecommendationsRequest
    {
        public string Email { get; set; }
    }

    public class GetRecommendationsRequestValidator : AbstractValidator<GetRecommendationsRequest>
    {
        public GetRecommendationsRequestValidator()
        {
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
