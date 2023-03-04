using FluentValidation;
using Utility.ErrorMessages;
using Utility.Regexes;

namespace ConcertApp.API.Requests.Users
{
    public class LoginUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginUserRequestValidator : AbstractValidator<LoginUserRequest>
    {
        public LoginUserRequestValidator() 
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(UserErrors.WrongCredentials)
                .Length(10, 100)
                .WithMessage(UserErrors.WrongCredentials)
                .Matches(Regexes.Email)
                .WithMessage(UserErrors.WrongCredentials);

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(UserErrors.WrongCredentials)
                .Length(3, 30)
                .WithMessage(UserErrors.WrongCredentials)
                .Matches(Regexes.NoWhiteSpace)
                .WithMessage(UserErrors.WrongCredentials);
        }
    }
}
